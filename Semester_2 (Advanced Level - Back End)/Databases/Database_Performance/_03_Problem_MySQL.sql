-- Homework: Database Performance

-- Problem 3.	Create the same table in MySQL


-- Drop the database if it already exists
DROP DATABASE IF EXISTS `DB_Performance`;


-- Create database
CREATE DATABASE `DB_Performance`
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `DB_Performance`;


DROP TABLE IF EXISTS `Performance`;

CREATE TABLE `Performance` (
	`id` int(11) NOT NULL AUTO_INCREMENT,
    `dated` datetime NOT NULL,
    `info` text NOT NULL,
    PRIMARY KEY(`id`)
);


-- Fill Database
DELIMITER $$

CREATE PROCEDURE fill_database()
BEGIN
START TRANSACTION;
  SET @i = 10000;
  SET @date = NOW();
  SET @count = 1;

  WHILE @i > 0 DO
	
    INSERT INTO `Performance` VALUES (
    @count,
    @date,
    CONCAT('Some text ', @count)
    );
    
	SET @date = @date + INTERVAL 2 MINUTE;
	SET @i = @i - 1;
    SET @count = @count + 1;
  END WHILE;
COMMIT;
END;

DELIMITER ;

-- Calling finction
CALL fill_database();



SELECT  *
FROM `Performance`


