SELECT con.ContinentName, cou.CountryName, COUNT(m.Name) AS MonasteriesCount FROM Countries cou
LEFT JOIN Monasteries m
ON cou.CountryCode = m.CountryCode
JOIN Continents con
ON cou.ContinentCode = con.ContinentCode
WHERE cou.IsDeleted IS NULL
GROUP BY cou.CountryName, con.ContinentName
ORDER BY MonasteriesCount DESC, cou.CountryName