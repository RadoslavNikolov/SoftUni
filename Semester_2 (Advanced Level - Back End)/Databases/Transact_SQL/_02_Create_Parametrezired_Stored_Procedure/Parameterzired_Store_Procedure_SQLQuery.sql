USE T_SQL_Homework
GO

CREATE PROC usp_SelectPersonMoreMoneThan(@moneyLevel int)
AS
	SELECT P.FirstName + ' ' + P.LastName[Full name], Acc.Balance FROM Persons AS P
	JOIN Accounts AS Acc
		ON P.ID = Acc.PersonID
	WHERE Acc.Balance > @moneyLevel
GO


/*EXEC usp_SelectPersonMoreMoneThan 1000