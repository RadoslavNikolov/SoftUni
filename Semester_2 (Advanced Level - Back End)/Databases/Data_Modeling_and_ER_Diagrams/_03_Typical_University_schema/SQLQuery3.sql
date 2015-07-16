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