CREATE TABLE Users
(
	Id int IDENTITY PRIMARY KEY,
	Username nvarchar(50) not null UNIQUE,
	Password nvarchar(50) not null  CHECK (LEN(Password) > 5),
	FullName nvarchar(60) null,
	LastLogin datetime not null,
)