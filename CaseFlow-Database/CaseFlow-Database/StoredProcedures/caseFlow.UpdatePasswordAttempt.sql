CREATE PROCEDURE [caseFlow].[UpdatePasswordAttempt]
	@caseworkerId		INT,
	@maxAttempts		INT = 3,
	@newAttemptCount	INT				OUTPUT,
	@success			BIT				OUTPUT,
	@wasLocked			BIT				OUTPUT,	
	@errorMessage		NVARCHAR(4000)	OUTPUT
AS
BEGIN TRY
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SET @success = 0;
	SET @errorMessage = NULL;

	BEGIN TRANSACTION	
		DECLARE @out TABLE (PasswordAttempt INT, IsLocked BIT)		

		UPDATE		[caseFlow].[User]
		SET			PasswordAttempt = PasswordAttempt + 1, IsLocked =
		CASE WHEN	PasswordAttempt + 1 >= @maxAttempts THEN 1 ELSE IsLocked END
		OUTPUT		INSERTED.PasswordAttempt, INSERTED.IsLocked INTO @out
		WHERE		CaseworkerId = @caseworkerId
		
		IF NOT EXISTS (SELECT 1 FROM @out)
		BEGIN
			ROLLBACK TRANSACTION;
			SET @errorMessage = N'User not found.';
			SET @newAttemptCount = 0;
			SET @wasLocked = 0;
			RETURN;
		END

		SELECT TOP 1
			@newAttemptCount = PasswordAttempt,
			@wasLocked = IsLocked
		FROM @out;
	COMMIT TRANSACTION;

	SET @success = 1;
	RETURN;
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	DECLARE @errMsg NVARCHAR(4000)	= ERROR_MESSAGE();
	DECLARE @errNum INT				= ERROR_NUMBER();

	SET @newAttemptCount			= 0;
	SET @wasLocked					= 0;
	SET	@errorMessage				= FORMATMESSAGE(N'Exception %d: %s', @ErrNum, @ErrMsg);

	THROW;
END CATCH