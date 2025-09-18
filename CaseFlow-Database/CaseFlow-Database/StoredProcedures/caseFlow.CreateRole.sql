CREATE PROCEDURE [caseFlow].[CreateRole]
	@roleName		NVARCHAR(256),
	@description	NVARCHAR(500)
AS
BEGIN TRY
	SET NOCOUNT ON;
	SET XACT_ABORT ON;

	IF EXISTS (SELECT 1 FROM [caseFlow].[CaseworkerRole] WHERE [Name] = @roleName)
		THROW 51003, 'Role already exists.', 1;

	INSERT INTO	[caseFlow].[CaseworkerRole] ([Name], [Description])
	VALUES									(@roleName, @description)
	
	SET NOCOUNT OFF;
END TRY
BEGIN CATCH
	THROW;
END CATCH
