INSERT INTO WorkHours
VALUES
	(2015-06-28, 'Create table Students', 3, 'No', 1),
	(2015-06-28, 'Insert a student', 1, 'Make me', 2)

UPDATE WorkHours
SET Comment = 'Ok'
WHERE Id = 1

DELETE FROM WorkHours
WHERE Id = 2