SELECT e.FirstName + ' ' + e.LastName AS EmployeeName,
m.FirstName + ' ' + m.LastName AS ManagerName FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID