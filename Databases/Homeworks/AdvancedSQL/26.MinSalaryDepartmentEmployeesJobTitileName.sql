SELECT d.Name AS Department, e.JobTitle, e.FirstName, MIN(e.Salary) AS [Min Salary]  FROM Employees e
JOIN Departments d
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName