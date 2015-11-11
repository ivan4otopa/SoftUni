SELECT c.Name AS Category, q.Title AS Question, q.CreatedOn FROM Categories c
LEFT JOIN Questions q
ON c.Id = q.CategoryId
ORDER BY c.Name, q.Title