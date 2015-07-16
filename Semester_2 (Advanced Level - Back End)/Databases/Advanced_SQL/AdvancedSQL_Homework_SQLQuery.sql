--Homework: Advanced SQL

--Problem 1.	Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.

SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary = 
(SELECT MIN(Salary) FROM Employees)

--Problem 2.	Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

DECLARE @minSalary money
SET @minSalary = (SELECT MIN(Salary) FROM Employees) 

SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary BETWEEN @minSalary AND @minSalary * 1.1

--Problem 3.	Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.

SELECT FirstName + ' ' + LastName[Full Name], JobTitle, Salary, Dep.Name[Dep Name] FROM Employees E
JOIN Departments AS Dep
	ON E.DepartmentID = Dep.DepartmentID
WHERE Salary =
(SELECT MIN(Salary) FROM Employees
	WHERE DepartmentID = E.DepartmentID)

--Problem 4.	Write a SQL query to find the average salary in the department #1.

SELECT E.DepartmentID, Dep.Name[Department Name], AVG(Salary) AS AvgSalary
FROM Employees AS E
JOIN Departments AS Dep
	ON E.DepartmentID = Dep.DepartmentID
WHERE E.DepartmentID = 1
GROUP BY E.DepartmentID, Dep.Name

--Problem 5.	Write a SQL query to find the average salary in the "Sales" department.

SELECT E.DepartmentID, Dep.Name[Department Name], AVG(Salary) AS AvgSalary
FROM Employees AS E
JOIN Departments AS Dep
	ON E.DepartmentID = Dep.DepartmentID
WHERE Dep.Name='Sales'
GROUP BY E.DepartmentID, Dep.Name

--Problem 6.	Write a SQL query to find the number of employees in the "Sales" department.

SELECT  COUNT(*) [Num Employees in Sales] FROM Employees AS E
JOIN Departments AS D
	ON E.DepartmentID = D.DepartmentID
WHERE D.Name = 'Sales'

--Problem 7.	Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(ManagerID) [Num of employees with manager] FROM Employees AS E

--Problem 8.	Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) [Num of employees without manager] FROM Employees AS E
WHERE E.ManagerID IS NULL

--Problem 9.	Write a SQL query to find all departments and the average salary for each of them.

SELECT Dep.Name[Department Name], AVG(Salary) AS AvgSalary
FROM Employees AS E
JOIN Departments AS Dep
	ON E.DepartmentID = Dep.DepartmentID
GROUP BY E.DepartmentID, Dep.Name
ORDER BY [Department Name]

--Problem 10.	Write a SQL query to find the count of all employees in each department and for each town. 

SELECT T.Name[Town], Dep.Name[Department Name], COUNT(*) [Num of employees in department]
FROM Employees AS E
JOIN Departments AS Dep
	ON E.DepartmentID = Dep.DepartmentID
JOIN Addresses AS A
	ON E.AddressID = A.AddressID
JOIN Towns AS T
	ON A.TownID = T.TownID
GROUP BY E.DepartmentID, Dep.Name, T.Name
ORDER BY [Department Name]

--Problem 11.	Write a SQL query to find all managers that have exactly 5 employees.

SELECT E.ManagerID, M.FirstName, M.LastName, COUNT(*) [Num of employees in department]
FROM Employees AS E
JOIN Employees AS M
	ON E.ManagerID = M.EmployeeID
GROUP BY E.ManagerID, M.FirstName, M.LastName
	HAVING COUNT(E.EmployeeID) = 5
ORDER BY M.LastName

--Problem 12.	Write a SQL query to find all employees along with their managers.

SELECT E.FirstName + ' ' + E.LastName[Employee full name], ISNULL(M.FirstName + ' ' + M.LastName, 'No manager') [Manager]
FROM Employees AS E
LEFT JOIN Employees AS M
	ON E.ManagerID = M.EmployeeID

--Problem 13.	Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 

SELECT FirstName, LastName FROM Employees
WHERE LEN(LastName) = 5

--Problem 14.	Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". 

SELECT CONVERT(VARCHAR(23), GETDATE(), 121) AS DateTime

--Problem 15.	Write a SQL statement to create a table Users.

CREATE TABLE Users (
	ID int IDENTITY(1,1),
	UserName nvarchar(50) NOT NULL,
	UserPassword nvarchar(30) NOT NULL,
	FullName nvarchar(100) NOT NULL,
	LastLogIn datetime NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY(ID),
	CONSTRAINT uc_UserName UNIQUE (UserName),
	CONSTRAINT chk_PasswordLen CHECK (LEN(UserPassword) >= 5))

--Problem 16.	Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.

CREATE VIEW [Users loged today] AS
 SELECT UserName, FullName, LastLogIn
 FROM Users
 WHERE DATEADD(dd,0, DATEDIFF(dd,0,LastLogIn)) =
	 DATEADD(dd,0, DATEDIFF(dd,0,GETDATE()))

--Or second version

CREATE VIEW [Users loged today] AS
 SELECT UserName, FullName, LastLogIn
 FROM Users
 WHERE cast(LastLogIn as date) = cast(GETDATE() as date)

--Problem 17.	Write a SQL statement to create a table Groups. 

CREATE TABLE Groups (
	ID int IDENTITY(1,1),
	Name nvarchar(20) NOT NULL,
	CONSTRAINT PK_Groups PRIMARY KEY(ID),
	CONSTRAINT uc_Name UNIQUE(Name))

--Problem 18.	Write a SQL statement to add a column GroupID to the table Users.

ALTER TABLE Users ADD GroupID int


ALTER TABLE Users ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY(GroupID) REFERENCES Groups(ID)

--Problem 19.	Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups (Name)
 VALUES ('Junior');


INSERT INTO Users (UserName,UserPassword,FullName, LastLogIn,GroupID)
	VALUES('batko', '664488', 'Batko Batkov', '2015-06-26', 2)

--Problem 20.	Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
 SET GroupID= 2
 WHERE UserName='batko'

--Problem 21.	Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE U FROM Users U
JOIN Groups G
	ON U.GroupID=G.ID
 WHERE G.Name = 'Senior'

--Problem 22.	Write SQL statements to insert in the Users table the names of all employees from the Employees table.

INSERT INTO Users (UserName,UserPassword,FullName, LastLogIn,GroupID)
	SELECT
		LEFT(E.FirstName,1) + '' + LOWER(E.LastName) + '' + UPPER(RIGHT(E.FirstName,1)),
		SUBSTRING(LOWER(RIGHT(E.FirstName,1)) + LOWER(E.LastName) + LOWER(E.FirstName),1,10),
		E.FirstName + ' ' + E.LastName,
		NULL,
		3 
	FROM Employees AS E

--Problem 23.	Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

UPDATE Users
 SET UserPassword = NULL
 WHERE cast(LastLogIn as date) < cast('2010-03-10' as date)

--Problem 24.	Write a SQL statement that deletes all users without passwords (NULL password).

DELETE U FROM Users U
 WHERE U.UserPassword IS NULL

--Problem 25.	Write a SQL query to display the average employee salary by department and job title.

SELECT  Dep.Name[Department], E.JobTitle, AVG(Salary)[Average Salary] FROM Employees AS E
JOIN Departments AS Dep
	ON E.DepartmentID=Dep.DepartmentID
GROUP BY Dep.Name, JobTitle

--Problem 26.	Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.

WITH MyView AS 
(
	SELECT  Dep.Name[Department],  E.JobTitle, E.FirstName, MIN(Salary)[Min Salary], ROW_NUMBER() OVER(PARTITION BY E.JobTitle ORDER BY E.FirstName DESC)[RowNumber]
	 FROM Employees AS E
	JOIN Departments AS Dep
		ON E.DepartmentID=Dep.DepartmentID
	GROUP BY Dep.Name, E.JobTitle, E.FirstName
)
SELECT MyView.Department, MyView.JobTitle, MyView.FirstName, MyView.[Min Salary]
FROM MyView
WHERE RowNumber = 1
ORDER BY MyView.Department

--Problem 27.	Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 T.Name, COUNT(*)[Number if employees] FROM Employees AS E
JOIN Addresses AS A
	ON E.AddressID = A.AddressID
JOIN Towns AS T
	ON A.TownID = T.TownID
GROUP BY T.Name
ORDER BY [Number if employees] DESC

--Problem 28.	Write a SQL query to display the number of managers from each town.

SELECT DISTINCT T.Name[Town], COUNT(*)[Numbers of managers] FROM Employees AS E
JOIN Addresses AS A
	ON E.AddressID = A.AddressID
JOIN Towns AS T
	ON A.TownID = T.TownID
WHERE E.EmployeeID IN
	(
		SELECT M.ManagerID FROM Employees AS M
		WHERE M.ManagerID IS NOT NULL
	)
GROUP BY T.Name

--Or second version


WITH MyView AS 
(
	SELECT DISTINCT M.ManagerID, E.FirstName, T.TownID, T.Name FROM Employees AS M
	JOIN Employees AS E
		ON M.ManagerID = E.EmployeeID
	JOIN Addresses AS A
		ON E.AddressID = A.AddressID
	JOIN Towns AS T
		ON A.TownID = T.TownID
	WHERE M.ManagerID IS NOT NULL
	GROUP BY T.TownID, M.ManagerID, E.FirstName, T.Name
)
SELECT MyView.Name[Town], COUNT(*)[Number of managers]
FROM MyView
GROUP BY MyView.TownID, MyView.Name
ORDER BY MyView.Name

--Problem 29.	Write a SQL to create table WorkHours to store work reports for each employee.

CREATE TABLE WorkHours (
	ID int IDENTITY(1,1),
	EmployeeID int NOT NULL,
	TaskDate datetime NOT NULL,
	Task nvarchar(100) NOT NULL,
	WorkHours int NOT NULL,
	Comments text,
	CONSTRAINT PK_Users PRIMARY KEY(ID),
	FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)

--Problem 30.	Issue few SQL statements to insert, update and delete of some data in the table.

INSERT INTO WorkHours (EmployeeID, TaskDate, Task, WorkHours, Comments)
SELECT DISTINCT
	E.EmployeeID, 
	GETDATE(),
	'Relax',
	0,
	'innitila insert'	
FROM Employees AS E
ORDER BY E.EmployeeID ASC

DELETE FROM WorkHours
WHERE EmployeeID BETWEEN 0 AND 100

--Problem 31.	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.

--Delete triggre
CREATE TRIGGER tr_WorkReportDelete ON WorkHours
  INSTEAD OF DELETE
AS
	IF @@ROWCOUNT = 0 return;
	INSERT INTO WorkHoursOldData (EmployeeID, TaskDate, Task, WorkHours, Comments)
	SELECT  
		d.EmployeeID,
		d.TaskDate,
		d.Task,
		d.WorkHours,
		d.Comments
	FROM deleted D
	JOIN WorkHours AS WH
		ON WH.ID = D.ID
	
	DELETE WorkHours 
	WHERE ID IN (SELECT ID FROM deleted)

	DECLARE @oldDataID int
	SET @oldDataID = (
		SELECT TOP 1 old.ID FROM WorkHoursOldData AS old
		ORDER BY old.ID DESC
	)

	INSERT INTO WorkHoursOldDataCommands (OldDataID, CommandID, NewDataID, ChageDataTime, Reason) 
	VALUES (
		@oldDataID,
		3,
		null,
		GETDATE(),
		'delete command'
	)
GO

--Insert trigger

CREATE TRIGGER trgAfterInsert ON WorkHours
FOR INSERT
AS  
	DECLARE @lastDataID int
	SET @lastDataID = (
		SELECT TOP 1 WH.ID FROM WorkHours AS WH
		ORDER BY WH.ID DESC
	)
	
    INSERT INTO WorkHoursOldDataCommands (OldDataID, CommandID, NewDataID, ChageDataTime, Reason) 
	Values (
		NULL,
		1,
		@lastDataID,
		GETDATE(),
		'insert data'
	)
GO

--Problem 32.	Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.

BEGIN TRAN
	DECLARE @salesDepID int 
	SET @salesDepID = (SELECT DepartmentID FROM Departments
		WHERE Name = 'Sales')
	DELETE FROM Employees 
	WHERE DepartmentID = @salesDepID

ROLLBACK TRAN

