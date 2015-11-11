SELECT m.Name AS Monastery, c.CountryName AS Country FROM Countries c
JOIN Monasteries m
ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted IS NULL
ORDER BY Monastery