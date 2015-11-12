SELECT i.Name AS Item, CONVERT(NUMERIC(9,2),REPLACE(i.Price, ',', '.')) AS Price, i.MinLevel, gt.Name AS [Forbidden Game Type] FROM Items i
LEFT JOIN GameTypeForbiddenItems gtfi
ON i.Id = gtfi.ItemId
LEFT JOIN GameTypes gt
ON gtfi.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name