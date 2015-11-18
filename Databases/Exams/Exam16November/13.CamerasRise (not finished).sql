UPDATE Cameras
SET Price += r.Rise FROM 
	(SELECT AVG(c.Price) * LEN(m.Name) / 100 AS Rise, m.Id AS ManufacturerId FROM Cameras c
	JOIN Manufacturers m
	ON c.ManufacturerId = m.Id
	GROUP BY m.Name, m.Id
	HAVING m.Id IN(
		(SELECT m.Id FROM Manufacturers m
		JOIN Cameras c
		ON m.Id = c.ManufacturerId
		GROUP BY m.Id))) r
WHERE Cameras.ManufacturerId = r.ManufacturerId

SELECT p.Model, p.Price, p.ManufacturerId FROM (SELECT ROW_NUMBER() OVER(PARTITION BY m.Id ORDER BY c.Price DESC) AS [Row Number], c.Model, c.Price, m.Id AS ManufacturerId FROM Manufacturers m
JOIN Cameras c
ON m.Id = c.ManufacturerId) p
WHERE p.[Row Number] <= 3
ORDER BY p.ManufacturerId, p.Price DESC, p.Model