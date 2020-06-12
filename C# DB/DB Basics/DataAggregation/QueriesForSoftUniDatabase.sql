--Problem 13.Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS TotalSalary FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID ASC

--Problem 14.Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimuSalary FROM Employees
WHERE HireDate > '01-01-2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)

--Problem 15.Employees Average Salaries
SELECT * 
INTO EmployeesWithSalaryMoreThan30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithSalaryMoreThan30000
WHERE ManagerID = 42

UPDATE EmployeesWithSalaryMoreThan30000
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID,
       AVG(Salary)
FROM EmployeesWithSalaryMoreThan30000
GROUP BY DepartmentID

--Problem 16.Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--Problem 17.Employees Count Salaries
SELECT COUNT(*) AS Count FROM Employees
WHERE ManagerID IS NULL

--Problem 18.*3rd Highest Salary
SELECT DepartmentID,
	   Salary AS ThirdHighestSalary
FROM	(SELECT DepartmentID,
         	   Salary,
         	   Rank() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
         FROM Employees
         GROUP BY DepartmentID, Salary
        ) AS RankSalariesInDepartments
WHERE Rank = 3

--Problem 19.**Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary > (SELECT AVG(Salary) 
                FROM Employees AS eavg 
				GROUP BY DepartmentID 
				HAVING e.DepartmentID = eavg.DepartmentID )
ORDER BY DepartmentID