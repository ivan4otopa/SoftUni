SELECT c.CurrencyCode, 
	c.[Description] AS Currency, 
	COUNT(co.CountryName) AS NumberOfCountries FROM Currencies c
LEFT JOIN Countries co
ON c.CurrencyCode = co.CurrencyCode
GROUP BY c.CurrencyCode, c.[Description]
ORDER BY NumberOfCountries DESC, c.[Description]