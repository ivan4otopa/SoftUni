INSERT INTO Monasteries(Name, CountryCode)
VALUES('Myin-Tin-Daik', (SELECT CountryCode FROM Countries WHERE CountryName = 'Myanmar'))