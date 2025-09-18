CREATE PROCEDURE [caseFlow].[GetAllRoles]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	Id, [Name], [Description]
	FROM	[caseFlow].[CaseworkerRole]

	SET NOCOUNT OFF;
END
