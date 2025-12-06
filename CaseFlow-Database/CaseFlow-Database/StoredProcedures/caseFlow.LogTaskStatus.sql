CREATE PROCEDURE [caseFlow].[LogTaskStatus]
	@taskId			INT,
	@statusId		INT,
	@caseworkerId	INT,
	@notes			NVARCHAR(256),
	@logDateTime	DATETIME2,
	@success		BIT				OUTPUT,
	@taskStatusId	INT				OUTPUT,	
	@errorMessage	NVARCHAR(4000)	OUTPUT
AS
BEGIN TRY	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SET @success		= 0;
	SET @taskStatusId	= NULL;	
	SET @errorMessage	= NULL;

	IF EXISTS (SELECT 1 FROM [caseFlow].[TaskStatus] WHERE TaskId = @taskId AND StatusId = @statusId)
	BEGIN
		SET @errorMessage = N'Task has already been updated.';
		RETURN;
	END

	DECLARE @insertedIds	TABLE(Id INT);
	
	INSERT INTO [caseFlow].[TaskStatus]		(TaskId, StatusId, CaseworkerId, Notes, LogDateTime)
	OUTPUT									INSERTED.Id INTO @insertedIds
	VALUES									(@taskId, @statusId, @caseworkerId, @notes, @logDateTime)

	SELECT @taskStatusId = Id FROM @insertedIds;

	IF NOT EXISTS (SELECT 1 FROM [caseFlow].[TaskStatus] WHERE Id = @taskStatusId)
	BEGIN
		SET @errorMessage = N'Failed to log task status.';
		RETURN;
	END

	SET @success = 1;
	RETURN;
END TRY
BEGIN CATCH
	DECLARE @errMsg NVARCHAR(4000)	= ERROR_MESSAGE();
	DECLARE @errNum INT				= ERROR_NUMBER();
	SET		@errorMessage			= FORMATMESSAGE(N'Exception %d: %s', @ErrNum, @ErrMsg);

	THROW;
END CATCH