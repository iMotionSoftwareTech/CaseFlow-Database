/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF CONVERT(INT, SERVERPROPERTY('ProductMajorVersion')) >= 14
BEGIN
    EXEC('ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE OFF;');
END
ELSE
BEGIN
    EXEC('DBCC TRACEON(272, -1);');
END