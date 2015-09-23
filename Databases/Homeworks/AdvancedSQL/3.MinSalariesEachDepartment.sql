SELECT e.FirstName + ' ' + e.LastName AS FullName, e.Salary, d.Name FROM Employees e, Departments d
WHERE e.Salary = 
	(SELECT MIN(em.Salary) FROM Employees em
	WHERE em.DepartmentID = d.DepartmentID)