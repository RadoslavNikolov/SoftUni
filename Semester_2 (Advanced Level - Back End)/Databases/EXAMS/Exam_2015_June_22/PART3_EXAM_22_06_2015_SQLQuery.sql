--Part III – Stored Procedures

--Problem 15.	Stored Function: Bulgarian Teams with Matches JSON
--Create a stored function fn_TeamsJSON that lists all Bulgarian teams alphabetically along with all games starting from the newest date and ending with games with no date. Format the output as JSON string without any whitespace. 
USE Football
GO

IF OBJECT_ID('fn_TeamsJSON') IS NOT NULL
	DROP FUNCTION fn_TeamsJSON
GO

CREATE FUNCTION fn_TeamsJSON()
	RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"teams":['
	DECLARE teamsCursor CURSOR  FOR
	SELECT Id, TeamName  FROM Teams
		WHERE CountryCode = 'BG'
	ORDER BY TeamName ASC

	OPEN teamsCursor
	DECLARE @TeamName NVARCHAR(MAX)
	DECLARE @TeamID INT

	FETCH NEXT FROM teamsCursor INTO @TeamID,@TeamName
	WHILE @@FETCH_STATUS = 0
		BEGIN
			SET @json = @json + '{"name":"' + @TeamName + '","matches":['

			DECLARE matchesCursor CURSOR FOR
			SELECT
				T1.TeamName,
				T2.TeamName,
				TM.HomeGoals,
				TM.AwayGoals,
				TM.MatchDate
			FROM TeamMatches AS TM
			LEFT JOIN Teams AS T1
				ON TM.HomeTeamId = T1.Id
			LEFT JOIN Teams AS T2
				ON TM.AwayTeamId = T2.Id
			WHERE HomeTeamId = @TeamID OR AwayTeamId = @TeamID
			ORDER BY TM.MatchDate DESC

			OPEN matchesCursor
			DECLARE @HomeTeamName NVARCHAR(MAX)
			DECLARE @AwayTeamName NVARCHAR(MAX)
			DECLARE @HomeGoals INT
			DECLARE @AwayGoals INT
			DECLARE @MatchDate DATE

			FETCH NEXT FROM matchesCursor INTO @HomeTeamName, @AwayTeamName, @HomeGoals, @AwayGoals, @MatchDate
			WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @json = @json + '{"' + @HomeTeamName + '":' + CAST(@HomeGoals AS NVARCHAR(10)) + ',"' +
					@AwayTeamName + '":' + CAST(@AwayGoals AS NVARCHAR(10)) + ',"date":' +
					CONVERT(NVARCHAR(MAX), @MatchDate, 103) + '}'

					FETCH NEXT FROM matchesCursor INTO @HomeTeamName, @AwayTeamName, @HomeGoals, @AwayGoals, @MatchDate
					IF @@FETCH_STATUS = 0						SET @json = @json + ','
				END
			CLOSE matchesCursor
			DEALLOCATE matchesCursor
			SET @json = @json + ']}'

			FETCH NEXT FROM teamsCursor INTO @TeamID,@TeamName
			IF @@FETCH_STATUS = 0
				SET @json = @json + ','
		END
	CLOSE teamsCursor
	DEALLOCATE teamsCursor 

	SET @json = @json + ']}'
	RETURN @json
END
GO

SELECT dbo.fn_TeamsJSON()
