CREATE INDEX DateSearch
ON DateAndText ([Date])

SELECT * FROM DateAndText
WHERE [Date] > '2019-07-06'
ORDER BY [Date] DESC