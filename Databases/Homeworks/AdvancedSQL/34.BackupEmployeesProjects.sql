SELECT EmployeeID, ProjectID 
INTO #EmployeesProjects
FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects
(
	EmployeeID int FOREIGN KEY REFERENCES Employees(EmployeeID) NOT NULL,
	ProjectID int FOREIGN KEY REFERENCES Projects(ProjectID) NOT NULL
)

SELECT * FROM EmployeesProjects

INSERT INTO EmployeesProjects 
SELECT EmployeeID, ProjectID
FROM #EmployeesProjects