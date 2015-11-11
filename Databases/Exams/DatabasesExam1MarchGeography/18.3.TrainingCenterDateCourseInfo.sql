SELECT tc.name AS `training center`, 
	ct.start_date AS `start date`, 
    c.name AS `course name`, 
    c.description AS `more info` 
    FROM `courses_timetable` ct
JOIN `courses` c
ON ct.course_id = c.id
JOIN `training_centers` tc
ON ct.training_center_id = tc.id
ORDER BY ct.start_date, ct.id;