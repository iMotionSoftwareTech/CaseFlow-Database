CREATE PROCEDURE [caseFlow].[UpdatePasswordAttempt]
	@caseworkerId	INT
AS
BEGIN TRY
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	DECLARE @passwordAttempt	INT = 3,
			@lockAccount		BIT = 1

	BEGIN TRANSACTION
		UPDATE		u
		SET			u.PasswordAttempt = u.PasswordAttempt +1
		FROM		[caseFlow].[User] u
		WHERE		u.CaseworkerId = @caseworkerId
		AND			u.PasswordAttempt < @passwordAttempt

		UPDATE		u
		SET			u.IsLocked = @lockAccount
		FROM		[caseFlow].[User] u
		WHERE		u.CaseworkerId = @caseworkerId
		AND			u.PasswordAttempt = @passwordAttempt
	COMMIT TRANSACTION;

	SET NOCOUNT OFF;
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	THROW;
END CATCH