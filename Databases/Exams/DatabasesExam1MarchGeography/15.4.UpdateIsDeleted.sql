UPDATE Countries
SET IsDeleted = 1
WHERE CountryName IN
	(SELECT c.CountryName FROM Countries c
	JOIN CountriesRivers cr
	ON c.CountryCode = cr.CountryCode
	JOIN Rivers r
	ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	HAVING COUNT(r.RiverName) > 3)