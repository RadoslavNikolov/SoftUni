--Part I – SQL Queries


--Problem 1.	All Ad Titles
SELECT
	Title
FROM Ads
ORDER BY Title ASC

--Problem 2.	Ads in Date Range
--Find all ads created between 26-December-2014 (00:00:00) and 1-January-2015 (23:59:59) sorted by date. Submit for evaluation the result grid with headers.

SELECT
	Title,
	[Date]
FROM Ads
WHERE [Date] BETWEEN CAST('26-Dec-2014' AS datetime) AND CAST('2-Jan-2015' AS datetime) 
ORDER BY [Date] ASC

--Problem 3.	* Ads with "Yes/No" Images
--Display all ad titles and dates along with a column named "Has Image" holding "yes" or "no" for all ads sorted by their Id. Submit for evaluation the result grid with headers.

SELECT
	Title,
	Date,
	IIF(ImageDataURL IS NULL, 'no', 'yes') [Has Image]
FROM Ads
ORDER BY Id ASC

--Problem 4.	Ads without Town, Category or Image
--Find all ads that have no town or no category or no image sorted by Id. Show all their data. Submit for evaluation the result grid with headers.

SELECT *
FROM Ads
WHERE TownId IS NULL OR CategoryId IS NULL OR ImageDataURL IS NULL
ORDER BY Id

--Problem 5.	Ads with Their Town
--Find all ads along with their towns sorted by Id. Display the ad title and town (even when there is no town). Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT
	Title,
	T.Name [Town]
FROM Ads AS A
LEFT JOIN Towns AS T
	ON A.TownId = T.Id
ORDER BY A.Id ASC

--Problem 6.	Ads with Their Category, Town and Status
--Find all ads along with their categories, towns and statuses sorted by Id. Display the ad title, category name, town name and status. Include all ads without town or category or status. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	Title,
	C.Name [CategoryName],
	T.Name [TownName],
	AdS.Status
FROM Ads AS A
LEFT JOIN Towns AS T
	ON A.TownId = T.Id
LEFT JOIN Categories AS C
	ON C.Id = A.CategoryId
LEFT JOIN AdStatuses As AdS
	ON A.StatusId = AdS.Id
ORDER BY A.Id ASC

--Problem 7.	Filtered Ads with Category, Town and Status
--Find all Published ads from Sofia, Blagoevgrad or Stara Zagora, along with their category, town and status sorted by title. Display the ad title, category name, town name and status. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	Title,
	C.Name [CategoryName],
	T.Name [TownName],
	AdS.Status
FROM Ads AS A
LEFT JOIN Towns AS T
	ON A.TownId = T.Id
LEFT JOIN Categories AS C
	ON C.Id = A.CategoryId
LEFT JOIN AdStatuses As AdS
	ON A.StatusId = AdS.Id
WHERE T.Name IN ('Sofia', 'Blagoevgrad', 'Stara Zagora') AND AdS.Status = 'Published'
ORDER BY Title ASC

--Problem 8.	Earliest and Latest Ads
--Find the dates of the earliest and the latest ads. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT
	MIN(Date) [MinDate],
	MAX(Date) [MaxDate]
FROM Ads


--Problem 9.	Latest 10 Ads
--Find the latest 10 ads sorted by date in descending order. Display for each ad its title, date and status. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT TOP 10
	Title,
	Date [Date],
	AdS.Status
FROM Ads AS A
LEFT JOIN AdStatuses As AdS
	ON A.StatusId = AdS.Id
ORDER BY [Date] DESC


--Problem 10.	Not Published Ads from the First Month
--Find all not published ads, created in the same month and year like the earliest ad. Display for each ad its id, title, date and status. Sort the results by Id. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT
	A.Id,
	Title,
	Date,
	Status
FROM Ads AS A
LEFT JOIN AdStatuses As AdS
	ON A.StatusId = AdS.Id
WHERE Status != 'published' AND
YEAR(Date) = YEAR((SELECT MIN(Date) FROM Ads)) AND
MONTH(Date) = MONTH((SELECT MIN(DATE) FROM Ads))
ORDER BY A.Id



--Problem 11.	Ads by Status
--Display the count of ads in each status. Sort the results by status. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.


SELECT
	Status,
	COUNT(A.Id) [Count]
FROM Ads AS A
LEFT JOIN AdStatuses As AdS
	ON A.StatusId = AdS.Id
GROUP BY Status
ORDER By Status


--Problem 12.	Ads by Town and Status
--Display the count of ads for each town and each status. Sort the results by town, then by status. Display only non-zero counts. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT 
	T.Name [Town Name],
	Status,
	COUNT(T.Id) [Count]
FROM Ads AS A
LEFT JOIN Towns AS T
	ON A.TownId = T.Id
LEFT JOIN AdStatuses As AdS
	ON A.StatusId = AdS.Id
GROUP BY T.Name, Status
HAVING COUNT(T.Id) > 0
ORDER BY [Town Name], Status

--Problem 13.	* Ads by Users
--Find the count of ads for each user. Display the username, ads count and "yes" or "no" depending on whether the user belongs to the role "Administrator". Sort the results by username. Display all users, including the users who have no ads. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.


SELECT 
	U.UserName [UserName],
	COUNT(A.Id) [AdsCount],
	IIF(admins.UserName IS NULL, 'no', 'yes') [IsAdministrator]
FROM AspNetUsers AS U
LEFT JOIN Ads AS A
	ON A.OwnerId = U.Id
LEFT JOIN (
	SELECT DISTINCT U1.UserName
	FROM AspNetUsers AS U1
	LEFT JOIN AspNetUserRoles AS UR
		ON UR.UserId = U1.Id
	LEFT JOIN AspNetRoles AS NR
		ON UR.RoleId = NR.Id
	WHERE NR.Name = 'Administrator'
) AS admins
	ON U.UserName = admins.UserName
GROUP BY U.UserName, admins.UserName
ORDER BY U.UserName


--Problem 14.	Ads by Town
--Find the count of ads for each town. Display the ads count and town name or "(no town)" for the ads without a town. Display only the towns, which hold 2 or 3 ads. Sort the results by town name. Name the columns exactly like in the table below. Submit for evaluation the result grid with headers.

SELECT
	COUNT(A.Id) [AdsCount],
	ISNULL(T.Name, '(no town)') [Town]
FROM Ads AS A
LEFT JOIN Towns AS T
	ON A.TownId = T.Id
GROUP BY T.Name
HAVING COUNT(A.Id) BETWEEN 2 AND 3
ORDER BY T.Name


--Problem 15.	Pairs of Dates within 12 Hours
--Consider the dates of the ads. Find among them all pairs of different dates, such that the second date is no later than 12 hours after the first date. Sort the dates in increasing order by the first date, then by the second date. Name the columns exactly like in the table below. Submit for evaluation the result grid with header.

SELECT 
	A1.Date [FirstDate],
	A2.Date [SecondDate]
FROM Ads AS A1, Ads AS A2
WHERE A2.Date > A1.Date AND
DATEADD(hour,12,A1.Date) > A2.Date
ORDER BY A1.Date, A2.Date
