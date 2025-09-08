CREATE PROCEDURE [caseFlow].[LogTaskStatus]
	@taskId			INT,
	@statusId		INT,
	@caseworkerId	INT,
	@notes			NVARCHAR(256)
AS
BEGIN TRY	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF EXISTS (SELECT 1 FROM [caseFlow].[TaskStatus] WHERE TaskId = @taskId AND StatusId = @statusId)
		THROW 51002, 'Task has already been updated.', 1;
	
	
	INSERT INTO [caseFlow].[TaskStatus]		(TaskId, StatusId, CaseworkerId, Notes)
	VALUES									(@taskId, @statusId, @caseworkerId, @notes)

	SET NOCOUNT OFF;
END TRY
BEGIN CATCH
	THROW;
END CATCH