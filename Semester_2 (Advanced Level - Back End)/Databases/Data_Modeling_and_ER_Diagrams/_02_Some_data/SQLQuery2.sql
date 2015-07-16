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
