CREATE PROCEDURE [caseFlow].[UpdateTasks]
	@taskToUpdate	TaskUpdateList	READONLY,
	@caseworkerId	INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [caseFlow].[TaskStatus] (TaskId, StatusId, CaseworkerId, [Notes])
	SELECT								tu.TaskId, tu.StatusId, @caseworkerId, tu.Notes
	FROM		@taskToUpdate tu
	
END