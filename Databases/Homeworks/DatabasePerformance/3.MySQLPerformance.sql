CREATE DATABASE `database_performance`;

CREATE TABLE `texts_and_dates`
(
	`text` nvarchar(100) NOT NULL,
    `date` datetime NOT NULL
)
PARTITION BY RANGE(YEAR(`date`))
(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
    PARTITION p2 VALUES LESS THAN (2010)
);

CREATE PROCEDURE dowhile()
BEGIN
	DECLARE counter int = 0;
	WHILE @counter < 1000000 DO
		INSERT INTO `texts_and_dates`(`text`, `date`)
		VALUES(DATE_ADD(CURDATE() + INTERVAL counter DAY), CAST(counter AS nvarchar(100))
        SET counter += 1
	END WHILE
END

CALL dowhile()