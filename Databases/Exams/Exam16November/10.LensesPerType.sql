SELECT [Type], COUNT(Id) AS [Count] FROM Lenses
GROUP BY [Type]
ORDER BY COUNT(Id) DESC, [Type]