CREATE TABLE [caseFlow].[CaseWorkerRole]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(256) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	CONSTRAINT PK_CaseWorkerRole  PRIMARY KEY ([Id])
)
GO 

	CREATE UNIQUE NONCLUSTERED INDEX IX_CaseWorkerRole_Id on caseFlow.CaseWorkerRole([Id])