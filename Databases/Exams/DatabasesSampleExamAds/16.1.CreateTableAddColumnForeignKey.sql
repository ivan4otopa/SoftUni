CREATE TABLE Countries
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(25) NOT NULL
)

ALTER TABLE Towns
ADD CountryId int

ALTER TABLE Towns
ADD CONSTRAINT FK_Towns_Countries
FOREIGN KEY (CountryId) REFERENCES Countries(Id)
