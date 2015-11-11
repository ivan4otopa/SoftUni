SELECT u.EmailProvider AS [Email Provider], COUNT(u.Username) AS [Number Of Users]
FROM (SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS EmailProvider, Username FROM Users) u
GROUP BY u.EmailProvider
ORDER BY [Number Of Users] DESC, [Email Provider]