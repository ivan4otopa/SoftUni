SELECT c.CountryName AS Country, 
	p.PeakName AS [Highest Peak Name], 
	ISNULL(p.Elevation, 0) AS [Highest Peak Elevation], 
	ISNULL(m.MountainRange, '(no mountain)') AS Mountain FROM Countries c
LEFT JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
ON mc.MountainId = m.Id
LEFT JOIN Peaks p
ON m.Id = p.MountainId
WHERE p.Elevation = 
	(SELECT MAX(p.Elevation)
	FROM MountainsCountries mc
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	WHERE c.CountryCode = mc.CountryCode)
UNION
SELECT c.CountryName AS Country, 
	'(no highest peak)' AS [Highest Peak Name], 
	0 AS [Highest Peak Elevation], 
	'(no mountain)' AS Mountain FROM Countries c
LEFT JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
ON mc.MountainId = m.Id
LEFT JOIN Peaks p
ON m.Id = p.MountainId
WHERE
	(SELECT MAX(p.Elevation)
	FROM MountainsCountries mc
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id
	WHERE c.CountryCode = mc.CountryCode) IS NULL
ORDER BY c.CountryName, [Highest Peak Name]