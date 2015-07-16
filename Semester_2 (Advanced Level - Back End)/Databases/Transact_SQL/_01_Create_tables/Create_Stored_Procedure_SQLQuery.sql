USE T_SQL_Homework
GO

CREATE PROC usp_SelectPersonsFullName
AS
	SELECT P.FirstName + ' ' + P.LastName[Full name] FROM Persons AS P
	ORDER BY [Full name]
GO