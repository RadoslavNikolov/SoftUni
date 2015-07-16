--Problem 1.	Create a database with two tables

CREATE DATABASE T_SQL_Homework
COLLATE SQL_Latin1_General_CP1_CI_AS
GO

CREATE TABLE Persons (
	ID int IDENTITY(1,1),
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	SSN varchar(10),
	CONSTRAINT PK_Persons PRIMARY KEY(ID)
)

CREATE TABLE Accounts (
	ID int IDENTITY(1,1),
	PersonID int NOT NULL,
	Balance money,
	CONSTRAINT PK_Accounts PRIMARY KEY(ID),
	CONSTRAINT FK_Persons_Accounts FOREIGN KEY(PersonID) REFERENCES Persons(ID)
)



USE T_SQL_Homework
GO

CREATE PROC usp_SelectPersonsFullName
AS
	SELECT P.FirstName + ' ' + P.LastName[Full name] FROM Persons AS P
	ORDER BY [Full name]
GO


--Problem 2.	Create a stored procedure

USE T_SQL_Homework
GO

CREATE PROC usp_SelectPersonMoreMoneThan(@moneyLevel int)
AS
	SELECT P.FirstName + ' ' + P.LastName[Full name], Acc.Balance FROM Persons AS P
	JOIN Accounts AS Acc
		ON P.ID = Acc.PersonID
	WHERE Acc.Balance > @moneyLevel
GO
--EXEC usp_SelectPersonMoreMoneThan 1000



--Problem 3.	Create a function with parameters

USE T_SQL_Homework
GO

CREATE FUNCTION ufn_CalculateInterest(@sum money, @interest float, @numMonths int) RETURNS @T TABLE(CalculatedInterest money)
AS
	BEGIN
		DECLARE @monthInterest int, @monthCounter int, @result money
		SET @monthInterest = @interest / 12
		SET @monthCounter = 0
		SET @result = @sum
		
		
		
		WHILE(@monthCounter < @numMonths)
			BEGIN
				SET @result = @result + (@result * @monthInterest / 100)
				SET @monthCounter = @monthCounter + 1
			END
		
		INSERT INTO @T(CalculatedInterest) VALUES (@result)
		RETURN
	END

GO



SELECT  * FROM ufn_CalculateInterest(10000, 7, 12)


--Problem 4.	Create a stored procedure that uses the function from the previous example.

USE T_SQL_Homework
GO

CREATE PROC usp_UpdateAccountsBalance(@accountID int, @yearlyInterest float)
AS
	UPDATE Accounts
		SET Balance = (SELECT * FROM ufn_CalculateInterest(Accounts.Balance, @yearlyInterest, 1))
		WHERE Accounts.ID=@accountID

GO


EXEC usp_UpdateAccountsBalance 1,120


--Problem 5.	Add two more stored procedures WithdrawMoney and DepositMoney.

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

--Transactions

BEGIN TRAN
	BEGIN TRY
		EXEC usp_DepositMoney 1, 1000
		
		COMMIT TRAN
	END TRY

BEGIN CATCH

  ROLLBACK TRAN

END CATCH



BEGIN TRAN
	BEGIN TRY
		EXEC usp_WithdrawMoney 1, 1000
		
		COMMIT TRAN
	END TRY

BEGIN CATCH

  ROLLBACK TRAN

END CATCH


--Problem 6.	Create table Logs.


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


--Problem 7.	Define function in the SoftUni database.

USE SoftUni
GO

CREATE FUNCTION ufn_checkWord(@inputString nvarchar(max), @seekWord nvarchar(max)) RETURNS int
BEGIN
	DECLARE  @char nvarchar(1), @index int, @wordLen int, @inputStringLen int, @charIndex int
	--SET @inputString = 'oistmiahf'
	--SET @seekWord = 'Sofia'
	SET @wordLen = LEN(@seekWord)
	SET @index = 1

	WHILE(@index <= @wordLen )
	BEGIN
		SET @char = SUBSTRING(@seekWord, @index, 1)
		SET @inputStringLen = LEN(@inputString)

		--PRINT @char	
		SET @charIndex = CHARINDEX(@char, @inputString)

		--PRINT @charIndex
		IF(@charIndex = 0)
			BEGIN
				RETURN 0
			END
		ELSE
			BEGIN
				IF (@charIndex = 1)
					BEGIN
						SET @inputString = SUBSTRING(@inputString, 2, @inputStringLen)
					END
				ELSE
					BEGIN
						IF(@charIndex = @inputStringLen)
							BEGIN
								SET @inputString = SUBSTRING(@inputString, 1, @inputStringLen - 1 ) 
							END
						ELSE
							BEGIN
								SET @inputString = SUBSTRING(@inputString, 1, @charIndex -1 ) + SUBSTRING(@inputString, @charIndex  + 1, @inputStringLen)
							END
					END
			END

		SET @index = @index + 1	
		--PRINT @inputString
	END
	RETURN 1
END
GO


DECLARE empCursor CURSOR READ_ONLY FOR
	(SELECT E.FirstName, E.LastName, T.Name
	 FROM Employees AS E
		JOIN Addresses AS A
			ON A.AddressID = E.AddressID
		JOIN Towns AS T
			ON T.TownID = A.TownID)

OPEN empCursor
DECLARE @firstName nvarchar(50), @lastName nvarchar(50), @town nvarchar(50), @string nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

SET @string = 'oistmiahf'

WHILE @@FETCH_STATUS = 0
  BEGIN
    FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town
	IF dbo.ufn_checkWord(@string, @firstName) = 1
		BEGIN
			print @firstName
		END	
	IF dbo.ufn_checkWord(@string, @lastName) = 1
		BEGIN
			print @lastName
		END	
	IF dbo.ufn_checkWord(@string, @town) = 1
		BEGIN
			print @town
		END	
  END

CLOSE empCursor
DEALLOCATE empCursor



--Problem 8.	Using database cursor write a T-SQL


DECLARE @FirstEmployeeTable TABLE
(
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	TownId INT,
	TownName NVARCHAR(50)
)

DECLARE @SecondEmployeeTable TABLE
(
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	TownId INT,
	TownName NVARCHAR(50)
)

INSERT INTO @FirstEmployeeTable (FirstName, LastName, TownId, TownName)
	SELECT e.FirstName, e.LastName, t.TownID, t.Name
	FROM Employees e
	INNER JOIN Addresses a 
		ON e.AddressID = a.AddressID
	INNER JOIN Towns t 
		ON a.TownID = t.TownID
	ORDER BY e.FirstName

INSERT INTO @SecondEmployeeTable (FirstName, LastName, TownId, TownName)
	SELECT * FROM @FirstEmployeeTable

DECLARE employeesCursor CURSOR READ_ONLY FOR
	SELECT fe.FirstName, fe.LastName, se.FirstName, se.LastName, fe.TownName FROM @FirstEmployeeTable fe
	INNER JOIN @SecondEmployeeTable se 
		ON fe.TownId = se.TownId
	ORDER BY fe.FirstName

OPEN employeesCursor
DECLARE @FirstEmployeeFirstName nvarchar(50),
		@FirstEmployeeLastName nvarchar(50),
		@SecondEmployeeFirstName nvarchar(50),
		@SecondEmployeeLastName nvarchar(50),
		@TownName nvarchar(50)
FETCH NEXT FROM employeesCursor INTO @FirstEmployeeFirstName, @FirstEmployeeLastName,
	@SecondEmployeeFirstName, @SecondEmployeeLastName, @TownName

WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT @SecondEmployeeLastName + ': ' + @FirstEmployeeFirstName + ' ' +
		@FirstEmployeeLastName + ' ' + @TownName + ' ' + @SecondEmployeeFirstName

		FETCH NEXT FROM employeesCursor INTO @FirstEmployeeFirstName, @FirstEmployeeLastName,
			@SecondEmployeeFirstName, @SecondEmployeeLastName, @TownName
	END
	CLOSE employeesCursor
	DEALLOCATE employeesCursor
