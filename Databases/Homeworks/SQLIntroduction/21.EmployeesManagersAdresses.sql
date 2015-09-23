SELECT e.FirstName + ' ' + e.LastName AS EmployeeName, 
m.FirstName + ' ' + m.LastName AS ManagerName, a.AddressText FROM Employees E
INNER JOIN Employees m
ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses a
ON e.AddressID = a.AddressID