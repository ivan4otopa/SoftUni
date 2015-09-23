CREATE DATABASE DatabasePerformance

USE DatabasePerformance

CREATE TABLE DateAndText
(
	[Date] date NOT NULL,
	[Text] nvarchar(MAX) NOT NULL
)

BEGIN TRAN
DECLARE @count bigint = 0
WHILE @count < 1000000
BEGIN
	INSERT INTO DateAndText([Date], [Text])
	VALUES(DATEADD(day, @count, GETDATE()), CAST(@count as nvarchar(MAX)))
	SET @count += 1
END
COMMIT TRAN

SELECT * FROM DateAndText
WHERE [Date] > '2019-07-06'
ORDER BY [Date] DESC