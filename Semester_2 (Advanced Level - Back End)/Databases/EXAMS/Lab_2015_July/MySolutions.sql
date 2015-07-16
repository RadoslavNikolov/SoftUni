--Databases - Lab

--Part I – SQL Queries

--Problem 1.	All Question Titles
--Display all question titles in ascending order. Name the columns exactly like in the table below.
USE Forum


SELECT 
	Title
FROm Questions
ORDER BY Title ASC

--Problem 2.	Answers in Date Range
--Find all answers created between 15-June-2012 (00:00:00) and 21-Mart-2013 (23:59:59) sorted by date. Name the columns exactly like in the table below.

SELECT 
	Content,
	CreatedOn	
FROM Answers AS A
WHERE CreatedOn BETWEEN '15-Jun-2012 ' AND '22-Mar-2013'
ORDER BY CreatedOn


--Problem 3.	Users with "1/0" Phones
--Display usernames and last names along with a column named "Has Phone" holding "1" or "0" for all users sorted by their last name, then by id. Name the columns exactly like in the table below.

SELECT 
	Username,
	LastName,
	IIF(PhoneNumber IS NULL, 0, 1) [Has Phone]
FROM Users
ORDER BY LastName, Id

--Problem 4.	Questions with their Author
--Find all questions along with their user sorted by Id. Display the question title and author username. Name the columns exactly like in the table below.

SELECT 
	Q.Title [Question Title],
	U.Username [Author]
FROM Questions AS Q
JOIN Users AS U
	ON Q.UserId = U.Id
ORDER BY Q.Title

--Problem 5.	Answers with their Question with their Category and User 
--Find top 50 answers along with their questions, along with question category, along with answer author sorted by Category Name, then by Answer Author, then by CreatedOn. Display the answer content, created on, question title, category name and author username. Name the columns exactly like in the table below.

SELECT TOP 50
	A.Content [Answer Content],
	A.CreatedOn,
	U.Username [Answer Author],
	Q.Title [Question Title],
	C.Name [Category Name]
FROM Answers AS A
JOIN Questions AS Q
	ON A.QuestionId = Q.Id
JOIN Categories AS C
	ON Q.CategoryId = C.Id
JOIN Users AS U
	ON A.UserId = U.Id
ORDER BY [Category Name], [Answer Author], A.CreatedOn

--Problem 6.	Category with Questions
--Find all categories along with their questions sorted by category name and question title. Display the category name, question title and created on columns. Name the columns exactly like in the table below.

SELECT
	Cat.Name [Category],
	Q.Title [Question],
	Q.CreatedOn
FROM Questions AS Q
RIGHT JOIN Categories AS Cat
	ON Q.CategoryId = Cat.Id
ORDER BY Cat.Name, Q.Title


--Problem 7.	*Users without PhoneNumber and Questions
--Find all users that have no phone and no questions sorted by RegistrationDate. Show all user data. Name the columns exactly like in the table below.

SELECT
	U.Id,
	U.Username,
	U.FirstName,
	U.PhoneNumber,
	U.RegistrationDate,
	U.Email
FROM Users AS U
LEFT JOIN Questions AS Q
	ON Q.UserId = U.Id	
WHERE U.PhoneNumber IS NULL AND Q.Title IS NULL
ORDER BY U.RegistrationDate


--Problem 8.	Earliest and Latest Answer Date
--Find the dates of the earliest answer for 2012 year and the latest answer for 2014 year. Name the columns exactly like in the table below.


SELECT 
	MIN(A.CreatedOn) [MinDate],
	MAX(A.CreatedOn) [MaxDate]
FROM Answers AS A
WHERE A.CreatedOn BETWEEN '1-Jan-2012' AND '1-Jan-2015'

--Problem 9.	Find the last ten answers
--Find the last 10 answers sorted by date of creation in ascending order. Display for each ad its content, date and author. Name the columns exactly like in the table below.


SELECT TOP 10
	A.Content [Answer],
	A.CreatedOn,
	U.Username
FROM Answers AS A
JOIN Users AS U
	ON A.UserId = U.Id
ORDER BY CreatedOn DESC

--Problem 10.	Not Published Answers from the First and Last Month
--Find the answers which is hidden from the first and last month where there are any published answer, from the last year where there are any published answers. Display for each ad its answer content, question title and category name. Sort the results by category name. Name the columns exactly like in the table below.


SELECT 
	A.Content [Answer Content],
	Q.Title [Question],
	Cat.Name [Category]
FROM Answers AS A
JOIN Questions AS Q
	ON A.QuestionId = Q.Id
JOIN Categories AS Cat
	ON Q.CategoryId = Cat.Id
WHERE A.IsHidden = 1 AND YEAR(A.CreatedOn)  = YEAR((SELECT TOP 1 A.CreatedOn FROM Answers AS A ORDER BY A.CreatedOn DESC))
ORDER BY Cat.Name

--Problem 11.	Answers count for Category
--Display the count of answers in each category. Sort the results by answers count in descending order. Name the columns exactly like in the table below.

SELECT 
	Cat.Name [Category],
	COUNT(A.Id) [Answers Count]
FROM Categories AS Cat
LEFT JOIN Questions AS Q
	ON Cat.Id = Q.CategoryId
LEFT JOIN Answers AS A
	ON A.QuestionId = Q.Id
GROUP BY Cat.Name
ORDER BY [Answers Count] DESC

--Problem 12.	Answers Count by Category and Username
--Display the count of answers for category and each username. Sort the results by Answers count, then by Username. Display only non-zero counts. Display only users with phone number. Name the columns exactly like in the table below. 

SELECT
	Cat.Name [Category],
	U.Username,
	U.PhoneNumber,
	COUNT(A.Id) [Answers Count]
FROM Categories AS Cat
JOIN Questions AS Q
	ON Q.CategoryId = Cat.Id
LEFT JOIN Answers AS A
	ON A.QuestionId = Q.Id
JOIN Users  AS U
	ON A.UserId = U.Id
WHERE U.PhoneNumber IS NOT NULL
GROUP BY Cat.Name, U.Username, U.PhoneNumber
ORDER BY [Answers Count] DESC, U.Username


--Problem 13.	Answers for the users from town
USE Forum

IF OBJECT_ID('Towns') IS NOT NULL
	DROP TABLE Town


CREATE TABLE Towns (
	ID int PRIMARY KEY IDENTITY,
	Name nvarchar(50),
	)
GO

ALTER TABLE Users
ADD TownId int NULL
DEFAULT NULL
GO

ALTER TABLE Users WITH CHECK ADD CONSTRAINT FK_Users_Towns
FOREIGN KEY (TownId) REFERENCES Towns(Id)
GO

INSERT INTO Towns(Name) VALUES ('Sofia'), ('Berlin'), ('Lyon')
UPDATE Users SET TownId = (SELECT Id FROM Towns WHERE Name='Sofia')
INSERT INTO Towns VALUES
('Munich'), ('Frankfurt'), ('Varna'), ('Hamburg'), ('Paris'), ('Lom'), ('Nantes')


UPDATE Users 
SET Users.TownId = (
		SELECT T.ID FROM Towns AS T
		WHERE T.Name = 'Paris')
WHERE Users.Id IN (
	SELECT U.Id 
	FROM Users AS U
	WHERE DATENAME(dw, U.RegistrationDate) = 'Friday'
)


UPDATE Questions 
SET Title = 'Java += operator' 
WHERE Questions.Id IN (
	SELECT DISTINCT QuestionId
		FROM Answers AS A
		WHERE DATENAME(dw, A.CreatedOn) IN ('Monday','Sunday') AND MONTH(A.CreatedOn) = 2
)
GO




CREATE TABLE #AnswerIds(
 AnswerId int
)
GO

INSERT INTO #AnswerIds(AnswerId) 
	SELECT
		A.Id
	FROM Answers AS A
	JOIN Votes AS V
		ON V.AnswerId = A.Id
	GROUP BY A.Id
	HAVING SUM(V.Value) < 0
GO

DELETE Votes
WHERE AnswerId IN (SELECT * FROM #AnswerIds)
GO

DELETE Answers
WHERE Id IN (SELECT * FROM #AnswerIds)
GO

IF OBJECT_ID('#AnswerIds') IS NOT NULL
	DROP TABLE #AnswerIds



INSERT INTO Questions (Title, Content, CreatedOn, UserId, CategoryId)
VALUES (
	'Fetch NULL values in PDO query',
	'When I run the snippet, NULL values are converted to empty strings. How can fetch NULL values?',
	GETDATE(),
	(SELECT Id FROM Users WHERE Username = 'darkcat'),
	(SELECT Id FROM Categories WHERE Categories.Name = 'Databases')
)


SELECT 
	T.Name [Town],
	U.Username,
	COUNT(A.Id) [AnswersCount]
FROM Towns AS T
LEFT JOIN Users AS U
	ON U.TownId = T.ID
LEFT JOIN Answers AS A
	ON A.UserId = U.Id
GROUP BY T.Name, U.Username
ORDER BY [AnswersCount] DESC, U.Username
GO

--Problem 14.	Create a View and a Stored Function


CREATE VIEW AllQuestions AS
 SELECT 
	U.Id [UId],
	U.Username [Username],
	U.FirstName [FirstName],
	U.LastName [LastName],
	U.Email [Email],
	U.PhoneNumber [PhoneNumber],
	U.RegistrationDate [RegistrationDate],
	Q.Id [QId],
	Q.Title [Title],
	Q.Content [Content],
	Q.CategoryId [CategoryId],
	Q.UserId [UserId],
	Q.CreatedOn [CreatedOn]
 FROM Questions AS Q
 RIGHT OUTER JOIN Users AS U
	ON Q.UserId = U.Id

GO

SELECT * FROM AllQuestions

SELECT Username, Title FROM AllQuestions



IF OBJECT_ID('fn_ListUsersQuestions') IS NOT NULL
	DROP FUNCTION fn_ListUsersQuestions
GO

CREATE FUNCTION fn_ListUsersQuestions()
	RETURNS @MyTable TABLE
   (
    UserName    nvarchar(max),
    Questions   nvarchar(max)
   )
AS
BEGIN
	DECLARE usersCursor CURSOR FOR
		 SELECT UId , Username FROM AllQuestions
		 GROUP BY UId,Username
		 ORDER BY Username

		 OPEN usersCursor
		 DECLARE @userName nvarchar(max)
		 DECLARE @userId int

		 FETCH NEXT FROM usersCursor INTO @userId, @userName
		 WHILE @@FETCH_STATUS = 0
			BEGIN
				
				DECLARE @output nvarchar(MAX)
				SET @output = ''

				DECLARE titleCursor CURSOR FOR
					SELECT Title FROM AllQuestions
					WHERE UId = @userId
					ORDER BY Title DESC
				
				OPEN titleCursor
				DECLARE @title nvarchar(max)
				
				FETCH NEXT FROM titleCursor INTO @title
				WHILE @@FETCH_STATUS = 0
				BEGIN
					SET @output = @output + @title
					FETCH NEXT FROM titleCursor INTO @title
					IF @@FETCH_STATUS = 0
						SET @output = @output + ', ' 
				END
				CLOSE titleCursor
				DEALLOCATE titleCursor

				INSERT @MyTable 
				VALUES (
					@userName,
					@output
				)

				FETCH NEXT FROM usersCursor INTO @userId, @userName		
			END

			CLOSE usersCursor
			DEALLOCATE usersCursor
RETURN  	
END
GO

SELECT * FROM  dbo.fn_ListUsersQuestions()


SELECT
	A.Username [UserName],
	STUFF( ISNULL(
	(SELECT ', ' + A1.Title 
		FROM AllQuestions AS A1
		WHERE A.Username = A1.Username
		GROUP BY A1.Username, A1.Title
		ORDER BY A1.Title DESC
		FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), '' ), 1, 2, '') AS Questions
FROM AllQuestions AS A
GROUP BY A.Username
ORDER BY A.Username ASC