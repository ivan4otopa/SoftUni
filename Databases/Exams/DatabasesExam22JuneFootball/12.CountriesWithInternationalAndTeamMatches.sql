SELECT 
	c.CountryName [Country Name], 
	COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) AS [International Matches],
	COUNT(DISTINCT tm.Id) AS [Team Matches] 
	FROM Countries c
LEFT JOIN InternationalMatches im1
ON c.CountryCode = im1.HomeCountryCode
LEFT JOIN InternationalMatches im2
ON c.CountryCode = im2.AwayCountryCode
LEFT JOIN Leagues l
ON c.CountryCode = l.CountryCode
LEFT JOIN TeamMatches tm
ON l.Id = tm.LeagueId
GROUP BY c.CountryName
HAVING COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) > 0 OR COUNT(DISTINCT tm.Id) > 0
ORDER BY [International Matches] DESC, [Team Matches] DESC, c.CountryName