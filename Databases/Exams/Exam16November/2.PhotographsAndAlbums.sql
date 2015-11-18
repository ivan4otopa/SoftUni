SELECT p.Title, a.Name FROM Photographs p
JOIN AlbumsPhotographs ap
ON p.Id = ap.PhotographId
JOIN Albums a
ON ap.AlbumId = a.Id
ORDER BY a.Name, p.Title DESC