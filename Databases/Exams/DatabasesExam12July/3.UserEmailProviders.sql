SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider] FROM Users
ORDER BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)), Username 