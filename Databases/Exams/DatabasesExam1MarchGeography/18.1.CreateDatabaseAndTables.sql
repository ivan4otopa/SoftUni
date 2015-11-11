CREATE DATABASE `trainings` CHARACTER SET utf8 COLLATE utf8_unicode_ci;

CREATE TABLE `courses`
(
	`id` int(11) NOT NULL AUTO_INCREMENT,
    `name` nvarchar(40) NOT NULL,
    `description` text,
    PRIMARY KEY (`id`)
);

CREATE TABLE `training_centers`
(
	`id` int(11) NOT NULL AUTO_INCREMENT,
    `name` nvarchar(40) NOT NULL,
    `description` text,
    `url` nvarchar(2083),
    PRIMARY KEY (`id`)
);

CREATE TABLE `courses_timetable`
(
	`id` int(11) NOT NULL AUTO_INCREMENT,
    `course_id` int(11) NOT NULL,
    `training_center_id` int(11) NOT NULL,
    `start_date` date NOT NULL,
    CONSTRAINT `fk_courses_timetable_courses` FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`),
    CONSTRAINT `fk_courses_timetable_training_centers` FOREIGN KEY (`training_center_id`) REFERENCES `training_centers` (`id`),
	PRIMARY KEY (`id`)
)