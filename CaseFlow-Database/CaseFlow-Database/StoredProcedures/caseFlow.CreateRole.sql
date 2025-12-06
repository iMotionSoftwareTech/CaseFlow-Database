CREATE PROCEDURE [caseFlow].[CreateRole]
	@roleName		NVARCHAR(256),
	@description	NVARCHAR(500),
	@success		BIT				OUTPUT,
	@roleId			INT				OUTPUT,	
	@errorMessage	NVARCHAR(4000)	OUTPUT
AS
BEGIN TRY
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	
	SET @success		= 0;
	SET @roleId			= NULL;
	SET @errorMessage	= NULL;

	IF EXISTS (SELECT 1 FROM [caseFlow].[CaseworkerRole] WHERE [Name] = @roleName)
	BEGIN
		SET @errorMessage = N'Role already exists.';
		RETURN;
	END

	DECLARE @insertedIds	TABLE(Id INT);

	INSERT INTO	[caseFlow].[CaseworkerRole] ([Name], [Description])
	OUTPUT								INSERTED.Id INTO @insertedIds
	VALUES									(@roleName, @description)
	
	SELECT	@roleId = Id FROM @insertedIds;

	IF NOT EXISTS (SELECT 1 FROM [caseFlow].[CaseworkerRole] WHERE Id = @roleId)
	BEGIN
		SET @errorMessage = N'Failed to create caseworker role.';
		ROLLBACK TRANSACTION;
		RETURN;
	END
	
	SET @success = 1;
	RETURN;
END TRY
BEGIN CATCH
	DECLARE @errMsg NVARCHAR(4000)	= ERROR_MESSAGE();
	DECLARE @errNum INT				= ERROR_NUMBER();
	SET		@errorMessage			= FORMATMESSAGE(N'Exception %d: %s', @ErrNum, @ErrMsg);

	THROW;
END CATCH
