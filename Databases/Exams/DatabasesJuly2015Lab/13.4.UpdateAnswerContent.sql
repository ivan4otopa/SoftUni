UPDATE Answers
SET Content = 'Java += operator'
WHERE DATENAME(dw, CreatedOn) IN ('Monday', 'Sunday') AND MONTH(CreatedOn) = 2