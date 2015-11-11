SELECT a.Title, c.Name AS CategoryName, t.Name AS TownName, ast.Status FROM Ads a
LEFT JOIN Categories c
ON a.CategoryId = c.Id
LEFT JOIN Towns t
ON a.TownId = t.Id
LEFT JOIN AdStatuses ast
ON a.StatusId = ast.Id