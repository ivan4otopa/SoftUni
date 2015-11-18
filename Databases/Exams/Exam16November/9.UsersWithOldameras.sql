SELECT u.FullName, m.Name AS Manufacturer, c.Model AS [Camera Model], c.Megapixels FROM Users u
JOIN Equipments e
ON u.EquipmentId = e.Id
JOIN Cameras c
ON e.CameraId = c.Id
JOIN Manufacturers m
ON c.ManufacturerId = m.Id
WHERE c.[Year] < 2015
ORDER BY u.FullName