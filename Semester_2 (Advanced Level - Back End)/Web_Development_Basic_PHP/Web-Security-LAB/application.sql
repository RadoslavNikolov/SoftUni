DROP DATABASE IF EXISTS `application`;

CREATE DATABASE `application`
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `application`;

-- Drop all existing Sales tables, so that we can create them
DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `buildings`;
DROP TABLE IF EXISTS `buildingsLevels`;
DROP TABLE IF EXISTS `usersBuildings`;


-- Create tables
CREATE TABLE IF NOT EXISTS users (
  id INT(11) NOT NULL AUTO_INCREMENT,
  username varchar(255) NOT NULL UNIQUE,
  password varchar(255) NOT NULL,
  gold int(11) NOT NULL,
  food int(11) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=INNODB DEFAULT CHARSET=utf8;


CREATE TABLE IF NOT EXISTS buildings (
  id INT(11) NOT NULL AUTO_INCREMENT,
  building_name varchar(255) NOT NULL UNIQUE,
  PRIMARY KEY (id)
) ENGINE=INNODB DEFAULT CHARSET=utf8;

INSERT INTO buildings VALUES (2,'HardUni'),(1,'SoftUni');

CREATE TABLE IF NOT EXISTS buildingsLevels (
  id INT(11) NOT NULL AUTO_INCREMENT,
  building_id int(11) NOT NULL,
  level int(11) NOT NULL,
  gold int(11) NOT NULL,
  food int(11) NOT NULL,
  PRIMARY KEY (id),
  KEY (level),
  CONSTRAINT FK_Buildings_Levels FOREIGN KEY(building_id) REFERENCES buildings (id) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=INNODB DEFAULT CHARSET=utf8;

INSERT INTO buildingsLevels VALUES (1,1,0,0,0),(2,2,0,0,0),(3,1,1,100,100),(4,2,1,100,100), (5,1,2,300,200),(6,2,2,200,400),(7,1,3,500,300),(8,2,3,600,500);

CREATE TABLE IF NOT EXISTS user_buildings (
  id INT(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL,
  building_id int(11) NOT NULL,
  level_id int(11) NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_1 FOREIGN KEY(user_id) REFERENCES users (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_2 FOREIGN KEY(building_id) REFERENCES buildings (id) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT FK_3 FOREIGN KEY(level_id) REFERENCES buildingsLevels (level) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=INNODB DEFAULT CHARSET=utf8;

