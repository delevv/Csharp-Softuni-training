CREATE DATABASE Bitbucket

USE Bitbucket

--1.Database Design
CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT FOREIGN KEY REFERENCES Users(Id),
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2)	NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)

--2.Insert
INSERT INTO Files([Name], Size, ParentId, CommitId)
	VALUES	('Trade.idk', 2598.0, 1, 1),
			('menu.net', 9238.31, 2, 2),
			('Administrate.soshy', 1246.93, 3, 3),
			('Controller.php', 7353.15, 4, 4),
			('Find.java', 9957.86, 5, 5),
			('Controller.json', 14034.87, 3, 6),
			('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
	VALUES	('Critical Problem with HomeController.cs file', 'open', 1, 4),
			('Typo fix in Judge.html', 'open', 4, 3),	
			('Implement documentation for UsersService.cs', 'closed', 8, 2),
			('Unreachable code in Index.cs', 'open', 9, 8)

--3.Update
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--4.Delete
DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

--5.Commits
SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

--6.Heavy HTML
SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

--7.Issues and Users
SELECT i.Id,
	   CONCAT(u.Username,' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee

--8.Non-Directory Files
SELECT Id,
	   [Name],
	   CONCAT(Size,'KB') AS Size
FROM Files
WHERE Id NOT IN (SELECT DISTINCT ParentId FROM Files WHERE ParentId IS NOT NULL)
ORDER BY Id, [Name], Size DESC

--9.Most Contributed Repositories
SELECT TOP(5) r.Id, 
			  r.[Name], 
			  COUNT(c.RepositoryId) AS Commits
FROM Repositories AS r
JOIN Commits AS c ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY Commits DESC, r.Id, r.[Name]

--10.User and Files
SELECT u.Username,
	   AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON c.Id = f.CommitId
GROUP BY u.Username
ORDER BY Size DESC, u.Username

--11.User Total Commits
GO

CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(50)) 
RETURNS INT
AS
BEGIN
	RETURN (SELECT COUNT(*)
		   FROM Users AS u
		   JOIN Commits AS c On u.Id = c.ContributorId
		   WHERE u.Username = @username)
END

GO

--12.Find by Extensions
CREATE PROC usp_FindByExtension @extension VARCHAR(10)
AS
BEGIN
	SELECT Id,
		   [Name],
		   CONCAT(Size,'KB') AS Size
	FROM Files
	WHERE [Name] LIKE '%.' + @extension
	ORDER BY Id, [Name], Size DESC
END