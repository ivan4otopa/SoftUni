CREATE TABLE WorkHours
(
	Id int IDENTITY PRIMARY KEY,
	Date datetime NOT NULL,
	Task nvarchar(100) NOT NULL,
	Hours int NOT NULL,
	Comment nvarchar(100) NOT NULL,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeID)
)