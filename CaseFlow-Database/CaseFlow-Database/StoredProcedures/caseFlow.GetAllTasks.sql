CREATE PROCEDURE [caseFlow].[GetAllTasks]	
	@pageNumber			INT,
	@pageSize			INT
AS
BEGIN
	SET NOCOUNT ON;
	
	-- Return count of records
	SELECT COUNT(*) AS 'TotalNoOfRecords' FROM [caseFlow].[Task]

	-- If No page size is given return all records
	IF @pageSize = -1
	BEGIN 
		SELECT [Id], [Title], [Description], [DueDateTime]	
		FROM [caseFlow].[Task]
		ORDER BY [Id]
	END
	ELSE 
	BEGIN
		-- Calculate number of rows to skip
		DECLARE @offset	INT = (@pageNumber - 1) * @pageSize

		-- Return the paginated data of Tasks 
		SELECT [Id], [Title], [Description], [DueDateTime]	
		FROM [caseFlow].[Task]
		ORDER BY [Id]
		OFFSET @offset ROWS
		FETCH NEXT @pageSize ROWS ONLY
	END

	SET NOCOUNT OFF;
END