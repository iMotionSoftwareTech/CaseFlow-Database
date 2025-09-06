CREATE PROCEDURE [caseFlow].[CreateTask]
	@caseworkerId	INT,
	@title			NVARCHAR(256),
	@description	NVARCHAR(256),
	@dueDateTime	DATETIME2
AS
BEGIN TRY	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF EXISTS (SELECT 1 FROM [caseFlow].[Task] WHERE Title = @title AND DueDateTime = @dueDateTime)
		THROW 51001, 'Task already exists.', 1;
	
	DECLARE @insertedIds		TABLE(Id INT);

	DECLARE @taskId				INT,
			@caseCreatedStatus	NVARCHAR(256) = 'Case Created';

	BEGIN TRANSACTION
		INSERT INTO [caseFlow].[Task]					(Title, [Description], DueDateTime)
		OUTPUT											INSERTED.Id INTO @insertedIds
		VALUES											(@title, @description, @dueDateTime)

		SELECT		@taskId = Id FROM @insertedIds;

		INSERT INTO [caseFlow].[TaskStatus]				(TaskId, StatusId, CaseworkerId)
		SELECT											@taskId, s.Id, @caseworkerId
												FROM	[caseFlow].[Status] s
												WHERE	Title = @caseCreatedStatus
	COMMIT TRANSACTION

	SET NOCOUNT OFF;
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	THROW;
END CATCH