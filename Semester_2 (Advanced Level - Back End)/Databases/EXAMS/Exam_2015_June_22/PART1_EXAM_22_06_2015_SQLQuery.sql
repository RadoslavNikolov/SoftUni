--Problem 1.	All Teams
--Display all teams in alphabetical order. Submit for evaluation the result grid with headers.

SELECT TeamName FROM Teams
ORDER BY TeamName

--Problem 2.	Biggest Countries by Population
--Find the 50 biggest countries by population. Display the country name and population. Sort the results by population (from biggest to smallest), then by country alphabetically. Submit for evaluation the result grid with headers.

SELECT TOP 50 CountryName, Population FROM Countries
ORDER BY Population DESC, CountryName ASC


--Problem 3.	Countries and Currency (Eurzone)
--Find all countries along with information about their currency. Display the country name, country code and information if the country is in the Eurozone or not (the currency is EUR or not): either "Inside" or "Outside". Sort the results by country name alphabetically. Submit for evaluation the result grid with headers.

SELECT 
	CountryName,
	CountryCode,
	IIF(CurrencyCode = 'EUR', 'Inside', 'Outside') [Eurozone]
FROM Countries AS C
ORDER BY CountryName

--Problem 4.	Teams Holding Numbers
--Find all teams that holds numbers in their name, sorted by country code. Display the team name and country code. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	TeamName [Team Name],
	CountryCode [Country Code] 
FROM Teams
WHERE TeamName LIKE '%[0-9]%'
ORDER BY [Country Code]

--Problem 5.	International Matches
--Find all international matches sorted by date. Display the country name of the home and away team. Sort the results starting from the newest date and ending with games with no date. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.


SELECT
	HC.CountryName [Home Team],
	AC.CountryName [Away Team],
	IM.MatchDate [Match Date]
FROM InternationalMatches AS IM
JOIN Countries AS HC
	ON IM.HomeCountryCode = HC.CountryCode
JOIN Countries AS AC
	ON IM.AwayCountryCode = AC.CountryCode
ORDER BY IM.MatchDate DESC

--Problem 6.	*Teams with their League and League Country
--Find all teams, along with the leagues, they play in and the country of the league. If the league does not have a country, display "International" instead. Sort the results by team name. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT
	T.TeamName [Team Name],
	L.LeagueName [League],
	ISNULL(C.CountryName, 'International') [League Country]
FROM Teams AS T
JOIN Leagues_Teams AS LT
	ON LT.TeamId = T.Id
JOIN Leagues AS L
	ON LT.LeagueId = L.Id
LEFT JOIN Countries AS C
	ON L.CountryCode = C.CountryCode
ORDER BY T.TeamName, League



--Problem 7.	* Teams with more than One Match
--Find all teams that have more than 1 match in any league. Sort the results by team name. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.
SELECT  * FROM TeamMatches

SELECT
	T.TeamName [Team],
	(SELECT COUNT(DISTINCT TM.Id)
	FROM TeamMatches AS TM 
	WHERE TM.HomeTeamId = T.Id OR TM.AwayTeamId = T.Id) [Matches Count]
FROM Teams AS T
WHERE (SELECT COUNT(DISTINCT TM.Id)
	FROM TeamMatches AS TM 
	WHERE TM.HomeTeamId = T.Id OR TM.AwayTeamId = T.Id) > 1
ORDER BY T.TeamName

--Problem 8.	Number of Teams and Matches in Leagues
--For each league in the database, display the number of teams, number of matches and average goals per match in it. Sort the results by number of teams (from largest to smallest), then by numbers of matches (from largest to smallest). Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	L.LeagueName [League Name],
	COUNT(DISTINCT LT.TeamId) [Teams],
	COUNT(DISTINCT TM.Id) [Matches],
	ISNULL(AVG(TM.HomeGoals + TM.AwayGoals), 0) [Average Goals]
FROM Leagues AS L
LEFT JOIN Leagues_Teams AS LT
	ON LT.LeagueId = L.Id
LEFT JOIN TeamMatches AS TM
	ON TM.LeagueId = L.Id
GROUP BY L.LeagueName
ORDER BY [Teams] DESC, [Matches] DESC

--Problem 9.	Total Goals per Team in all Matches
--Find the number of goals for each Team from all matches played. Sort the results by number of goals (from highest to lowest), then by team name alphabetically. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	T.TeamName,
	(SELECT ISNULL(SUM(tm.HomeGoals), 0) 
     FROM TeamMatches AS tm 
     WHERE tm.HomeTeamId = t.Id) +
    (SELECT ISNULL(SUM(tm.AwayGoals), 0) 
     FROM TeamMatches AS tm 
     WHERE tm.AwayTeamId = t.Id) [Total Goals]
FROM Teams AS T
GROUP BY T.Id, T.TeamName
ORDER BY [Total Goals] DESC, T.TeamName ASC

--Problem 10.	Pairs of Matches on the Same Day
--Find all pairs of team matches that are on the same day. Show the date and time of each pair. Sort the dates from the newest to the oldest first date, then from the newest to the oldest second date. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT
	TM1.MatchDate [First Date],
	TM2.MatchDate [Second Date]
FROM TeamMatches AS TM1, TeamMatches AS TM2
WHERE TM2.MatchDate > TM1.MatchDate AND
	DATEDIFF(day, TM1.MatchDate, TM2.MatchDate) < 1
ORDER BY [First Date] DESC, [Second Date] DESC


--Problem 11.	Mix of Team Names
--Combine all team names with one another (including itself), so that the last letter of the first team name is the same as the first letter of the reversed second team name. Sort the results by the obtained mix alphabetically. Submit for evaluation the result grid with headers.

SELECT  
	LOWER(T2.TeamName + '' + SUBSTRING(REVERSE(T1.TeamName), 2, LEN(T1.TeamName)-1)) [Mix]
FROM Teams AS T1, Teams AS T2
WHERE RIGHT(T2.TeamName, 1) = LEFT(REVERSE(T1.TeamName), 1)
ORDER BY [Mix]

--Problem 12.	Countries with International and Team Matches
--For each country, extract the total amount of international and team matches. List only countries with at least one international or team match. Sort the results in decreasing order by international matches count, then by team matches count, than alphabetically by country name. Submit for evaluation the result grid with headers.

SELECT
	C.CountryName [Country Name],
	COUNT(DISTINCT IM1.Id) + COUNT(DISTINCT IM2.Id) AS [International Matches],
	COUNT(DISTINCT TM.Id) [Team Matches]
FROM Countries AS C
LEFT JOIN InternationalMatches AS IM1
	ON IM1.HomeCountryCode = C.CountryCode
LEFT JOIN InternationalMatches AS IM2
	ON IM2.AwayCountryCode = C.CountryCode
LEFT JOIN Leagues AS L
	ON C.CountryCode = L.CountryCode
LEFT JOIN TeamMatches AS TM
	ON TM.LeagueId = L.Id
GROUP BY C.CountryName
HAVING COUNT(DISTINCT IM1.Id) + COUNT(DISTINCT IM2.Id) > 0 OR
	COUNT(DISTINCT TM.Id) > 0
ORDER BY [International Matches] DESC, 
[Team Matches] DESC, [Country Name] ASC