UPDATE Ads
SET TownId = 
	(SELECT Id FROM Towns
	WHERE Name = 'Paris')
WHERE DATENAME(WEEKDAY, Date) = 'Friday'