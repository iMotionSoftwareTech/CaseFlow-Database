CREATE TABLE [caseFlow].[TaskStatus]
(
	[TaskId] INT NOT NULL,
	[StatusId] INT NOT NULL,
	[CaseworkerId] INT NOT NULL,
	CONSTRAINT PK_TaskStatus PRIMARY KEY ([TaskId]),
	CONSTRAINT FK_TaskStatus_Task FOREIGN KEY ([TaskId]) REFERENCES [caseFlow].[Task] ([Id]),
	CONSTRAINT FK_TaskStatus_Status FOREIGN KEY ([StatusId]) REFERENCES [caseFlow].[Status] ([Id]),
	CONSTRAINT FK_TaskStatus_Caseworker FOREIGN KEY ([CaseworkerId]) REFERENCES [caseFlow].[Caseworker] ([Id])
)
