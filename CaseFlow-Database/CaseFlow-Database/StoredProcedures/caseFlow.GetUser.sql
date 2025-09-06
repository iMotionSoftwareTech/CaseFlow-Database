CREATE PROCEDURE [caseFlow].[GetUser]
	@email			NVARCHAR(256)
AS
BEGIN	
	SELECT		u.CaseworkerId, c.CaseworkerRoleId, r.[Name] AS 'Role', c.Email, u.Username, c.Forename, c.Surname, u.PasswordAttempt, u.IsLocked
	FROM		[caseFlow].[User]			u
	INNER JOIN	[caseFlow].[Caseworker]		c ON c.Id = u.CaseworkerId
	INNER JOIN	[caseFlow].[CaseworkerRole] r ON r.Id = c.CaseworkerRoleId
	WHERE		Email = @email
END