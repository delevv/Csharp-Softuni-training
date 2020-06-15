--Problem 9.Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

EXEC dbo.usp_GetHoldersFullName

GO

--Problem 10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan @number DECIMAL(18, 4)
AS
BEGIN
	SELECT FirstName,
		   LastName	  
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @number
	ORDER BY  FirstName ASC,
			  LastName ASC
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 25000

GO

--Problem 11.Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue 
   (@sum DECIMAL(18, 4), 
	@yir FLOAT, 
	@yearsCount INT
   )
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @futureValue DECIMAL(18, 4)
	SET @futureValue = @sum * (POWER((1 + @yir), @yearsCount))

	RETURN @futureValue
END

GO

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)

--Problem 12.Calculating Interest
GO

CREATE PROC usp_CalculateFutureValueForAccount @accountID INT, @interestRate FLOAT
AS
BEGIN
	SELECT a.Id AS [Account Id],
		   FirstName AS [First Name],
		   LastName AS [Last Name],
		   Balance AS [Current Balance],
		   dbo.ufn_CalculateFutureValue(Balance, @interestRate, 5)
		   AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountID
END

GO

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1
