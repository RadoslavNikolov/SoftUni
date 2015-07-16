--Homework: Data Modeling and E/R Diagrams


--Problem 2.	Fill some sample data in the tables with SSMS.

SELECT U.UserName[Answer From], U.FirstName,U.LastName, A.Content[Answer content],Q.Decription[Question content],
		Q.Title,U1.UserName[Question From],U1.FirstName, U1.LastName,Cat.Title[Category]
FROM Answers AS A
JOIN Users AS U
ON A.UserID = U.ID
JOIN Questions as Q
On A.QuestionID = Q.ID
JOIN Users as U1
ON Q.UserID=U1.ID
JOIN Categories as Cat
ON Q.CategoryID=Cat.ID
WHERE A.UserID = 2
OR A.UserID = 1

--Problem 3.	Create a data model for typical university in SQL Server.

SELECT S.ID, S.FirstName[Student first name], S.LastName[Student last name], S.FacultyNumber, C.Name[Participate in],
		 C.Description[Course Description], Dep.Name[Department nama], Pr.ID[Pr.ID], Pr.Name[Professor name], T.Name[Title], 
		 T.Description, F.Name[Faculty name]
FROM Students as S
JOIN StudentsCourses AS SC
ON S.ID=SC.StudentID
JOIN Courses AS C
ON SC.CourseID=C.ID	
JOIN Professors AS Pr
ON C.ProfessorID=Pr.ID	
JOIN ProfessorsTitles As PrT
ON Pr.ID=PrT.ProfessorID
JOIN Title AS T
ON PrT.TitleID=T.ID
JOIN Departments as Dep
ON Pr.DepartmentID=Dep.ID
JOIN Faculties as F
ON Dep.FacultyID=F.ID


--Problem 4.	Create the same data model in MySQL.

-- MySQL Workbench Synchronization
-- Generated: 2015-06-24 14:14
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: isrmn

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

ALTER TABLE `typical_uni`.`Students` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`ID`)  COMMENT '';

ALTER TABLE `typical_uni`.`Courses` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`ID`)  COMMENT '';

ALTER TABLE `typical_uni`.`Departments` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`ID`)  COMMENT '';

ALTER TABLE `typical_uni`.`Professors` 
DROP PRIMARY KEY,
ADD PRIMARY KEY (`ID`)  COMMENT '';


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;