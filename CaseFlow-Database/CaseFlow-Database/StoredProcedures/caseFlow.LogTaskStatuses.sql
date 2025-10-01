CREATE PROCEDURE [caseFlow].[LogTaskStatuses]
	@taskToUpdate	TaskUpdateList	READONLY,
	@caseworkerId	INT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [caseFlow].[TaskStatus] (TaskId, StatusId, CaseworkerId, [Notes], LogDateTime)
	SELECT								tu.TaskId, tu.StatusId, @caseworkerId, tu.Notes, tu.LogDateTime
	FROM		@taskToUpdate tu
	
END