USE T_SQL_Homework
GO

CREATE TRIGGER tr_LogsAccountsChanges ON Accounts
  INSTEAD OF UPDATE
AS
BEGIN
	DECLARE @accountID int, @oldSum money, @newSum money, @currID int
	
	SELECT @accountID = inserted.ID,
		@newSum = inserted.Balance,
		@currID = inserted.ID
	FROM inserted

	SET @oldSum = (SELECT A.Balance FROM Accounts AS A 
	WHERE A.ID = @currID)
	
	INSERT INTO Logs (AccountID, OldSum, NewSum, ChangeTime)
	VALUES (
		@accountID,
		@oldSum,
		@newSum,
		GETDATE()
	)

	UPDATE Accounts
	SET Balance = @newSum
	WHERE ID = @currID

END
	