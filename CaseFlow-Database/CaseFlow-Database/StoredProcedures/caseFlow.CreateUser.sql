CREATE PROCEDURE [caseFlow].[CreateUser]
	@caseworkerRoleId	INT,
	@forename			NVARCHAR(256),
	@surname			NVARCHAR(256),
	@email				NVARCHAR(256),
	@passwordHash		VARBINARY(64),
	@passwordSalt		VARBINARY(64),
	@createdDateTime	DATETIME2
AS
BEGIN TRY	
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF EXISTS (SELECT 1 FROM [caseFlow].Caseworker WHERE Email = @email)
		THROW 51000, 'User already exists.', 1;
	
	DECLARE @insertedIds	TABLE(Id INT);

	DECLARE	@caseworkerId	INT,	
			@userName		NVARCHAR(256);

	SET @username = CONCAT(UPPER(LEFT(@forename, 1)), @surname);

	BEGIN TRANSACTION
		INSERT INTO [caseFlow].[Caseworker] (CaseworkerRoleId, Forename, Surname, Email)
		OUTPUT								INSERTED.Id INTO @insertedIds
		VALUES								(@caseworkerRoleId, @forename, @surname, @email)

		SELECT		@caseworkerId = Id FROM @insertedIds;

		INSERT INTO [caseFlow].[User]		(CaseworkerId, Username, PasswordHash, PasswordSalt, CreatedAt)
		SELECT								@caseworkerId, @userName, @passwordHash, @passwordSalt, @createdDateTime
	COMMIT TRANSACTION

	SET NOCOUNT OFF;
END TRY
BEGIN CATCH
	IF ((@@TRANCOUNT > 0 OR (XACT_STATE()) = -1))
		ROLLBACK TRANSACTION;

	THROW;
END CATCH