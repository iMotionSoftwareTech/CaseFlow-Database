CREATE TABLE [caseFlow].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CaseworkerId] INT NOT NULL,
	[Username] NVARCHAR(256) NOT NULL UNIQUE,
	[PasswordHash] VARBINARY(64) NOT NULL,
	[PasswordSalt] VARBINARY(64) NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL,
	[IsLocked] BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_User PRIMARY KEY ([Id]),
	CONSTRAINT FK_User_Caseworker FOREIGN KEY ([CaseworkerId]) REFERENCES [caseFlow].[Caseworker] ([Id])
)

GO 
	CREATE UNIQUE NONCLUSTERED INDEX IX_User_Id on [caseFlow].[User]([Id])
