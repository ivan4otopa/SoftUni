DECLARE @maxYear int = (SELECT YEAR(MAX(CreatedOn)) FROM Answers)
DECLARE @minMonth int = (SELECT MONTH(MIN(CreatedOn)) FROM Answers WHERE YEAR(CreatedOn) = @maxYear)
DECLARE @maxMonth int = (SELECT MONTH(MAX(CreatedOn)) FROM Answers WHERE YEAR(CreatedOn) = @maxYear)
SELECT a.Content AS [Answer Content], q.Title AS Question, c.Name AS Category FROM Answers a
JOIN Questions q
ON a.QuestionId = q.Id
JOIN Categories c
ON q.CategoryId = c.Id
WHERE 
	IsHidden = 1 AND 
	YEAR(a.CreatedOn) = @maxYear AND 
	(MONTH(a.CreatedOn) = @minMonth OR MONTH(a.CreatedOn) = @maxMonth)
ORDER BY c.Name