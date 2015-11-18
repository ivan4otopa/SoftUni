SELECT p.Title, p.Link, p.[Description], c.Name AS CategoryName, u.FullName AS Author FROM Photographs p
JOIN Users u
ON p.UserId = u.Id
JOIN Categories c
ON p.CategoryId = c.Id
WHERE p.[Description] IS NOT NULL
ORDER BY p.Title