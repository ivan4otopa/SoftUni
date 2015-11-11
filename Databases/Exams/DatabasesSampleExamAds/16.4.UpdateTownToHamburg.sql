UPDATE Ads
SET TownId = 
	(SELECT Id FROM Towns
	WHERE Name = 'Hamburg')
WHERE DATENAME(WEEKDAY, Date) = 'Thursday'