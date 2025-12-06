CREATE PROCEDURE [caseFlow].[CreateTask]
	@caseworkerId	INT,
	@title			NVARCHAR(256),
	@description	NVARCHAR(256),
	@dueDateTime	DATETIME2,
	@success		BIT				OUTPUT,
	@taskId			INT				OUTPUT,
	@errorMessage	NVARCHAR(4000)	OUTPUT
AS
BEGIN TRY	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	SET @success		= 0;
	SET @taskId			= NULL;
	SET @errorMessage	= NULL;

	IF EXISTS (SELECT 1 FROM [caseFlow].[Task] WHERE Title = @title AND DueDateTime = @dueDateTime)
	BEGIN
		SET @errorMessage = N'Task already exists.';
		RETURN;
	END
	
	DECLARE @insertedIds		TABLE(Id INT);		

	BEGIN TRANSACTION
		INSERT INTO [caseFlow].[Task]					(Title, [Description], DueDateTime)
		OUTPUT											INSERTED.Id INTO @insertedIds
		VALUES											(@title, @description, @dueDateTime)

		SELECT		@taskId = Id FROM @insertedIds;

		DECLARE @caseCreatedStatus	NVARCHAR(256) = 'Case Created';

		INSERT INTO [caseFlow].[TaskStatus]				(TaskId, StatusId, CaseworkerId, Notes, LogDateTime)
		SELECT											@taskId, s.Id, @caseworkerId, '', SYSUTCDATETIME()
												FROM	[caseFlow].[Status] s
												WHERE	Title = @caseCreatedStatus

		IF NOT EXISTS (SELECT 1 FROM [caseFlow].[TaskStatus] WHERE TaskId = @taskId)
		BEGIN
			SET @errorMessage = N'Failed to create initial task status.';
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

	DECLARE @errMsg NVARCHAR(4000) = ERROR_MESSAGE();
	DECLARE @errNum INT = ERROR_NUMBER();
	SET		@errorMessage = FORMATMESSAGE(N'Exception %d: %s', @ErrNum, @ErrMsg);

	THROW;
END CATCH