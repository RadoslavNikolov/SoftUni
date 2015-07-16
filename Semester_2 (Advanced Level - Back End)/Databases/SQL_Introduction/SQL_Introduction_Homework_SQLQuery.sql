--Homework: SQL Introduction

--Problem 4.	Write a SQL query to find all information about all departments (use "SoftUni" database).

SELECT * FROM Departments

--Problem 5.	Write a SQL query to find all department names.

SELECT Dep.Name FROM Departments AS Dep

--Problem 6.	Write a SQL query to find the salary of each employee. 

SELECT E.FirstName + ' ' + E.LastName[Full name], E.Salary  FROM Employees AS E

--Problem 7.	Write a SQL to find the full name of each employee.

SELECT E.FirstName + ' ' + E.LastName[Full name]  FROM Employees AS E

 --Problem 8.	Write a SQL query to find the email addresses of each employee.

 SELECT  E.FirstName + ' ' + E.LastName[Employee full name], E.FirstName + '.' + E.LastName + '@softuni.bg'[Email address] FROM Employees AS E

 --Problem 9.	Write a SQL query to find all different employee salaries. 

 SELECT DISTINCT E.Salary[Distinct Salary]  FROM Employees AS E

 --Problem 10.	Write a SQL query to find all information about the employees whose job title is “Sales Representative“.

 SELECT * FROM Employees AS E
WHERE E.JobTitle='Sales Representative'

 --Problem 11.	Write a SQL query to find the names of all employees whose first name starts with "SA".

 SELECT * FROM Employees AS E
WHERE E.FirstName LIKE 'SA%'

 --Problem 12.	Write a SQL query to find the names of all employees whose last name contains "ei".

 SELECT * FROM Employees AS E
WHERE E.LastName LIKE '%ei%'

 --Problem 13.	Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].

 SELECT * FROM Employees AS E
WHERE E.Salary BETWEEN 20000 AND 30000
ORDER BY E.Salary

 --Problem 14.	Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

 SELECT * FROM Employees AS E
WHERE E.Salary IN (25000, 14000, 12500, 23600)
ORDER BY E.Salary DESC

 --Problem 15.	Write a SQL query to find all employees that do not have manager.

 SELECT * FROM Employees AS E
WHERE E.ManagerID IS NULL

 --Problem 16.	Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.

 SELECT * FROM Employees AS E
WHERE E.Salary > 50000
ORDER BY E.Salary DESC

 --Problem 17.	Write a SQL query to find the top 5 best paid employees.

 SELECT TOP 5 E.Salary FROM Employees AS E
ORDER BY E.Salary DESC

--Problem 18.	Write a SQL query to find all employees along with their address.

SELECT * FROM Employees AS E
JOIN Addresses AS A
ON E.AddressID=A.AddressID

--Problem 19.	Write a SQL query to find all employees and their address.

SELECT * 
FROM Employees AS E, Addresses AS A
WHERE E.AddressID=A.AddressID

--Problem 20.	Write a SQL query to find all employees along with their manager.

SELECT * 
FROM Employees AS E, Employees AS E1
WHERE E.ManagerID=E1.EmployeeID

SELECT * FROM Employees AS E
JOIN Employees AS E1
ON E.ManagerID=E1.EmployeeID

--Problem 21.	Write a SQL query to find all employees, along with their manager and their address.

SELECT E.EmployeeID, E.FirstName + ' ' + E.LastName[Employee Full Name], E.JobTitle, E.DepartmentID, E.Salary,
	E1.EmployeeID[Manager ID], E1.FirstName + ' ' + E1.LastName[Manager Full Name], E1.Salary[Manager Salary],
	A.AddressText[Manager Address], T.Name[Town name]
FROM Employees AS E
JOIN Employees AS E1
ON E.ManagerID=E1.EmployeeID
JOIN Addresses AS A
ON E1.AddressID=A.AddressID
JOIN Towns AS T
ON A.TownID=T.TownID
ORDER BY E.ManagerID

--Problem 22.	Write a SQL query to find all departments and all town names as a single list.

SELECT Departments.Name FROM Departments
UNION ALL
SELECT Towns.Name FROM Towns

--Problem 23.	Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager. 

SELECT * FROM Employees AS E
LEFT JOIN Employees AS E1
ON E.ManagerID=E1.EmployeeID

--Problem 24.	Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.

SELECT * FROM Employees AS E
JOIN Departments AS Dep
ON E.DepartmentID=Dep.DepartmentID
WHERE Dep.Name IN ('Sales', 'Finance')
AND E.HireDate BETWEEN '1995-01-01' AND '2004-12-31'
