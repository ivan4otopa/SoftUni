SELECT m.Name, c.Model, SUM(c.Price) AS Price FROM Manufacturers m
JOIN Cameras c
ON m.Id = c.ManufacturerId
GROUP BY m.Name, c.Model
HAVING SUM(c.Price) > 
	(SELECT AVG(Price) FROM Cameras)
ORDER BY SUM(c.Price) DESC, c.Model