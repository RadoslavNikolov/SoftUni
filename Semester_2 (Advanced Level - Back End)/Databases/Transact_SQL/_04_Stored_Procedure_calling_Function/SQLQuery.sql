USE T_SQL_Homework
GO

CREATE PROC usp_UpdateAccountsBalance(@accountID int, @yearlyInterest float)
AS
	UPDATE Accounts
		SET Balance = (SELECT * FROM ufn_CalculateInterest(Accounts.Balance, @yearlyInterest, 1))
		WHERE Accounts.ID=@accountID

GO


/*EXEC usp_UpdateAccountsBalance 1,120*/