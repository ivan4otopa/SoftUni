SELECT TOP 10 a.Title, a.Date, ast.Status FROM Ads a
JOIN AdStatuses ast
ON a.StatusId = ast.Id
ORDER BY a.Date DESC