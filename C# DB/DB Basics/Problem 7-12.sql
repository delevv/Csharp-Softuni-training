--Problem 7.Create Table People
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) 
	CHECK(DATALENGTH(Picture) <= 2000 * 1024),
    Height NUMERIC(3,2),
	[Weight] NUMERIC(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography TEXT)

INSERT INTO People([Name],Height,[Weight],Gender,Birthdate,Biography)
	VALUES
		('Pesho1',1.50,80,'m','05.01.1999','This is some Biography'),
		('Maria1',1.80,59,'f','02.12.1990','This is some Biography'),
		('Pesho2',1.90,45.30,'m','05.21.2020','This is some Biography'),
		('Maria2',1.65,65,'f','05.21.2020','This is some Biography'),
		('Pesho3',1.70,45.30,'m','05.21.2020','This is some Biography')

--Problem 8.Create Table Users
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDeleted BIT NOT NULL)

INSERT INTO Users(Username,[Password],LastLoginTime,IsDeleted)
	VALUES
		('Pesho1',123456,'05.21.2020',0),
		('Pesho2',123456,'05.21.2020',1),
		('Pesho3',123456,'05.21.2020',0),
		('Pesho4',123456,'05.21.2020',1),
		('Pesho5',123456,'05.21.2020',0)

--Problem 9.Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07C3652794

ALTER TABLE USERS
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id,Username)

--Problem 10.Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)

--Problem 11.Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

--Problem 12.Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)