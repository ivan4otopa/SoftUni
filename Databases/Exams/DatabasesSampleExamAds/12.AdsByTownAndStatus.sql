SELECT t.Name [Town Name], ast.Status, COUNT(a.Title) AS [Count] FROM Ads a
JOIN Towns t
ON a.TownId = t.Id
JOIN AdStatuses ast
ON a.StatusId = ast.Id
GROUP BY ast.Status, t.Name