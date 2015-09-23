SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary <
	(SELECT MIN(Salary) + MIN(Salary) * 10 / 100 FROM Employees)