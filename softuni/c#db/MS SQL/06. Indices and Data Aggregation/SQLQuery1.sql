--01. Records’ Count
SELECT COUNT(*) FROM WizzardDeposits

--02. Longest Magic Wand
SELECT MAX(MagicWandSize) FROM WizzardDeposits

--03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS [LongestMagicWand] 
FROM WizzardDeposits
GROUP BY DepositGroup

--04. Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) 

--05. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
GROUP BY DepositGroup

--06. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--07. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum] FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC

--08. Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator

--09. Age Groups
SELECT AgeGroup, COUNT(*) AS [WizardCount] FROM 
	(SELECT 
	CASE 
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup
FROM WizzardDeposits) AS AgeGrouped
GROUP BY AgeGroup

--10. First Letter
SELECT LEFT(FirstName, 1) AS [FirstLetter] FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1) 
ORDER BY FirstLetter

--11. Average Interest
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits 
WHERE DepositStartDate > '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired 


--12. Rich Wizard, Poor Wizard
SELECT SUM([Host Wizard Deposit] - [Guest Wizard Deposit])
	AS [SumDifference]
	FROM (
		SELECT [FirstName]
		AS [Host Wizard],
			[DepositAmount]
		AS [Host Wizard Deposit],
			LEAD([FirstName]) OVER (ORDER BY [Id])
		AS [Guest Wizard],
			LEAD([DepositAmount]) OVER (ORDER BY [Id])
		AS [Guest Wizard Deposit]
		FROM [WizzardDeposits]
		) AS [HostGuestWizardQuery]
WHERE [Guest Wizard] IS NOT NULL

--13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary) FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) FROM Employees
WHERE DepartmentID IN('2', '5', '7') AND HireDate > '01-01-2000'
GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT * INTO [EmployeesAvgSalary] FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesAvgSalary
WHERE ManagerID = 42

UPDATE EmployeesAvgSalary
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary] FROM EmployeesAvgSalary
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS [MaxSalary] FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(Salary) FROM Employees
WHERE ManagerID IS NULL

--18. 3rd Highest Salary
SELECT DepartmentID, MaxSalary FROM 
	(SELECT DepartmentID, Salary, MAX(Salary) AS MaxSalary,
		DENSE_RANK() 
		OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SR
	FROM Employees
	GROUP BY DepartmentID, Salary) AS subq
WHERE subq.SR = 3

--19. Salary Challenge
SELECT TOP 10 FirstName, LastName, DepartmentID FROM Employees AS ex
WHERE Salary > (SELECT 
	AVG(Salary) AS [AverageSalary] 
	FROM Employees AS ein
	WHERE ein.DepartmentID = ex.DepartmentID
	GROUP BY DepartmentID)
ORDER BY DepartmentID

