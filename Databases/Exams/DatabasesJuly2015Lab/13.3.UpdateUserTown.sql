UPDATE Users
SET TownId = (SELECT Id FROM Towns WHERE Name = 'Paris')
WHERE DATENAME(dw, RegistrationDate) = 'Friday'