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

--Problem 19.Trigger
GO

--create trigger
CREATE OR ALTER TRIGGER trg_UsersShouldByItemsOnTheirLeverOrLower
ON UserGameItems INSTEAD OF INSERT
AS
BEGIN
	DECLARE @UserGameId INT = (SELECT TOP(1) i.UserGameId FROM inserted AS i)
	DECLARE @ItemId INT = (SELECT TOP(1) i.ItemId FROM inserted AS i)

	DECLARE @UserLevel INT = (SELECT ug.[Level] 
		                      FROM UsersGames AS ug
							  JOIN Games AS g ON ug.GameId = g.Id
							  WHERE ug.Id = @UserGameId AND g.[Name] = 'Bali'
							  )
	DECLARE @ItemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @ItemId )

	IF @UserLevel >= @ItemLevel
		BEGIN
		INSERT INTO UserGameItems(ItemId, UserGameId)
			VALUES (@ItemId, @UserGameId)
		END
END

--give cash to users
UPDATE UsersGames
SET Cash += 50000
FROM UsersGames AS ug
JOIN Games AS g ON ug.GameId = g.Id
JOIN Users AS u ON ug.UserId = u.Id
WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
	AND g.[Name] = 'Bali'

--buy items for users
DECLARE @FirstGroupCurrItemNum INT = 251
DECLARE @FirstGroupLastItemNum INT = 299

DECLARE @SecondGroupCurrItemNum INT = 501
DECLARE @SecondGroupLastItemNum INT = 539

WHILE 1 = 1
BEGIN
	IF @FirstGroupCurrItemNum <= @FirstGroupLastItemNum
		BEGIN
		BEGIN TRAN
			INSERT INTO UserGameItems(ItemId, UserGameId)
				SELECT @FirstGroupCurrItemNum,
					   ug.Id
				FROM UsersGames AS ug
				JOIN Games AS g ON ug.GameId = g.Id
				JOIN Users AS u ON ug.UserId = u.Id
				WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
				AND g.[Name] = 'Bali'

			UPDATE UsersGames
				SET Cash -= (SELECT Price FROM Items WHERE id = @FirstGroupCurrItemNum)
				FROM UsersGames AS ug
				JOIN Games AS g ON ug.GameId = g.Id
				JOIN Users AS u ON ug.UserId = u.Id
				WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
					AND g.[Name] = 'Bali'
        COMMIT
		END

	IF @SecondGroupCurrItemNum <= @SecondGroupCurrItemNum
		BEGIN
		BEGIN TRAN
			INSERT INTO UserGameItems(ItemId, UserGameId)
				SELECT @SecondGroupCurrItemNum,
					   ug.Id
				FROM UsersGames AS ug
				JOIN Games AS g ON ug.GameId = g.Id
				JOIN Users AS u ON ug.Id = u.Id
				WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
				AND g.[Name] = 'Bali'

			UPDATE UsersGames
				SET Cash -= (SELECT Price FROM Items WHERE id = @SecondGroupCurrItemNum)
				FROM UsersGames AS ug
				JOIN Games AS g ON ug.GameId = g.Id
				JOIN Users AS u ON ug.Id = u.Id
				WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
					AND g.[Name] = 'Bali'
		COMMIT
		END

		IF @FirstGroupCurrItemNum >= @FirstGroupLastItemNum
		AND @SecondGroupCurrItemNum >= @SecondGroupLastItemNum
		BEGIN
			BREAK;
		END

		SET @FirstGroupCurrItemNum += 1
		SET @SecondGroupCurrItemNum += 1
END

--Display results
SELECT u.Username,
	   g.[Name],
	   ug.Cash,
	   i.[Name]
FROM UsersGames AS ug
JOIN Users AS u ON ug.UserId = u.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
RIGHT JOIN Items AS i ON ugi.ItemId = i.Id
LEFT JOIN Games AS g ON ug.GameId = g.Id
WHERE g.[Name] = 'Bali'
ORDER BY u.Username ASC,
		 i.[Name] ASC

GO

--Problem 20.*Massive Shopping
CREATE PROC usp_BuyItemsFromLevelToLevel @username VARCHAR(50), 
									     @gameName VARCHAR(50), 
										 @startItemsLevel INT , 
										 @endItemsLevel INT 
AS
BEGIN

	DECLARE @userGameId INT = (SELECT ug.Id
							   FROM UsersGames AS ug
							   JOIN Users AS u ON ug.UserId = u.Id
							   JOIN Games AS g ON ug.GameId = g.Id
							   WHERE u.Username = @username AND g.Name = @gameName
							  )
	
	DECLARE @userGameLevel INT = (SELECT [Level]
	                              FROM UsersGames
	                              WHERE Id = @userGameId
								 )

	DECLARE @money MONEY = (SELECT Cash
						    FROM UsersGames
						    WHERE Id = @userGameId
						   )
	DECLARE @itemsValue MONEY = (SELECT SUM(Price)
								 FROM Items
								 WHERE MinLevel BETWEEN @startItemsLevel AND @endItemsLevel
								)
	
	IF @money >= @itemsValue AND @userGameLevel >= @endItemsLevel
	
	  BEGIN
	    BEGIN TRANSACTION
	    
		UPDATE UsersGames
	    SET Cash -= @itemsValue
	    WHERE Id = @userGameId
	    
		IF (@@ROWCOUNT != 1)
	      BEGIN
	        ROLLBACK
	        RAISERROR ('Could not make payment', 16, 1)
	      END
	    ELSE
	      BEGIN
	        INSERT INTO UserGameItems (ItemId, UserGameId)
	          (SELECT Id, @userGameId
	           FROM Items
	           WHERE MinLevel BETWEEN @startItemsLevel AND @endItemsLevel
			  )
	
	        IF (SELECT COUNT(*) FROM Items
	            WHERE MinLevel BETWEEN @startItemsLevel AND @endItemsLevel
			   ) != @@ROWCOUNT
	          BEGIN
	            ROLLBACK;
	            RAISERROR ('Could not buy items', 16, 1)
	          END
	        ELSE COMMIT;
	      END
	  END
END

EXEC dbo.usp_BuyItemsFromLevelToLevel 'Stamat', 'Safflower', 11, 12
EXEC dbo.usp_BuyItemsFromLevelToLevel 'Stamat', 'Safflower', 19, 21

SELECT i.Name AS [Item Name]
FROM UserGameItems AS ugi
JOIN Items AS i ON i.Id = ugi.ItemId
JOIN UsersGames AS ug ON ug.Id = ugi.UserGameId
JOIN Games AS g ON g.Id = ug.GameId
WHERE g.Name = 'Safflower'
ORDER BY [Item Name]
