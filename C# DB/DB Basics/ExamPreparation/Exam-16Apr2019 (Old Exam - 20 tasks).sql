CREATE DATABASE Airport

USE Airport

--1.Database Design
CREATE TABLE Planes(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	Range INT NOT NULL
)

CREATE TABLE Flights(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME2,
	ArrivalTime DATETIME2,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT NOT NULL REFERENCES Planes(Id)
)

CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes(
	Id INT PRIMARY KEY IDENTITY,
	Type VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT NOT NULL REFERENCES LuggageTypes(Id),
	PassengerId INT NOT NULL REFERENCES Passengers(Id)
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT NOT NULL REFERENCES Passengers(Id),
	FlightId INT NOT NULL REFERENCES Flights(Id),
	LuggageId INT NOT NULL REFERENCES Luggages(Id),
	Price DECIMAL(18,2) NOT NULL
)

--2.Insert
INSERT INTO Planes([Name], Seats, [Range])
	VALUES ('Airbus 336', 112, 5132),
	       ('Airbus 330', 432, 5325),
		   ('Boeing 369', 231, 2355),
		   ('Stelt 297', 254, 2143),
		   ('Boeing 338', 165, 5111),
		   ('Airbus 558', 387, 1342),
		   ('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes(Type)
	VALUES ('Crossbody Bag'),
		   ('School Backpack'),
		   ('Shoulder Bag')

--3.Update
UPDATE Tickets
SET Price *= 1.13 
FROM Tickets AS t
JOIN Flights AS f ON t.FlightId = f.Id
WHERE f.Destination = 'Carlsbad'

--4.Delete
DELETE FROM Tickets
WHERE FlightId IN (SELECT Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--5.Trips
SELECT Origin, Destination
FROM Flights
ORDER BY Origin, Destination

--6.The "Tr" Planes
SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

--7.Flight Profits
SELECT FlightId,
	   SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC, FlightId

--8.Passengers and Prices
SELECT TOP(10) FirstName,
			   LastName,
			   Price
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
ORDER BY t.Price DESC, FirstName, LastName

--9.Most Used Luggage's
SELECT lt.[Type],
	   COUNT(*) AS MostUsedLuggage
FROM Luggages AS l
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
GROUP BY lt.[Type]
ORDER BY MostUsedLuggage DESC, lt.[Type]

--10.Passenger Trips
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
       f.Origin,
	   f.Destination
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY [Full Name], Origin, Destination

--11.Non Adventures People
SELECT FirstName,
       LastName,
	   Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.Id IS NULL
ORDER BY Age DESC,
         FirstName,
		 LastName

--12.Lost Luggage's
SELECT p.PassportId,
       p.[Address]
FROM Passengers AS p
LEFT JOIN Luggages AS l ON p.Id = l.PassengerId
WHERE l.Id IS NULL
ORDER BY p.PassportId, p.[Address]

--13.Count of Trips
SELECT p.FirstName,
       p.LastName,
	   COUNT(t.Id)  AS [Total Trips]
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
GROUP BY p.FirstName, p.LastName
ORDER BY [Total Trips] DESC,
		 FirstName,
		 LastName

--14.Full Info
SELECT CONCAT(p.FirstName,' ',p.LastName) AS [Full Name],
       pl.[Name] AS [Plane Name],
	   CONCAT(f.Origin,' - ',f.Destination) AS Trip,
	   lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name],
	     pl.[Name],
		 f.Origin,
		 f.Destination,
		 [Luggage Type]

--15.Most Expensive Trips
SELECT FirstName,
	   LastName,
	   Destination,
	   Price
FROM (SELECT p.FirstName,
             p.LastName,
      	     f.Destination,
      	     t.Price,
      	     DENSE_RANK() OVER (PARTITION BY p.Id ORDER BY t.Price DESC) AS PriceRank
      FROM Passengers AS p
      JOIN Tickets AS t ON p.Id = t.PassengerId
      JOIN Flights AS f ON t.FlightId = f.Id
     ) AS PassengersWithRankedTicketsByPrice
WHERE PriceRank = 1
ORDER BY Price DESC,
         FirstName,
		 LastName,
		 Destination

--16.Destinations Info
SELECT Destination,
	   COUNT(t.Id) AS FilesCount
FROM Flights AS f
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY Destination
ORDER BY FilesCount DESC,
         Destination

--17.PSP
SELECT p.[Name],
       p.Seats,
	   COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY p.[Name], p.Seats
ORDER BY [Passengers Count] DESC,
	     p.[Name],
		 p.Seats

--18.Vacation
GO

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(30)
AS
BEGIN
    DECLARE @flightId INT = (
	                         SELECT TOP(1) Id FROM Flights 
	                         WHERE Origin = @origin AND Destination = @destination
			                )
	
	IF @flightId IS NULL
		BEGIN
			RETURN'Invalid flight!'
		END
	
	IF @peopleCount <= 0
		BEGIN
			RETURN'Invalid people count!'
		END

	DECLARE @pricePerTicket DECIMAL(18, 2) = (
	                                          SELECT SUM(Price)
		                                      FROM Tickets
		                                      WHERE FlightId = @flightId
		                                      GROUP BY FlightId
		                                     )

	RETURN CONCAT('Total price ', @pricePerTicket * @peopleCount)
END

GO

--19.Wrong Data
GO

CREATE PROC usp_CancelFlights
AS
BEGIN
	UPDATE Flights
	SET DepartureTime = NULL, ArrivalTime = NULL
	WHERE ArrivalTime > DepartureTime
END

GO

--20.Deleted Planes
CREATE TABLE DeletedPlanes(
	Id INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

GO

CREATE TRIGGER trg_SaveOnPlaneDelete
ON Planes AFTER DELETE
AS
BEGIN
	INSERT INTO DeletedPlanes
		SELECT Id,
		       [Name],
			   Seats,
			   [Range]
		FROM deleted
END

GO