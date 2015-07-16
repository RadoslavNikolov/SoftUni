USE T_SQL_Homework
GO

CREATE PROC usp_WithdrawMoney(@accountID int, @money money)
AS
	DECLARE @currBalance money;
	SET @currBalance = (SELECT A.Balance FROM Accounts AS A
		WHERE A.ID=@accountID)

	IF ( @currBalance >= @money)
		BEGIN
			UPDATE Accounts
			SET Balance = Balance - @money
			WHERE Accounts.ID=@accountID
		END
	ELSE
		BEGIN
			PRINT 'Not  enough money! You have ' + CAST(@currBalance AS varchar) + 'only!'
		END	
GO