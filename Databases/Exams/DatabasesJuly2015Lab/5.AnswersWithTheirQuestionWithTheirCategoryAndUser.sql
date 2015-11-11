SELECT TOP 50 
	a.Content AS [Answer Content],
	a.CreatedOn,
	u.Username AS [Answer Author],
	q.Title AS [Question Title],
	c.Name AS [Category Name]
	FROM Answers a
JOIN Questions q
ON a.QuestionId = q.Id
JOIN Categories c
ON q.CategoryId = c.Id
JOIN Users u
ON a.UserId = u.Id
ORDER BY c.Name, u.Username, a.CreatedOn