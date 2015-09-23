SELECT e.Town, e.[Employees count] AS [Number of employees] FROM 
	(SELECT t.Name AS Town, COUNT(*) AS [Employees count] FROM Employees e
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	GROUP BY t.Name) e
WHERE e.[Employees count] = (SELECT MAX(ec.[Employees count]) FROM 
	(SELECT t.Name AS Town, COUNT(*) AS [Employees count] FROM Employees e
	JOIN Addresses a
	ON a.AddressID = e.AddressID
	JOIN Towns t
	ON t.TownID = a.TownID
	GROUP BY t.Name) ec)