INSERT INTO Monasteries(Name, CountryCode)
VALUES('Hanga Abbey', (SELECT CountryCode FROM Countries WHERE CountryName = 'Tanzania'))