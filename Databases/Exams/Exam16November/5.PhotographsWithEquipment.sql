SELECT p.Title, c.Model AS CameraModel, l.Model AS LensModel FROM Photographs p
JOIN Equipments e
ON p.EquipmentId = e.Id
JOIN Cameras c
ON e.CameraId = c.Id
JOIN Lenses l
ON e.LensId = l.Id
ORDER BY p.Title