--Problem 1.Employee Address
SELECT TOP(5) e.EmployeeID,
			  e.JobTitle,
			  a.AddressID,
			  a.AddressText
FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

--Problem 2.Addresses with Towns
SELECT TOP(50) e.FirstName,
			   e.LastName,
			   t.[Name] AS Town,
			   a.AddressText 
FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName ASC

--Problem 3.Sales Employee
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   d.[Name] AS DepartmentName
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID ASC

--Problem 4.Employee Departments
SELECT TOP(5) e.EmployeeID,
			  e.FirstName,
	          e.Salary,
	          d.[Name] AS DepartmentName
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID ASC

--Problem 5.Employees Without Project
SELECT TOP(3) e.EmployeeID, 
			  e.FirstName 
FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID ASC

--Problem 6.Employees Hired After
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS DeptName
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01.01.1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

--Problem 7.Employees with Project
SELECT TOP(5) e.EmployeeID,
	          e.FirstName,
	          p.[Name] AS ProjectName
FROM EmployeesProjects AS ep
INNER JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08.13.2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID ASC

--Problem 8.Employee 24
SELECT e.EmployeeID,
	   e.FirstName,
	   CASE
			WHEN YEAR(p.StartDate) >= 2005 THEN NULL
			ELSE p.[Name]
	   END AS ProjectName
FROM EmployeesProjects AS ep
INNER JOIN Employees AS e ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
ORDER BY e.EmployeeID ASC

--Problem 9.Employee Manager
SELECT e.EmployeeID,
	   e.FirstName,
	   em.EmployeeID AS ManagerID,
	   em.FirstName AS ManagerName
FROM Employees AS e
INNER JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE em.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID ASC

--Problem 10.Employee Summary
SELECT TOP(50) e.EmployeeID,
			   CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
			   CONCAT(em.FirstName, ' ', em.LastName) AS ManagerName,
			   d.[Name] AS DepartmentName
FROM Employees AS e
INNER JOIN Employees AS em ON e.ManagerID = em.EmployeeID
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC

--Problem 11.Min Average Salary
SELECT TOP(1) AVG(Salary) FROM Employees
GROUP BY DepartmentID
ORDER BY AVG(Salary) ASC