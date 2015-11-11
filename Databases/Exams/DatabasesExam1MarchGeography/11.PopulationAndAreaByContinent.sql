SELECT con.ContinentName, 
	SUM(CAST(cou.AreaInSqKm AS bigint)) AS CountriesArea, 
	SUM(CAST(cou.[Population] AS bigint)) AS CountriesPopulation FROM Continents con
JOIN Countries cou
ON con.ContinentCode = cou.ContinentCode
GROUP BY con.ContinentName
ORDER BY CountriesPopulation DESC