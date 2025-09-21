CREATE TYPE [caseFlow].[TaskUpdateList] AS TABLE
(
	TaskId			INT                 NOT NULL,
    StatusId		INT                 NOT NULL,
    Notes			NVARCHAR(256)       NULL,    
	[LogDateTime]	DATETIME2			NOT NULL
)