SELECT p.PeakName, m.MountainRange AS Mountain, cou.CountryName, con.ContinentName FROM Peaks p
JOIN Mountains m
ON p.MountainId = m.Id
JOIN MountainsCountries mc
ON m.Id = mc.MountainId
JOIN Countries cou
ON mc.CountryCode = cou.CountryCode
JOIN Continents con
ON cou.ContinentCode = con.ContinentCode
ORDER BY p.PeakName, cou.CountryName