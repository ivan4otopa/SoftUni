CREATE TABLE FriendlyMatches
(
	Id int IDENTITY PRIMARY KEY,
	HomeTeamId int NOT NULL,
	AwayTeamId int NOT NULL,
	MatchDate datetime NOT NULL
)

ALTER TABLE FriendlyMatches
ADD CONSTRAINT FK_FriendlyMatchesHome_Teams FOREIGN KEY (HomeTeamId) REFERENCES Teams(Id)

ALTER TABLE FriendlyMatches
ADD CONSTRAINT FK_FriendlyMatchesAway_Teams FOREIGN KEY (AwayTeamId) REFERENCES Teams(Id)