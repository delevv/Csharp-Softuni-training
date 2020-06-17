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

--Problem 14.Create Table Logs
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO

CREATE TRIGGER trg_CreateLogWhenUpdateOnAccounts
ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	    SELECT i.Id, d.Balance, i.Balance
		FROM inserted AS i
		JOIN deleted AS d ON i.Id = d.Id
END

GO

--Problem 15.Create Table Emails
CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL REFERENCES Accounts(Id),
	[Subject] VARCHAR(50) NOT NULL,
	Body VARCHAR(100) NOT NULL
)

GO

CREATE TRIGGER trg_CreateEmailWhenInsertInLogs
ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	    SELECT i.AccountId,
			   CONCAT('Balance change for account: ', i.AccountId),
			   CONCAT('On ',FORMAT(GETDATE(), 'MMM dd yyyy HH:mmtt'),' your balance was changed from ',i.OldSum,' to ',i.NewSum,'.')
		FROM inserted AS i
END

GO

--Problem 16.Deposit Money
GO

CREATE PROC usp_DepositMoney @AccountId INT, @MoneyAmount MONEY
AS
BEGIN
	IF (SELECT COUNT(*) FROM Accounts WHERE Id = @AccountId) > 0
	AND @MoneyAmount > 0
		BEGIN
			UPDATE Accounts
			SET Balance += @MoneyAmount
			WHERE Id = @AccountId
		END 
END

GO

--Problem 17.Withdraw Money
GO

CREATE PROC usp_WithdrawMoney @AccountId INT, @MoneyAmount MONEY
AS
BEGIN
	IF (SELECT COUNT(*) FROM Accounts WHERE Id = @AccountId) > 0
	AND @MoneyAmount > 0
		BEGIN
			UPDATE Accounts
			SET Balance -= @MoneyAmount
			WHERE Id = @AccountId
		END 
END

GO

--Problem 18.Money Transfer
GO

CREATE PROC usp_TransferMoney @SenderId INT, @ReceiverId INT, @Amount MONEY
AS
BEGIN
	EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
	EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
END

GO