--Problem 1.	All Mountain Peaks
--Display all ad mountain peaks in alphabetical order. Submit for evaluation the result grid with headers.
SELECT PeakName FROM Peaks
ORDER BY PeakName

--Problem 2.	Biggest Countries by Population
--Find the 30 biggest countries by population from Europe. Display the country name and population. Sort the results by population (from biggest to smallest), then by country alphabetically. Submit for evaluation the result grid with headers.

SELECT TOP 30 CountryName, Population FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY Population DESC, CountryName

--Problem 3.	Countries and Currency (Euro / Not Euro)
--Find all countries along with information about their currency. Display the country code, country name and information about its currency: either "Euro" or "Not Euro". Sort the results by country name alphabetically. Submit for evaluation the result grid with headers.

SELECT
 C.CountryName, 
 C.CountryCode, 
 IIF(C.CurrencyCode = 'EUR', 'Euro', 'Not Euro' ) AS [Currency] 
FROM Countries AS C
ORDER BY C.CountryName

--Problem 4.	Countries Holding 'A' 3 or More Times
--Find all countries that holds the letter 'A' in their name at least 3 times (case insensitively), sorted by ISO code. Display the country name and ISO code. Submit for evaluation the result grid with headers.

SELECT CountryName [Country Name], IsoCode [ISO Code] FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode


--Problem 5.	Peaks and Mountains
--Find all peaks along with their mountain sorted by elevation (from the highest to the lowest), then by peak name alphabetically. Display the peak name, mountain range name and elevation. Submit for evaluation the result grid with headers.

SELECT P.PeakName, M.MountainRange [Mountain], P.Elevation FROM Peaks AS P
JOIN Mountains AS M
	ON M.Id = P.MountainId
ORDER BY P.Elevation DESC, P.PeakName

--Problem 6.	Peaks with Their Mountain, Country and Continent
--Find all peaks along with their mountain, country and continent. When a mountain belongs to multiple countries, display them all. Sort the results by peak name alphabetically, then by country name alphabetically. Submit for evaluation the result grid with headers.

SELECT 
	P.PeakName,
	M.MountainRange [Mountain],
	C.CountryName,
	CON.ContinentName
	FROM Peaks AS P
JOIN Mountains AS M
	ON M.Id = P.MountainId
JOIN MountainsCountries AS MC
	ON MC.MountainId = M.ID
JOIN Countries AS C
	ON MC.CountryCode = C.CountryCode
JOIN Continents AS CON
	ON CON.ContinentCode = C.ContinentCode
ORDER BY P.PeakName, C.CountryName

--Problem 7.	* Rivers Passing through 3 or More Countries
--Find all rivers that pass through to 3 or more countries. Display the river name and the number of countries. Sort the results by river name. Submit for evaluation the result grid with headers.

SELECT
	R.RiverName [River],
	COUNT(*) [Countries Count] 
FROM Rivers AS R
JOIN CountriesRivers AS CR
	ON CR.RiverId = R.Id
JOIN Countries AS C
	ON CR.CountryCode = C.CountryCode
GROUP BY R.RiverName
HAVING COUNT(*) >= 3
ORDER BY R.RiverName

--Problem 8.	Highest, Lowest and Average Peak Elevation
--Find the highest, lowest and average peak elevation. Submit for evaluation the result grid with headers.

SELECT 
	MAX(Elevation) [MaxElevation],
	MIN(Elevation) [MinElevation],
	AVG(Elevation) [AverageElevation]
FROM Peaks

--Problem 9.	Rivers by Country
--For each country in the database, display the number of rivers passing through that country and the total length of these rivers. When a country does not have any river, display 0 as rivers count and as total length. Sort the results by rivers count (from largest to smallest), then by total length (from largest to smallest), then by country alphabetically. Submit for evaluation the result grid with headers.

SELECT
	C.CountryName,
	CON.ContinentName,
	COUNT(R.RiverName) [RiversCount],
	ISNULL(SUM(R.Length), 0) [TotalLength]
	FROM Countries AS C
LEFT JOIN Continents AS CON
	ON C.ContinentCode = CON.ContinentCode
LEFT JOIN CountriesRivers AS CR
	ON CR.CountryCode = C.CountryCode
LEFT JOIN Rivers AS R
	ON CR.RiverId = R.Id
GROUP BY C.CountryName, CON.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, C.CountryName


--Problem 10.	Count of Countries by Currency
--Find the number of countries for each currency. Display three columns: currency code, currency description and number of countries. Sort the results by number of countries (from highest to lowest), then by currency description alphabetically. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	CUR.CurrencyCode,
	CUR.Description [Currency],
	COUNT(C.CountryName) [NumberOfCountries]
FROM Currencies AS CUR 
LEFT JOIN Countries AS C
	ON CUR.CurrencyCode = C.CurrencyCode
GROUP BY CUR.CurrencyCode, CUR.Description
ORDER BY NumberOfCountries DESC, Cur.Description ASC


--Problem 11.	* Population and Area by Continent
--For each continent, display the total area and total population of all its countries. Sort the results by population from highest to lowest. Submit for evaluation the result grid with headers.

SELECT
	CON.ContinentName,
	SUM(C.AreaInSqKm) [CountriesArea],
	SUM(CAST(C.Population AS bigint)) [CountriesPopulation]
FROM Continents AS CON
JOIN Countries AS C
	ON C.ContinentCode = CON.ContinentCode
GROUP BY CON.ContinentName
ORDER BY CountriesPopulation DESC

--Problem 12.	Highest Peak and Longest River by Country
--For each country, find the elevation of the highest peak and the length of the longest river, sorted by the highest peak elevation (from highest to lowest), then by the longest river length (from longest to smallest), then by country name (alphabetically). Display NULL when no data is available in some of the columns. Submit for evaluation the result grid with headers.

SELECT 
	C.CountryName, 
	MAX(P.Elevation) [HighestPeakElevation],
	MAX(R.Length) [LongestRiverLength]
FROM Countries AS C
LEFT JOIN MountainsCountries AS MC
	ON MC.CountryCode = C.CountryCode
LEFT JOIN Mountains AS M
	ON M.ID = MC.MountainId
LEFT JOIN Peaks AS P
	ON P.MountainId = M.Id
LEFT JOIN CountriesRivers AS CR
	ON CR.CountryCode = C.CountryCode
LEFT JOIN Rivers AS R
	ON CR.RiverId = R.Id
GROUP BY C.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, C.CountryName

--Problem 13.	Mix of Peak and River Names
--Combine all peak names with all river names, so that the last letter of each peak name is the same like the first letter of its corresponding river name. Display the peak names, river names, and the obtained mix. Sort the results by the obtained mix. Submit for evaluation the result grid with headers.

SELECT  
	P.PeakName,
	R.RiverName,
	LOWER(P.PeakName + '' + SUBSTRING(R.RiverName, 2, LEN(R.RiverName)-1)) [Mix]
FROM Peaks AS P, Rivers AS R
WHERE RIGHT(P.PeakName,1) = LEFT(R.RiverName,1)
ORDER BY Mix

--Problem 14.	** Highest Peak Name and Elevation by Country
--For each country, find the name and elevation of the highest peak, along with its mountain. When no peaks are available in some country, display elevation 0, "(no highest peak)" as peak name and "(no mountain)" as mountain name. When multiple peaks in some country have the same elevation, display all of them. Sort the results by country name alphabetically, then by highest peak name alphabetically. Submit for evaluation the result grid with headers.
WITH MyView AS
(
	SELECT 
	C.CountryName [Country],
	ISNULL(P.PeakName, '(no highest peak)') as [Highest Peak Name],
	ISNULL(P.Elevation, 0) as [Highest Peak Elevation],
	IIF(p.Elevation IS NULL, '(no mountain)', M.MountainRange) AS [Mountain],
	ROW_NUMBER() OVER(PARTITION BY C.CountryName ORDER BY P.Elevation DESC) [RowNumber]
	
	FROM Countries AS C
	LEFT JOIN MountainsCountries AS MC
		ON MC.CountryCode = C.CountryCode
	LEFT JOIN Mountains AS M
		ON M.Id = MC.MountainId
	LEFT JOIN Peaks AS P
		ON P.MountainId = M.Id
	group by C.CountryName,P.PeakName,P.Elevation,M.MountainRange
)

SELECT
	MyView.Country,
	MyView.[Highest Peak Name],
	MyView.[Highest Peak Elevation],
	MyView.Mountain
FROM MyView
WHERE RowNumber = 1
ORDER BY MyView.Country, MyView.[Highest Peak Name]


