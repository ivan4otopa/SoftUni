SELECT e.FirstName + ' ' + e.LastName AS Name, e.HireDate, d.Name FROM Employees e
INNER JOIN Departments d
ON (d.Name = 'Sales' OR d.Name = 'Finance') AND e.DepartmentID = d.DepartmentID AND 
(e.HireDate > '1995-01-01 00:00:00' AND e.HireDate < '2005-12-31 00:00:00')