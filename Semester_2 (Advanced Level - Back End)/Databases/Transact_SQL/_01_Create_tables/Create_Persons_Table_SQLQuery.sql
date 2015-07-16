CREATE TABLE Persons (
	ID int IDENTITY(1,1),
	FirstName nvarchar(20) NOT NULL,
	LastName nvarchar(20) NOT NULL,
	SSN varchar(10),
	CONSTRAINT PK_Persons PRIMARY KEY(ID)
)