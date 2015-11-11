CREATE VIEW AllAds AS
SELECT a.Id, a.Title, u.UserName AS Author, a.Date, t.Name AS Town, c.Name AS Category, ast.Status FROM Ads a
LEFT JOIN AspNetUsers u 
ON a.OwnerId = u.Id
LEFT JOIN Towns t 
ON a.TownId = t.Id
LEFT JOIN Categories c
ON a.CategoryId = c.Id
LEFT JOIN AdStatuses ast
ON a.StatusId = ast.Id