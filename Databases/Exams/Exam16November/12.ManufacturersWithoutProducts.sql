SELECT m.Name FROM Manufacturers m
LEFT JOIN Cameras c
ON m.Id = c.ManufacturerId
LEFT JOIN Lenses l
ON m.Id = l.ManufacturerId
GROUP  BY m.Name, c.Model, l.Model
HAVING c.Model IS NULL AND l.Model IS NULL
ORDER BY m.Name