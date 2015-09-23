SELECT t.Name AS Town, d.Name AS Department, COUNT(*) AS [Employees count] FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON a.AddressID = e.AddressID
JOIN Towns t
ON t.TownID = a.TownID
GROUP BY t.Name, d.Name