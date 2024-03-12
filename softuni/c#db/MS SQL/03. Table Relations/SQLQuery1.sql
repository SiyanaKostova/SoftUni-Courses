CREATE DATABASE SoftuniDemo

USE SoftuniDemo

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY IDENTITY(101, 1),
	PassportNumber NVARCHAR(20)
)

CREATE TABLE Persons(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50),
	Salary DECIMAL(8,2),
	PassportID INT UNIQUE FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportNumber)
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
('Roberto', 433000, 102),
('Tom', 56100, 103),
('Yana', 60200, 101)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30),
	EstablishedOn DATE
)

INSERT INTO Manufacturers([Name], EstablishedOn)
VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

CREATE TABLE Models(
	ModelID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(30),
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models([Name], ManufacturerID)
VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2), 
('Model 3', 2),
('Nova', 3)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
)

INSERT INTO [Students]([Name])
VALUES
	('Mila'),
	('Toni'),
	('Ron')

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50)
)

INSERT INTO Exams([Name])
VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO [StudentsExams]([StudentID], [ExamID])
VALUES
	(1, 101),
	(1, 102),
	(2, 101),
	(3, 103),
	(2, 102),
	(2, 103)

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50),
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO [Teachers]([Name], [ManagerID])
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

CREATE TABLE Cities(
	[CityID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	[CityID] INT FOREIGN KEY REFERENCES Cities([CityID])
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE OrderItems(
	[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL,
	[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL,
	PRIMARY KEY ([OrderID], [ItemID])
)

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(50)
)

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50)
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT,
	StudentName	NVARCHAR(50),
	MajorID	INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE,
	PaymentAmount INT,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Agenda(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)

USE Geography

SELECT m.MountainRange, PeakName, Elevation 
FROM Peaks AS p
JOIN Mountains AS m ON m.Id = p.MountainId
WHERE MountainId = (SELECT Id FROM Mountains
					WHERE MountainRange = 'Rila')
ORDER BY Elevation DESC