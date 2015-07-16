SELECT Students.Name, Students.Age, Students.PhoneNumber, Classes.Name, Classes.MaxStudents
FROM Students
JOIN StudentsClasses
ON Students.ID=StudentsClasses.StudentID
Join Classes
ON StudentsClasses.ClassID=Classes.ID
WHERE Students.PhoneNumber IS NOT NULL
AND Students.Age > 22
AND Students.Age < 32
ORDER BY Students.Name ASC, Classes.MaxStudents DESC

