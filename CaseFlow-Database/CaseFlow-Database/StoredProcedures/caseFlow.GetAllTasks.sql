CREATE PROCEDURE [caseFlow].[GetAllTasks]	
	@pageNumber			INT,
	@pageSize			INT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Imlement Latest Status temp table to only return the latest status 
	IF OBJECT_ID ('tempdb..#LatestStatus') IS NOT NULL DROP TABLE #LatestStatus

	CREATE TABLE #LatestStatus
	(
		TaskId		INT, 
		StatusId	INT, 
	    [Status]	NVARCHAR(256), 
		RowNo		INT
	)

	INSERT INTO #LatestStatus	
    SELECT
        ts.TaskId,
        ts.StatusId,
		s.[Title] AS 'Status',
        ROW_NUMBER() OVER (PARTITION BY TaskId ORDER BY ts.Id DESC) AS rn
    FROM
        [caseFlow].[TaskStatus] ts 
		LEFT JOIN [caseFlow].[Status] s ON s.Id = ts.StatusId

	-- Return count of records
	SELECT COUNT(*) AS 'TotalNoOfRecords' FROM [caseFlow].[Task]

	-- If No page size is given return all records
	IF @pageSize = -1
	BEGIN 
		SELECT		t.[Id] TaskId, t.[Title], t.[Description], ls.[Status],  t.[DueDateTime]	
		FROM		[caseFlow].[Task]		t		
		INNER JOIN	#LatestStatus			ls ON ls.TaskId =	t.Id
		WHERE		ls.RowNo = 1
		ORDER BY	t.[Id]
	END
	ELSE 
	BEGIN
		-- Calculate number of rows to skip
		DECLARE @offset	INT = (@pageNumber - 1) * @pageSize

		-- Return the paginated data of Tasks 
		SELECT		t.[Id] TaskId, t.[Title], t.[Description], ls.[Status],  t.[DueDateTime]	
		FROM		[caseFlow].[Task]		t		
		INNER JOIN	#LatestStatus			ls ON ls.TaskId =	t.Id
		WHERE		ls.RowNo = 1
		ORDER BY	t.[Id]
		OFFSET @offset ROWS
		FETCH NEXT @pageSize ROWS ONLY
	END

	SET NOCOUNT OFF;
END