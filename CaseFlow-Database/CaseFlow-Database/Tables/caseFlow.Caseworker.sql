CREATE TABLE [caseFlow].[Caseworker]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[CaseworkerRoleId] INT NOT NULL,
	[Forename] NVARCHAR(256) NOT NULL,
	[Surname] NVARCHAR(256) NOT NULL,
	[Email] NVARCHAR(256) NOT NULL,
	CONSTRAINT PK_Caseworker PRIMARY KEY ([Id]),
	CONSTRAINT FK_Caseworker_CaseworkerRole FOREIGN KEY ([CaseworkerRoleId]) REFERENCES [caseFlow].[CaseworkerRole] ([Id])
)
GO 
	CREATE UNIQUE NONCLUSTERED INDEX IX_Caseworker_Id ON caseFlow.Caseworker([Id])