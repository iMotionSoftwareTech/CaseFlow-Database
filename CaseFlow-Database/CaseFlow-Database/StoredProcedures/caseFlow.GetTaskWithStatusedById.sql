CREATE PROCEDURE [caseFlow].[GetTaskWithStatusedById]
	@taskId		INT
AS
BEGIN

	SELECT ts.Id, ts.TaskId, ts.StatusId, s.Title AS 'Status', c.Forename + ' ' + c.Surname AS 'CaseWorker' , ts.Notes, ts.LogDateTime
	FROM [caseFlow].[TaskStatus]				ts
	INNER JOIN [caseflow].[Status]				s	ON	s.Id = ts.StatusId
	INNER JOIN [caseFlow].[Caseworker]			c	ON	c.Id = ts.CaseworkerId
	WHERE ts.TaskId = @taskId

END
