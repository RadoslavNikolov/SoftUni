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