--Employee Address
SELECT TOP 5 e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
FROM Employees AS e JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--Addresses with Towns
SELECT TOP 50 
	e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
FROM Employees AS e JOIN Addresses AS a ON E.AddressID = A.AddressID
					JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY FirstName, LastName 

--Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS [DepartmentName]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--Employee Departments
SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS [DepartmentName] 
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--Employees Without Project
SELECT TOP 3 e.EmployeeID, e.FirstName FROM Employees AS e 
WHERE e.EmployeeID NOT IN(SELECT EmployeeID FROM EmployeesProjects)
ORDER BY EmployeeID

--Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
FROM Employees AS e JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01'
AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.HireDate 

--Employees with Project
SELECT TOP 5 e.EmployeeID, e.FirstName, p.[Name] FROM Employees AS e 
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13'
ORDER BY e.EmployeeID

--Employee 24
SELECT e.EmployeeID, e.FirstName, 
CASE WHEN p.StartDate >= '2005-01-01' THEN NULL ELSE p.[Name] END AS [ProjectName]
FROM Employees AS e 
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName 
FROM Employees AS e 
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3,7)
ORDER BY e.EmployeeID

--Employees Summary
SELECT TOP 50 e.EmployeeID, CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName, 
CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName,
d.[Name] AS DepartmentName
FROM Employees AS e 
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
ORDER BY e.EmployeeID

--Min Average Salary
SELECT MIN(dt.AvgSalary) FROM
(SELECT AVG(e.Salary) AS AvgSalary FROM Employees AS e 
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID) AS dt

--Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Peaks AS p JOIN Mountains AS m ON p.MountainId = m.Id
JOIN MountainsCountries AS c ON c.MountainId = p.MountainId
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC

--Count Mountain Ranges
SELECT c.CountryCode, COUNT(c.CountryCode) AS [MountainRanges]
FROM Mountains AS m 
JOIN MountainsCountries AS c ON m.Id = c.MountainId
WHERE c.CountryCode IN('BG', 'RU', 'US')
GROUP BY c.CountryCode

--Countries With or Without Rivers
SELECT TOP 5 c.CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--Continents and Currencies
SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM
	(SELECT *, DENSE_RANK() OVER 
	(PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS CurrencyRank FROM 
		(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyUsage
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS CoreQuery
	WHERE CurrencyUsage > 1) AS SecondSubQuery
WHERE CurrencyRank = 1
ORDER BY ContinentCode

--Countries Without Any Mountains
SELECT COUNT(*) FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

--Highest Peak and Longest River by Country
SELECT TOP (5) [c].[CountryName],
               MAX([p].[Elevation]) AS [HighestPeakElevation],
               MAX([r].[Length]) AS [LongestRiverLength]
          FROM [Countries] AS [c]
     LEFT JOIN [CountriesRivers] AS [cr]
            ON [c].[CountryCode] = [cr].[CountryCode]
     LEFT JOIN [Rivers] AS [r]
            ON [cr].[RiverId] = [r].[Id]
     LEFT JOIN [MountainsCountries] AS [mc]
            ON [mc].[CountryCode] = [c].[CountryCode]
     LEFT JOIN [Mountains] AS [m]
            ON [mc].[MountainId] = [m].[Id]
     LEFT JOIN [Peaks] AS [p]
            ON [p].[MountainId] = [m].[Id]
      GROUP BY [c].[CountryName]
      ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]

--Highest Peak Name and Elevation by Country
SELECT TOP (5) [Country],
               CASE
                    WHEN [PeakName] IS NULL THEN '(no highest peak)'
                    ELSE [PeakName]
               END AS [Highest Peak Name],
               CASE
                    WHEN [Elevation] IS NULL THEN 0
                    ELSE [Elevation]
               END AS [Highest Peak Elevation],
               CASE
                    WHEN [MountainRange] IS NULL THEN '(no mountain)'
                    ELSE [MountainRange]
               END AS [Mountain]          
               FROM (
                       SELECT [c].[CountryName] AS [Country],
                              [m].[MountainRange],
                              [p].[PeakName],
                              [p].[Elevation],
                              DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC) 
                           AS [PeakRank]
                         FROM [Countries] AS [c]
                    LEFT JOIN [MountainsCountries] AS [mc]
                           ON [mc].[CountryCode] = [c].[CountryCode]
                    LEFT JOIN [Mountains] AS [m]
                           ON [mc].[MountainId] = [m].[Id]
                    LEFT JOIN [Peaks] AS [p]
                           ON [p].[MountainId] = [m].[Id]
                   ) AS [PeakRankingQuery]
        WHERE [PeakRank] = 1
     ORDER BY [Country], [Highest Peak Name]