SELECT ma.Town, COUNT(*) FROM
	(SELECT DISTINCT e.EmployeeID, t.Name AS Town FROM Employees e
	JOIN Employees m
	ON m.ManagerID = e.EmployeeID
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID) ma
GROUP BY ma.Town