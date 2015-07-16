SELECT T.TeamName[Team Name], L.LeagueName[League], ISNULL(C.CountryName, 'International')[League Country] FROM Leagues_Teams as LT
JOIN Teams AS T
ON LT.TeamId=T.Id
JOIN Leagues AS L
ON LT.LeagueId=L.Id
LEFT JOIN Countries AS C
ON L.CountryCode=C.CountryCode
ORDER BY [Team Name]