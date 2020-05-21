--Problem 13.Movies Database
CREATE DATABASE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes TEXT)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes TEXT)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes TEXT)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId  INT NOT NULL,
	CopyrightYear INT,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes TEXT)

INSERT INTO Directors(DirectorName)
	VALUES
		('Pesho Petrov'),
		('Ivan Ivanov'),
		('Mladen Mladeno'),
		('Asen Asenov'),
		('Danail Danailov')

INSERT INTO Genres(GenreName)
	VALUES
		('Action'),
		('Horor'),
		('Drama'),
		('Asian'),
		('Comedy')

INSERT INTO Categories(CategoryName,Notes)
	VALUES
		('Family Movies','This is note'),
		('Funny Movies',NULL),
		('Drama Movies','This is note'),
		('Romantic Movies',NULL),
		('Fantasy Movies','This is note')

INSERT INTO Movies(Title,DirectorId,CopyrightYear,[Length],GenreId,CategoryId,Rating,Notes)
	VALUES
		('SomeMovie1',1,2000,120,1,1,10,NULL),
		('SomeMovie2',2,2000,120,2,2,10,NULL),
		('SomeMovie3',3,2000,120,3,3,10,NULL),
		('SomeMovie4',4,2000,120,4,4,10,NULL),
		('SomeMovie5',5,2000,120,5,5,10,'This is note')