--01. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
@salaryLevel DECIMAL(18,4)
AS
	SELECT FirstName, LastName FROM Employees
	WHERE Salary >= @salaryLevel

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--03. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith
@inputString NVARCHAR(50)
AS
	SELECT [Name] AS [Town] FROM Towns
	WHERE [Name] LIKE @inputString + '%'

EXEC usp_GetTownsStartingWith B

--04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown
@town NVARCHAR(50)
AS
	SELECT FirstName, LastName FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @town 

EXEC usp_GetEmployeesFromTown 'Sofia' 

--05. Salary Level Function
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS VARCHAR(10) AS
BEGIN
	DECLARE @result VARCHAR(10);

	IF (@salary < 30000)
		SET @result = 'Low';
	ELSE IF (@salary <= 50000)
		SET @result = 'Average';
	ELSE 
		SET @result = 'High';

	RETURN @result;
END

SELECT [Salary], [dbo].ufn_GetSalaryLevel([Salary]) AS [Salary level]
FROM [Employees]

--06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel
@levelOfSalary NVARCHAR(50)
AS
BEGIN
	SELECT FirstName, LastName 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary
END

EXEC usp_EmployeesBySalaryLevel 'High'

--07. Define Function
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(100))
RETURNS BIT
AS
BEGIN 
	DECLARE @i INT = 1
	WHILE @i <= LEN(@word)
	BEGIN
		DECLARE @ch NVARCHAR(1) = SUBSTRING(@word, @i, 1)
		IF CHARINDEX(@ch, @setOfLetters) = 0
			RETURN 0
		ELSE
			SET @i += 1
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('ABCD', 'F')

--08. *Delete Employees and Departments
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
@departmentId INT
AS
BEGIN
	DECLARE @employeesToBeDeleted TABLE (ID INT)

	INSERT INTO @employeesToBeDeleted(ID)
	SELECT EmployeeID
	FROM Employees
	WHERE DepartmentID = 1

	ALTER TABLE Departments 
	ALTER COLUMN ManagerID INT 

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @employeesToBeDeleted)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @employeesToBeDeleted)

	DELETE FROM EmployeesProjects
	WHERE EmployeeID  IN (SELECT * FROM @employeesToBeDeleted)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

SELECT * FROM Departments

--09. Find Full Name
CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
	SELECT CONCAT_WS(' ', FirstName, LastName)
	FROM AccountHolders

EXEC usp_GetHoldersFullName

--10. People with Balance Higher Than
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan 
@accThreshold MONEY
AS
	SELECT FirstName as [First Name], LastName as [Last Name]
	FROM AccountHolders AS ah
	LEFT JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.Id, ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @accThreshold
	ORDER BY FirstName, LastName

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,2), @rate FLOAT, @years INT)
RETURNS DECIMAL(20,4)
AS
BEGIN
	RETURN @sum * POWER((1 + @rate), @years)
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12. Calculating Interest
CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
	DECLARE @Years INT = 5

	SELECT a.Id AS [Account Id], ah.FirstName, ah.LastName, a.Balance,
			dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, @Years) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--13. *Cash in User Games Odd Rows
CREATE FUNCTION [ufn_CashInUsersGames](@gameName NVARCHAR(50))
RETURNS TABLE
AS RETURN (
            SELECT SUM([Cash])
                AS [SumCash]
                FROM (
                        SELECT [ug].[Cash],
                                ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC)
                            AS [RowNumber]
                            FROM [UsersGames]
                            AS [ug]
                    LEFT JOIN [Games]
                            AS [g]
                            ON [ug].[GameId] = [g].[Id]
                        WHERE [g].[Name] = @gameName
                    ) AS [RowNumberSubquery]
                WHERE [RowNumber] % 2 <> 0
            )
 
SELECT * FROM [ufn_CashInUsersGames]('Dahlia')