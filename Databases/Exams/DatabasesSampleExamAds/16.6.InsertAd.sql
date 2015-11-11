INSERT INTO Ads(Title, Text, Date, OwnerId, StatusId)
VALUES('Free Book', 'Free C# Book', GETDATE(), 
	(SELECT Id FROM AspNetUsers
	WHERE UserName = 'nakov'),
	(SELECT Id FROM AdStatuses
	WHERE Status = 'Waiting Approval'))