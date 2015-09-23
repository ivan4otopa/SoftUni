CREATE TABLE Groups
(
	Id int IDENTITY PRIMARY KEY,
	Name nvarchar(50) not null UNIQUE
)