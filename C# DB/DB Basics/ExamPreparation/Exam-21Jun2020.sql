CREATE DATABASE TripService

USE TripService

--1.Database design
CREATE TABLE Cities(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL (18, 2)
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL REFERENCES Hotels(Id)
)

CREATE TABLE Trips(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK(BookDate < ArrivalDate),
	CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips(
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	TripId INT NOT NULL REFERENCES Trips(Id),
	Luggage INT NOT NULL,
	PRIMARY KEY(AccountId, TripId),
	CHECK(Luggage >= 0)
)

--2.Insert
INSERT INTO Accounts(FirstName, MiddleName, LastName, CityId, BirthDate, Email)
	VALUES ('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
		   ('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
		   ('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
		   ('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips(RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
	VALUES (101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	       (102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
		   (103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
		   (104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
		   (109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--3.Update
UPDATE Rooms 
SET Price *= 1.14
WHERE HotelId IN (5, 7 ,9)

--4.Delete
DELETE
FROM AccountsTrips
WHERE AccountId = 47

--5.EEE-Mails
SELECT a.FirstName,
	   a.LastName,
	   FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate,
	   c.Name,
	   a.Email
FROM Accounts AS a
JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.Name

--6.City Statistics
SELECT c.Name AS City,
       COUNT(*) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY Hotels DESC,
		 c.Name

--7.Longest and Shortest Trips
SELECT Id,
	   FullName,
	   MAX(Days) AS LongestTrip,
	   MIN(Days) AS ShortesTrip
FROM (
        SELECT DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS [Days],
        	   a.Id,
        	   CONCAT(a.FirstName, ' ', a.LastName) AS FullName
        FROM Accounts AS a
        JOIN AccountsTrips AS at ON a.Id = at.AccountId
        JOIN Trips AS t on at.TripId = t.Id
        WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
     ) AS AccountAndTripsInDays
GROUP BY Id, FullName
ORDER BY LongestTrip DESC,
		 ShortesTrip

--8.Metropolis
SELECT TOP(10) c.Id,
               c.Name AS City,
	           c.CountryCode AS Country,
	           COUNT(*) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

--9.Romantic Getaways
SELECT a.Id,
       a.Email,
	   c.Name AS City,
	   COUNT(*) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS c ON h.CityId = c.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC,
		 a.Id

--10.GDPR Violation
SELECT t.Id,
       CASE	
			WHEN a.MiddleName IS NULL THEN CONCAT(a.FirstName, ' ', a.LastName)
			ELSE CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName)
	   END AS [Full Name],
	   ac.[Name] AS [From],
	   hc.[Name] AS [To],
	   CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CAST(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) AS VARCHAR(10)) + ' days'
	   END AS Duration
FROM AccountsTrips AS at
JOIN Accounts AS a ON at.AccountId = a.Id
JOIN Cities AS ac ON a.CityId = ac.Id
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON r.HotelId = h.Id
JOIN Cities AS hc ON h.CityId = hc.Id
ORDER BY [Full Name], t.Id

--11.Available Room
GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @result VARCHAR(MAX)

	IF EXISTS (
	           SELECT * 
               FROM Rooms AS r
               JOIN Trips AS t ON r.Id = t.RoomId
               WHERE r.Id NOT IN (
                                  SELECT r.Id FROM Rooms AS r
                                  JOIN Trips AS t ON r.Id = t.RoomId
                                  WHERE @Date BETWEEN t.ArrivalDate AND t.ReturnDate
                                 )
               AND (t.CancelDate IS NULL)
               AND (r.Beds >= @People) 
               AND (r.HotelId = @HotelId) 
			  )
		BEGIN
		    DECLARE @RoomNumber INT = (SELECT TOP(1) r.Id 
                                       FROM Rooms AS r
                                       JOIN Trips AS t ON r.Id = t.RoomId
                                       WHERE r.Id NOT IN (
                                                          SELECT r.Id FROM Rooms AS r
                                                          JOIN Trips AS t ON r.Id = t.RoomId
                                                          WHERE @Date BETWEEN t.ArrivalDate AND t.ReturnDate
                                                         )
                                       AND (t.CancelDate IS NULL)
                                       AND (r.Beds >= @People) 
                                       AND (r.HotelId = @HotelId)
                                       ORDER BY r.Price DESC
			                          )

		   DECLARE @RoomBeds INT = (SELECT TOP(1) Beds FROM Rooms WHERE Id = @RoomNumber)

		   DECLARE @RoomType VARCHAR(MAX) = (SELECT TOP(1) [Type] FROM Rooms WHERE Id = @RoomNumber)

		   DECLARE @RoomPrice DECIMAL(18, 2) = (SELECT TOP(1) Price FROM Rooms WHERE Id = @RoomNumber)

		   DECLARE @HotelBaseRate DECIMAL(18, 2) = (SELECT TOP(1) BaseRate FROM Hotels WHERE Id = @HotelId)

		   DECLARE @TotalPrice DECIMAL(18, 2) = (@HotelBaseRate + @RoomPrice) * @People

			SET @result = CONCAT('Room ', @RoomNumber, ': ', @RoomType, ' (', @RoomBeds, ' beds',')',' - ','$', @TotalPrice)			
		END
	
	ELSE
		BEGIN
			SET @result = 'No rooms available'
		END

		RETURN @result
END

GO

--12.Switch Room
GO

CREATE PROC usp_SwitchRoom @TripId INT, @TargetRoomId INT
AS
BEGIN
	DECLARE	@CurrentRoom INT = (SELECT TOP(1) RoomId FROM Trips WHERE Id = @TripId)

	IF (SELECT TOP(1) HotelId FROM Rooms WHERE Id = @CurrentRoom) !=
	   (SELECT TOP(1) HotelId FROM Rooms WHERE Id = @TargetRoomId)
		BEGIN
			THROW 51000, 'Target room is in another hotel!', 1
		END
	
	IF (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId) <
	   (
	    SELECT COUNT(*) AS AccountsOnTrip
	    FROM Trips AS t
	    JOIN AccountsTrips AS at ON t.Id = at.TripId
		WHERE t.Id = @TripId
		GROUP BY t.Id
	   )
	   BEGIN
			THROW 51001, 'Not enough beds in target room!', 1
	   END

	   UPDATE Trips
	   SET RoomId = @TargetRoomId
	   WHERE Id = @TripId
END

GO