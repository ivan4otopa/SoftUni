SELECT 
	c1.CountryName AS [Home Team], 
	c2.CountryName AS [Away Team], 
	im.MatchDate AS [Match Date] FROM InternationalMatches im
JOIN Countries c1
ON im.HomeCountryCode = c1.CountryCode
JOIN Countries c2
ON im.AwayCountryCode = c2.CountryCode
ORDER BY im.MatchDate DESC