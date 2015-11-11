SELECT r.RiverName AS River, COUNT(c.CountryName) AS [Countries Count] FROM Rivers r
JOIN CountriesRivers cr
ON r.Id = cr.RiverId
JOIN Countries c
ON cr.CountryCode = c.CountryCode
GROUP BY r.RiverName
HAVING COUNT(c.CountryName) >= 3