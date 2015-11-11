SELECT a.Title, c.Name AS CategoryName, t.Name AS TownName, ast.Status FROM Ads a
JOIN Categories c
ON a.CategoryId = c.Id
JOIN Towns t
ON a.TownId = t.Id AND t.Name IN('Sofia', 'Blagoevgrad', 'Stara Zagora')
JOIN AdStatuses ast
ON a.StatusId = ast.Id AND ast.Status = 'Published'
ORDER BY a.Title