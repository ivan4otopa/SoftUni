SELECT COUNT(a.Title) AS AdsCount, 
	(CASE WHEN t.Name IS NULL THEN '(no town)' ELSE t.Name END) AS Town FROM Ads a
LEFT JOIN Towns t
ON a.TownId = t.Id
GROUP BY t.Name
HAVING COUNT(a.Title) = 3 OR COUNT(a.Title) = 2