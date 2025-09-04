CREATE TABLE [caseFlow].[TaskStatus]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[TaskId] INT NOT NULL,
	[StatusId] INT NOT NULL,
	[CaseworkerId] INT NOT NULL,
	[Notes] NVARCHAR(256) NULL, 
    CONSTRAINT PK_TaskStatus PRIMARY KEY ([Id]),
	CONSTRAINT FK_TaskStatus_Task FOREIGN KEY ([TaskId]) REFERENCES [caseFlow].[Task] ([Id]),
	CONSTRAINT FK_TaskStatus_Status FOREIGN KEY ([StatusId]) REFERENCES [caseFlow].[Status] ([Id]),
	CONSTRAINT FK_TaskStatus_Caseworker FOREIGN KEY ([CaseworkerId]) REFERENCES [caseFlow].[Caseworker] ([Id])
)

GO
	CREATE UNIQUE NONCLUSTERED INDEX IX_TaskStatus_Id ON caseFlow.TaskStatus ([Id])