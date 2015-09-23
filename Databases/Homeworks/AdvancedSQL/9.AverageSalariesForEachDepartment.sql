SELECT d.Name, AVG(e.Salary) FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY d.Name