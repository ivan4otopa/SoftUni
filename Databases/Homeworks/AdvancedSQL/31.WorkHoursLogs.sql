CREATE TABLE WorkHoursLogs
(
	Id int IDENTITY PRIMARY KEY,
	Date datetime NOT NULL,
	Task nvarchar(100) NOT NULL,
	Hours int NOT NULL,
	Comment nvarchar(100) NOT NULL,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeID)
)

CREATE TRIGGER WorkHoursUpdate
ON WorkHours AFTER  UPDATE, DELETE
AS
	INSERT INTO WorkHoursLogs(Id, Date, Task, Hours, Comment, EmployeeId)
	SELECT d.Id, d.Date, d.Task, d.Hours, d.Comment, d.EmployeeId FROM DELETED d

CREATE TRIGGER WorkHoursInsert ON WorkHours
FOR INSERT AS
BEGIN
	INSERT INTO WorkHoursLogs
	(
		Id, 
		Date, 
		Task, 
		Hours, 
		Comment, 
		EmployeeId
	)
	SELECT Id, Date, Task, Hours, Comment, EmployeeId FROM INSERTED
END