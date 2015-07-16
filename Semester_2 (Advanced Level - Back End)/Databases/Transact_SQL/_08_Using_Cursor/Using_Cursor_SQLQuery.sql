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
