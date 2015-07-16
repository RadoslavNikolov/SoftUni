CREATE TABLE Accounts (
	ID int IDENTITY(1,1),
	PersonID int NOT NULL,
	Balance money,
	CONSTRAINT PK_Accounts PRIMARY KEY(ID),
	CONSTRAINT FK_Persons_Accounts FOREIGN KEY(PersonID) REFERENCES Persons(ID)
)