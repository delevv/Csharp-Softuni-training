--Problem 13.*Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT SUM(Cash) AS [SumCash]
	   FROM (
	   	  SELECT g.[Name],
	         	 ug.Cash,
	         	 ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS RowNumber
	       FROM Games AS g
	       JOIN UsersGames AS ug ON g.Id = ug.GameId
	       WHERE g.[Name] = @gameName
	   	 ) AS RowNumQuery
	   WHERE RowNUmber % 2 != 0

GO

SELECT * FROM ufn_CashInUsersGames('Love in a mist')
