--Problem 1.Employees with Salary Above 35000
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000
END

EXECUTE dbo.usp_GetEmployeesSalaryAbove35000

GO

--Problem 2. Employees with Salary Above Number
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @number DECIMAL(18,4)
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @number
END

EXECUTE dbo.usp_GetEmployeesSalaryAboveNumber 48100

GO

--Problem 3.Town Names Starting With
GO

CREATE PROCEDURE usp_GetTownsStartingWith @string NVARCHAR(MAX)
AS
BEGIN
	SELECT [Name] AS Town FROM Towns
	WHERE [Name] LIKE @string + '%'
END

EXECUTE dbo.usp_GetTownsStartingWith 'b'

GO

--Problem 4.Employees from Town
GO

CREATE PROCEDURE usp_GetEmployeesFromTown @townName NVARCHAR(50)
AS
BEGIN
	SELECT FirstName,
		   LastName
	FROM Employees AS e
	INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
	INNER JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
END

EXECUTE dbo.usp_GetEmployeesFromTown 'Sofia'

GO

--Problem 5.Salary Level Function
GO

CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18, 4))
RETURNS VARCHAR(7)
BEGIN
	IF @salary < 30000 RETURN 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000 RETURN 'Average'
	ELSE IF @salary > 50000 RETURN 'High'

	RETURN Null 
END

GO

SELECT Salary,
	   dbo.ufn_GetSalaryLevel (Salary)
FROM Employees

--Problem 6. Employees by Salary Level
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel @salaryLevel VARCHAR(7)
AS
BEGIN
	SELECT FirstName, LastName FROM Employees
	WHERE dbo.ufn_GetSalaryLevel (Salary) = @salaryLevel
END

EXECUTE dbo.usp_EmployeesBySalaryLevel 'High'

GO

--Problem 7. Define Function
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
BEGIN
	DECLARE @counter INT = 1
	DECLARE @isWordComprised BIT = 1

	WHILE @counter <= LEN(@word)
		BEGIN
			DECLARE @currLetter CHAR(1) = SUBSTRING(@word, @counter, 1)
			DECLARE @currLetterIndex INT = CHARINDEX(@currLetter, @setOfLetters , 1)

			IF @currLetterIndex = 0
				BEGIN 
					SET @isWordComprised = 0
					BREAK
				END

			SET @counter += 1
		END 
     
	 RETURN @isWordComprised
END

GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

--Problem 8.*Delete Employees and Departments
GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN
	
	--Delete employees from EmployeesProjects
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
	                     SELECT EmployeeID FROM Employees
	                     WHERE DepartmentID = @departmentId
						)
		                
	--Set ManagerId to NULL in Employees
	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
	                     SELECT EmployeeID FROM Employees
	                     WHERE DepartmentID = @departmentId
						)

	--Alter column ManagerID in Departments
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	--Set ManagerId to NULL in Departments
	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
	                     SELECT EmployeeID FROM Employees
	                     WHERE DepartmentID = @departmentId
						)

   --Delete all employees from current department
   DELETE FROM Employees
   WHERE DepartmentID = @departmentId

   --Delete current department
   DELETE FROM Departments
   WHERE DepartmentID = @departmentId

   --Return 0 count if DELETE was succesfull
   SELECT COUNT(*) FROM Employees
   WHERE DepartmentID = @departmentId

END

EXECUTE dbo.usp_DeleteEmployeesFromDepartment 1

GO