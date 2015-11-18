SELECT TOP 5 p.Title, c.Name AS [Category Name], ca.Model, m.Name AS [Manufacturer Name], ca.Megapixels, ca.Price FROM Photographs p
JOIN Categories c
ON p.CategoryId = c.Id
JOIN Equipments e
ON p.EquipmentId = e.Id
JOIN Cameras ca
ON e.CameraId = ca.Id
JOIN Manufacturers m
ON ca.ManufacturerId = m.Id
WHERE p.Title NOT LIKE 'I dont want you to go!'
ORDER BY ca.Price DESC, p.Title