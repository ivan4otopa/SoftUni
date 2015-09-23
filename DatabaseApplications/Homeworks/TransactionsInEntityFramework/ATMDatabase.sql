CREATE DATABASE ATM

USE ATM

CREATE TABLE CardAccounts
(
	Id int IDENTITY PRIMARY KEY,
	CardNumber char(10),
	CardPIN char(4),
	CardCash money
)

INSERT INTO CardAccounts(CardNumber, CardPIN, CardCash)
VALUES
	('1234567891', '2345', 20),
	('6789123456', '7891', 100),
	('2345678912', '3456', 120),
	('7891234567', '8912', 200),
	('3456789123', '4567', 220),
	('8912345678', '9123', 300)