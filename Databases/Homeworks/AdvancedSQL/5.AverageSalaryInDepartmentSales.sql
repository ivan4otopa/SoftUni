SELECT AVG(Salary) AS [Average Salaries for Sales Department] FROM Employees
WHERE DepartmentID =
	(SELECT DepartmentID FROM Departments
	WHERE Name = 'Sales')