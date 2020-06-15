CREATE DATABASE Service

USE Service

--1.Table design

CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME2,
	Age INT NOT NULL CHECK(Age BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME2,
	Age INT CHECK(Age BETWEEN 18 AND 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE [Status](
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
	OpenDate DATETIME2 NOT NULL,
	CloseDate DATETIME2,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2.Insert
INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
	VALUES 
			('Marlo', 'O''Malley', '09-21-1958', 1),
			('Niki', 'Stanaghan', '11-26-1969',	4),
			('Ayrton', 'Senna',	'03-21-1960', 9),
			('Ronnie', 'Peterson', '02-14-1944', 9),
			('Giovanna', 'Amati', '07-20-1959', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
	VALUES
			(1, 1, '04-13-2017', NULL, 'Stuck Road on Str.133', 6, 2),
			(6, 3, '09-05-2015', '12-06-2015', 'Charity trail running', 3, 5),
			(14, 2, '09-07-2015', NULL, 'Falling bricks on Str.58', 5, 2),
			(4, 3, '07-03-2017', '07-06-2017', 'Cut off streetlight on Str.11', 1, 1)
		   
--3.Update
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4.Delete
DELETE FROM Reports
WHERE StatusId = 4

--5.Unassigned Reports
SELECT [Description],
	   FORMAT(OpenDate,'dd-MM-yyyy')
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

--6.Reports & Categories
SELECT r.[Description],
	   c.[Name]
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE c.Name IS NOT NULL
ORDER BY r.[Description] ASC, c.[Name] ASC

--7.Most Reported Category
SELECT TOP(5) c.[Name],
	          COUNT(*) AS ReportsNumber
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name] ASC

--8.Birthday Report
SELECT u.Username,
	   c.[Name] AS CategoryName
FROM Reports AS r
JOIN Users AS u 
ON r.UserId = u.Id
JOIN Categories AS c
ON r.CategoryId = c.Id
WHERE DATEPART(day, u.Birthdate) = DATEPART(day,  r.OpenDate)
	AND DATEPART(month, u.Birthdate) = DATEPART(month,  r.OpenDate)
ORDER BY u.Username ASC, c.[Name] ASC

--9.Users per Employee 
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	   COUNT(DISTINCT r.UserId) AS UsersCount	
FROM Employees AS e
LEFT JOIN Reports AS r
ON e.Id = r.EmployeeId
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName ASC

--10.Full Info
SELECT CASE
			WHEN r.EmployeeId IS NULL THEN 'None'
			WHEN e.FirstName IS NULL THEN 'None'
			WHEN e.LastName IS NULL THEN 'None'
			ELSE CONCAT(e.FirstName, ' ', e.LastName) 
	   END AS Employee,
	   ISNULL(d.[Name], 'None') AS Department,
	   c.[Name] AS Category,
	   r.[Description],
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.[Label] AS [Status],
	   u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
ORDER BY e.FirstName DESC,
		 e.LastName DESC,
		 d.[Name] ASC,
		 c.[Name] ASC,
		 r.[Description] ASC,
		 r.OpenDate ASC,
		 s.Id ASC,
		 u.Id ASC

--11.Hours to Complete
GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	
	IF @StartDate IS NULL OR @EndDate IS NULL
		SET @result = 0
	ELSE
		SET @result = DATEDIFF(HOUR, @StartDate, @EndDate)

	RETURN @result
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

--12.Assign Employee
GO

CREATE PROC usp_AssignEmployeeToReport @EmployeeId INT, @ReportId INT
AS
BEGIN
	DECLARE @isDepartmentSame BIT = (SELECT CASE
									 			WHEN e.DepartmentId != c.DepartmentId THEN 0
									 			ELSE 1
									 	    END AS DepartmentEqual
									 FROM Reports AS r
									 JOIN Employees AS e ON e.Id = @EmployeeId
									 JOIN Categories AS c ON r.CategoryId = c.Id
									 WHERE r.Id = @ReportId
									)
	IF @isDepartmentSame = 1
		BEGIN
			UPDATE Reports
			SET EmployeeId = @EmployeeId
			WHERE Id = @ReportId
		END
	ELSE 
		BEGIN
			SELECT 'Employee doesn''t belong to the appropriate department!' AS Response
		END
END

GO

EXEC usp_AssignEmployeeToReport 17, 2
EXEC usp_AssignEmployeeToReport 30, 1
