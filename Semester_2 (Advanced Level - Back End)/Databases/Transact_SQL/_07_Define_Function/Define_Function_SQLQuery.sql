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