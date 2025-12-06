CREATE PROCEDURE [caseFlow].[LogTaskStatuses]
	@taskToUpdate	TaskUpdateList	READONLY,
	@caseworkerId	INT,
	@success		BIT				OUTPUT,
	@insertedCount	INT				OUTPUT,	
	@errorMessage	NVARCHAR(4000)	OUTPUT
AS
BEGIN TRY
	SET NOCOUNT ON;

	SET @success		= 0;
	SET @insertedCount	= 0;	
	SET @errorMessage	= NULL;

	BEGIN TRANSACTION
		INSERT INTO [caseFlow].[TaskStatus] (TaskId, StatusId, CaseworkerId, [Notes], LogDateTime)
		SELECT								tu.TaskId, tu.StatusId, @caseworkerId, tu.Notes, tu.LogDateTime
		FROM		@taskToUpdate tu

		SET @insertedCount = @@ROWCOUNT;

		IF @insertedCount <= 0		
		BEGIN
			SET @errorMessage = N'No task statuses were logged.';
			ROLLBACK TRANSACTION;
			RETURN;
		END
	COMMIT TRANSACTION;


	SET @success = 1;
	RETURN;	
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	DECLARE @errMsg NVARCHAR(4000)	= ERROR_MESSAGE();
	DECLARE @errNum INT				= ERROR_NUMBER();
	SET		@errorMessage			= FORMATMESSAGE(N'Exception %d: %s', @ErrNum, @ErrMsg);
	THROW;
END CATCH