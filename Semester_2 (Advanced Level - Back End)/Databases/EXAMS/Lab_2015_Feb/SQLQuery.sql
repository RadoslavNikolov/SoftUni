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


