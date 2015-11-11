SELECT cou.CountryName, 
	con.ContinentName, 
	ISNULL(COUNT(r.RiverName), 0) AS RiversCount, ISNULL(SUM(r.Length), 0) AS TotalLength 
	FROM Countries cou
LEFT JOIN CountriesRivers cr
ON cou.CountryCode = cr.CountryCode
LEFT JOIN Rivers r
ON cr.RiverId = r.Id
LEFT JOIN Continents con
ON cou.ContinentCode = con.ContinentCode
GROUP BY cou.CountryName, con.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, cou.CountryName