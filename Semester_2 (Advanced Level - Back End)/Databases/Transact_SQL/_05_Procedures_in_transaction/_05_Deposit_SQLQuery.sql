USE T_SQL_Homework
GO

CREATE PROC usp_DepositMoney (@accountID int, @money money)
AS
	DECLARE @currBalance money;

	UPDATE Accounts
		SET Balance = Balance + @money
		WHERE Accounts.ID=@accountID

	SET @currBalance = (SELECT A.Balance FROM Accounts AS A
		WHERE A.ID = @accountID)

	PRINT 'Your new balance is ' + CAST(@currBalance AS varchar) + ' Increased with  ' + CAST(@money AS varchar)
GO