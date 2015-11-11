SELECT t.Name AS Town, c.Name AS Country, COUNT(a.Title) AS AdsCount FROM Ads a
FULL JOIN Towns t
ON a.TownId = t.Id
FULL JOIN Countries c
ON t.CountryId = c.Id
GROUP BY t.Name, c.Name
ORDER BY t.Name