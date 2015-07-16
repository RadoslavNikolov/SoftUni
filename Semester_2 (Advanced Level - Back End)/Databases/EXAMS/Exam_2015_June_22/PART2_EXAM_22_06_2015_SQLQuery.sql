--Part II – Changes in the Database

--Problem 13.	Non-international Matches

USE Football
IF OBJECT_ID('FriendlyMatches') IS NOT NULL
	DROP TABLE FriendlyMatches

CREATE TABLE FriendlyMatches (
	Id int IDENTITY NOT NULL,
	HomeTeamId int NOT NULL,
	AwayTeamId int NOT NULL,
	MatchDate datetime NULL
	CONSTRAINT PK_FriendlyMatches PRIMARY KEY(Id))
GO

ALTER TABLE FriendlyMatches WITH CHECK ADD CONSTRAINT
FK_FriendlyMatches_Teams_HomeTeam FOREIGN KEY (HomeTeamId)
REFERENCES Teams(Id)
GO

ALTER TABLE FriendlyMatches WITH CHECK ADD CONSTRAINT
FK_FriendlyMatches_Teams_AwayTeam FOREIGN KEY (AwayTeamId)
REFERENCES Teams(Id)
GO

INSERT INTO Teams(TeamName) VALUES
 ('US All Stars'),
 ('Formula 1 Drivers'),
 ('Actors'),
 ('FIFA Legends'),
 ('UEFA Legends'),
 ('Svetlio & The Legends')
GO

INSERT INTO FriendlyMatches(
  HomeTeamId, AwayTeamId, MatchDate) VALUES
  
((SELECT Id FROM Teams WHERE TeamName='US All Stars'), 
 (SELECT Id FROM Teams WHERE TeamName='Liverpool'),
 '30-Jun-2015 17:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Formula 1 Drivers'), 
 (SELECT Id FROM Teams WHERE TeamName='Porto'),
 '12-May-2015 10:00'),
 
((SELECT Id FROM Teams WHERE TeamName='Actors'), 
 (SELECT Id FROM Teams WHERE TeamName='Manchester United'),
 '30-Jan-2015 17:00'),

((SELECT Id FROM Teams WHERE TeamName='FIFA Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='UEFA Legends'),
 '23-Dec-2015 18:00'),

((SELECT Id FROM Teams WHERE TeamName='Svetlio & The Legends'), 
 (SELECT Id FROM Teams WHERE TeamName='Ludogorets'),
 '22-Jun-2015 21:00')

GO


SELECT 
	T1.TeamName [Home Team],
	T2.TeamName [Away Team],
	FM.MatchDate [Match Date]
FROM FriendlyMatches AS FM
JOIN Teams AS T1
	ON FM.HomeTeamId = T1.Id
JOIN Teams AS T2
	ON FM.AwayTeamId = T2.Id
UNION
SELECT
	T1.TeamName [Home Team],
	T2.TeamName [Away Team],
	TM.MatchDate [Match Date]
FROM TeamMatches AS TM
JOIN Teams AS T1
	ON TM.HomeTeamId = T1.Id
JOIN Teams AS T2
	ON TM.AwayTeamId = T2.Id
ORDER BY [Match Date] DESC


--Problem 14.	Seasonal Matches

ALTER TABLE Leagues
ADD IsSeasonal BIT NOT NULL
DEFAULT 0

INSERT INTO TeamMatches (
	HomeTeamId,AwayTeamId,HomeGoals,AwayGoals,MatchDate,LeagueId) 
VALUES
(
	(SELECT Id FROM Teams WHERE TeamName = 'Empoli'),
	(SELECT Id FROM Teams WHERE TeamName = 'Parma'),
	2,
	2,
	'19-Apr-2015 16:00',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A')
),
(
	(SELECT Id FROM Teams WHERE TeamName = 'Internazionale'),
	(SELECT Id FROM Teams WHERE TeamName = 'AC Milan'),
	0,
	0,
	'19-Apr-2015 21:45',
	(SELECT Id FROM Leagues WHERE LeagueName = 'Italian Serie A')
)

UPDATE Leagues
SET IsSeasonal = 1
WHERE Id IN (
	SELECT 
		L.Id
	FROM Leagues AS L
	JOIN TeamMatches AS TM
		ON TM.LeagueId = L.Id
	GROUP BY L.Id
	HAVING COUNT(Tm.Id) > 0
)

SELECT 
	T1.TeamName [Home Team],
	TM.HomeGoals [Home Goals],
	T2.TeamName [Away Team],
	TM.AwayGoals [Away Goals],
	L.LeagueName [League Name]
FROM TeamMatches AS TM
JOIN Leagues AS L
	ON TM.LeagueId = L.Id
JOIN Teams AS T1
	ON TM.HomeTeamId = T1.Id
JOIN Teams AS T2
	ON TM.AwayTeamId = T2.Id
WHERE TM.MatchDate > '10-Apr-2015' AND L.IsSeasonal = 1
ORDER BY [League Name] ASC, [Home Goals] DESC, [Away Goals] DESC

