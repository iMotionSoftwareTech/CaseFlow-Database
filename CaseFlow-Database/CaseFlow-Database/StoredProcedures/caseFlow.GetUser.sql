CREATE PROCEDURE [caseFlow].[GetUser]
	@email			NVARCHAR(256),
	@passwordSalt	VARBINARY(64),
	@passwordHash	VARBINARY(64)
AS
BEGIN TRY
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF OBJECT_ID ('tempdb..#Caseworkers') IS NOT NULL DROP TABLE #Caseworkers;

	CREATE TABLE #Caseworkers
	(
		[Id]						INT,
		[CaseworkerRoleId]			INT,
		[Forename]					NVARCHAR(256),
		[Surname]					NVARCHAR(256),
		[Email]						NVARCHAR(256)
	)

	-- Find user record
	INSERT INTO #Caseworkers	([Id], [CaseworkerRoleId], [Forename], [Surname], [Email])				
	SELECT						[Id], [CaseworkerRoleId], [Forename], [Surname], [Email]
	FROM		[caseFlow].[Caseworker]
	WHERE		Email = @email

	-- Validate user
	IF NOT EXISTS (SELECT 1 FROM #Caseworkers)
		THROW 51002, 'User does not exist.', 1;

	DECLARE @passwordAttempt	INT = 3,
			@lockAccount		BIT = 1

	-- Validate Password
	IF EXISTS	(SELECT 1 FROM [caseFlow].[User] u INNER JOIN #Caseworkers c ON c.Id = u.CaseworkerId 
					WHERE u.PasswordSalt <> @passwordSalt OR u.PasswordHash <> @passwordHash)
	BEGIN
		BEGIN TRANSACTION
		UPDATE		u
		SET			u.PasswordAttempt = u.PasswordAttempt +1
		FROM		[caseFlow].[User] u
		JOIN		#Caseworkers c ON c.Id = u.CaseworkerId
		WHERE		u.PasswordAttempt < @passwordAttempt

		UPDATE		u
		SET			u.IsLocked = @lockAccount
		FROM		[caseFlow].[User] u
		JOIN		#Caseworkers c ON c.Id = u.CaseworkerId
		WHERE		u.PasswordAttempt = @passwordAttempt
		COMMIT TRANSACTION;
	END
	
	SELECT u.CaseworkerId, c.CaseworkerRoleId, r.[Name], c.Email, u.Username, c.Forename, c.Surname, u.PasswordAttempt, u.IsLocked
	FROM [caseFlow].[User] u
	INNER JOIN #Caseworkers c ON c.Id = u.CaseworkerId
	INNER JOIN [caseFlow].[CaseworkerRole] r ON r.Id = c.CaseworkerRoleId

	SET NOCOUNT OFF;
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	THROW;
END CATCH