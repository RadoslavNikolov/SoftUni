--Part II – Changes in the Database
--Problem 15.	Monasteries by Country

CREATE TABLE Monasteries (
	ID int PRIMARY KEY IDENTITY,
	Name nvarchar(50),
	CountryCode char(2),
	)
GO


ALTER TABLE Monasteries WITH CHECK ADD CONSTRAINT FK_Monasteries_Countries
FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
GO

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

ALTER TABLE Countries
ADD IsDeleted BIT NOT NULL
DEFAULT 0



UPDATE Countries
SET IsDeleted = 1
WHERE Countries.CountryCode IN (
	SELECT 
	C.CountryCode
	FROM Countries AS C
	LEFT JOIN CountriesRivers AS CR
		ON CR.CountryCode = C.CountryCode
	GROUP BY C.CountryCode
	--ORDER BY RiverCount DESC
	HAVING COUNT(CR.RiverId) > 3
)

SELECT * FROM Countries
WHERE Countries.IsDeleted = 1

SELECT 
	M.Name [Monastery],
	C.CountryName [Country]
FROM Monasteries AS M
JOIN Countries AS C
	ON M.CountryCode = C.CountryCode
WHERE C.IsDeleted != 1
ORDER BY M.Name



--Problem 16.	Monasteries by Continents and Countries
SELECT * FROM Countries
ORDER BY Countries.CountryName 

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'


INSERT INTO Monasteries (Name, CountryCode)
VALUES ('Hanga Abbey', 
	(SELECT Countries.CountryCode FROM Countries
	WHERE CountryName = 'Tanzania')
)


INSERT INTO Monasteries (Name, CountryCode)
VALUES ('Myin-Tin-Daik', 
	(SELECT Countries.CountryCode FROM Countries
	WHERE CountryName = 'Maynmar')
)


SELECT 
	Con.ContinentName,
	C.CountryName,
	COUNT(M.CountryCode) [MonasteriesCount]
FROM Continents AS Con
JOIN Countries AS C
	ON C.ContinentCode = Con.ContinentCode
LEFT JOIN Monasteries AS M
	ON M.CountryCode = C.CountryCode
WHERE C.IsDeleted != 1
GROUP BY C.CountryName, Con.ContinentName
ORDER BY COUNT(M.CountryCode) DESC, C.CountryName

