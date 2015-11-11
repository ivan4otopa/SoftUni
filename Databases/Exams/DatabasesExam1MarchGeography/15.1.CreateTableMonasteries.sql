CREATE TABLE Monasteries
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(50) NOT NULL,
	CountryCode char(2) NOT NULL
)

ALTER TABLE Monasteries
ADD CONSTRAINT FK_Monasteries_Countries
FOREIGN KEY (CountryCode) REFERENCES Countries (CountryCode)