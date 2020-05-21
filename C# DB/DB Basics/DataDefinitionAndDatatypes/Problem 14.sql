--Problem 14.Car Rental Database
CREATE DATABASE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50) NOT NULL,
	DailyRate INT ,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT)

INSERT INTO Categories(CategoryName)
	VALUES
		('Family'),
		('Sport'),
		('Electric')

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufaturer VARCHAR(50) NOT NULL,
	Model Varchar(50) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors TINYINT NOT NULL,
	Picture VARBINARY,
	Condition BIT NOT NULL,
	Available BIT NOT NULL)

INSERT INTO Cars(PlateNumber,Manufaturer,Model,CarYear,CategoryId,Doors,Condition,Available)
	VALUES
		('XXXXXXX1','Mercedes','C220',2012,1,4,1,1),
		('XXXXXXX2','BMW','E60',2016,1,4,1,1),
		('XXXXXXX3','Fiat','Multipla',2015,1,4,1,1)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(30) NOT NULL,
	Notes TEXT)

INSERT INTO Employees(FirstName,LastName,Title)
	VALUES
		('E1','EE1','Dealer'),
		('E2','EE2','Manager'),
		('E3','EE3','Cleaner')

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber INT NOT NULL,
	FullName NVARCHAR(60) NOT NULL,
	Address NVARCHAR(50),
	City NVARCHAR(50),
	ZIPCode INT,
	Notes TEXT)

INSERT INTO Customers(DriverLicenceNumber,FullName,[Address],City,ZIPCode)
	VALUES
		(111,'Name1','asdas','asdasd',8000),
		(222,'Name2','asdas','asdasd',8000),
		(333,'Name3',NULL,NULL,NULL)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage int NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied INT NOT NULL,
	TaxRate INT NOT NULL,
	OrderStatus BIT NOT NULL,
	Notes TEXT)

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus)
	VALUES
		(1,1,1,99,123,200,77,'05.20.2020','05.22.2020',2,0,0,1),
		(1,1,1,99,123,200,77,'05.20.2020','05.22.2020',2,0,0,1),
		(1,1,1,99,123,200,77,'05.20.2020','05.22.2020',2,0,0,1)