CREATE PROCEDURE [caseFlow].[CreateUser]
	@caseworkerRoleId	INT,
	@forename			NVARCHAR(256),
	@surname			NVARCHAR(256),
	@email				NVARCHAR(256),
	@passwordHash		VARBINARY(64),
	@passwordSalt		VARBINARY(64),
	@createdDateTime	DATETIME2,
	@success			BIT				OUTPUT,
	@caseworkerId		INT				OUTPUT,
	@errorMessage		NVARCHAR(4000)	OUTPUT
AS
BEGIN TRY	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	SET @success		= 0;
	SET @caseworkerId	= NULL;
	SET @errorMessage	= NULL;

	IF EXISTS (SELECT 1 FROM [caseFlow].Caseworker WHERE Email = @email)
	BEGIN
		SET @errorMessage = N'User already exists.';
		RETURN;
	END

	DECLARE @insertedIds	TABLE(Id INT);
	
	BEGIN TRANSACTION
		INSERT INTO [caseFlow].[Caseworker] (CaseworkerRoleId, Forename, Surname, Email)
		OUTPUT								INSERTED.Id INTO @insertedIds
		VALUES								(@caseworkerRoleId, @forename, @surname, @email)

		SELECT	@caseworkerId				= Id FROM @insertedIds;

		DECLARE	@userName	NVARCHAR(256)	= CONCAT(UPPER(LEFT(@forename, 1)), @surname);

		INSERT INTO [caseFlow].[User]		(CaseworkerId, Username, PasswordHash, PasswordSalt, CreatedAt)
		SELECT								@caseworkerId, @userName, @passwordHash, @passwordSalt, @createdDateTime

		IF NOT EXISTS (SELECT 1 FROM [caseFlow].[User] WHERE CaseworkerId = @caseworkerId)
		BEGIN
			SET @errorMessage = N'Failed to create user credentials.';
			ROLLBACK TRANSACTION;
			RETURN;
		END

	COMMIT TRANSACTION
	
	SET @success = 1;
	RETURN;
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	DECLARE @errMsg NVARCHAR(4000)	= ERROR_MESSAGE();
	DECLARE @errNum INT				= ERROR_NUMBER();
	SET		@errorMessage			= FORMATMESSAGE(N'Exception %d: %s', @ErrNum, @ErrMsg);

	THROW;
END CATCH