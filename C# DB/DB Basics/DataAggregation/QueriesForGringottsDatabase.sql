--Problem 1.Records’ Count
SELECT COUNT(*) AS Count FROM WizzardDeposits

--Problem 2.Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand FROM WizzardDeposits

--Problem 3.Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 4.* Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC

--Problem 5.Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
GROUP BY DepositGroup

--Problem 6.Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--Problem 7.Deposits Filter
SELECT * 
FROM (SELECT DepositGroup, SUM(DepositAmount) AS TotalSum FROM WizzardDeposits
      WHERE MagicWandCreator = 'Ollivander family'
      GROUP BY DepositGroup
     ) AS DepositGroupsTotalSum
WHERE TotalSum < 150000
ORDER BY TotalSum DESC

--Problem 8.Deposit Charge
SELECT DepositGroup, 
       MagicWandCreator, 
       MIN(DepositCharge) AS MinDepositCharge 
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator

--Problem 9.Age Groups
SELECT AgeGroup,
       COUNT(*) AS WizardCount
FROM	(SELECT  CASE
         			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
         			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
         			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
         			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
         			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
         			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
         			ELSE '[61+]'
         		END AS AgeGroup
         FROM WizzardDeposits
		) AS WizzardAge
GROUP BY AgeGroup

--Problem 10.First Letter
SELECT LEFT(FirstName, 1) AS FirstLetter FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter ASC

--Problem 11.Average Interest 
SELECT DepositGroup, 
       IsDepositExpired, 
       AVG(DepositInterest) AS AverageInterest 
FROM WizzardDeposits
WHERE DepositStartDate > '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC,
         IsDepositExpired ASC

--Problem 12.* Rich Wizard, Poor Wizard
SELECT SUM(HostWizardDeposit - GuestWizardDeposit) AS SumDifference
FROM	(SELECT DepositAmount AS HostWizardDeposit,
         	    LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestWizardDeposit
         FROM WizzardDeposits
		) AS WizzardsDiff
