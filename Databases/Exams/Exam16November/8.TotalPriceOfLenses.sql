SELECT m.Name, SUM(l.Price) AS [Total Price] FROM Lenses l
JOIN Manufacturers m
ON l.ManufacturerId = m.Id
GROUP BY m.Name
ORDER BY m.Name