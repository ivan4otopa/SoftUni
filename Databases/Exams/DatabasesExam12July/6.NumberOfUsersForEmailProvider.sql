SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider], COUNT(Username) AS [Number Of Users] FROM Users
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
ORDER BY COUNT(Username) DESC, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))