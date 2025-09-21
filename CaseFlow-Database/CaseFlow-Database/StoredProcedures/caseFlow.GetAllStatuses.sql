CREATE PROCEDURE [caseFlow].[GetAllStatuses]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Title
	FROM [caseFlow].[Status]

	SET NOCOUNT OFF;
END