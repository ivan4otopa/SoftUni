SELECT 
	(SELECT MIN(CreatedOn) FROM Answers
	WHERE YEAR(CreatedOn) = '2012') AS MinDate,
	(SELECT MAX(CreatedOn) FROM Answers
	WHERE YEAR(CreatedOn) = '2014') AS MaxDate