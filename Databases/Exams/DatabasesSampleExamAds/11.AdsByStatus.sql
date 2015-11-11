SELECT ast.Status, COUNT(a.Title) AS [Count] FROM Ads a
JOIN AdStatuses ast
ON a.StatusId = ast.Id
GROUP BY ast.Status