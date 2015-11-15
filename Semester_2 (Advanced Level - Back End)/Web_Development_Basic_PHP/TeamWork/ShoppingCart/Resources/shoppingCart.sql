DROP DATABASE IF EXISTS `shopping_cart`;

CREATE DATABASE `shopping_cart`
CHARACTER SET utf8 COLLATE utf8_unicode_ci;

USE `shopping_cart`;

-- Drop all existing Sales tables, so that we can create them
DROP TABLE IF EXISTS `roles`;
DROP TABLE IF EXISTS `categories`;
DROP TABLE IF EXISTS `users`;
DROP TABLE IF EXISTS `carts`;
DROP TABLE IF EXISTS `products`;
DROP TABLE IF EXISTS `cart_products`;


-- Create tables

CREATE TABLE IF NOT EXISTS roles(
	role_id int(11) NOT NULL AUTO_INCREMENT,
    role_name varchar(255) NOT NULL UNIQUE,
    isDeleted boolean NOT NULL DEFAULT false,
    PRIMARY KEY (role_id)
)ENGINE=INNODB DEFAULT CHARSET=utf8;

INSERT INTO roles VALUES (1,'administrator', false),(2,'customer', false), (3,'editor', false);

CREATE TABLE IF NOT EXISTS categories (
  cat_id int(11) NOT NULL AUTO_INCREMENT,
  cat_name varchar(50) NOT NULL UNIQUE DEFAULT '0',
  parent_id int(11) NULL,
  isActive boolean NOT NULL,
  isDeleted boolean NOT NULL,
  PRIMARY KEY (cat_id),
  CONSTRAINT FK_Parend_ID FOREIGN KEY(parent_id) REFERENCES categories (cat_id)
) ENGINE=INNODB DEFAULT CHARSET=utf8;

INSERT INTO categories VALUES 
	(1,'animal', null, true, false),
	(2,'vegetable', null, true, false),
    (3,'mineral', null, true, false),
    (4,'dogie', 1, true, false),
	(5,'kittie', 1, true, false),
    (6,'horsie', 1, true, false),
    (7,'gerbil', 1, true, false),
	(8,'birdie', 1, true, false),
    (9,'carrot', 2, true, false),
    (10,'tomato', 2, true, false),
	(11,'potato', 2, true, false),
    (12,'celery', 2, true, false),
    (13,'rutabaga', 2, true, false),
	(14,'quartz', 3, true, false),
    (15,'feldspar', 3, true, false),
    (16,'silica', 3, true, false),
	(17,'gypsum', 3, true, false),
    (18,'hunting', 4, true, false),
    (19,'companion', 4, true, false),
	(20,'herding', 4, true, false),
    (21,'setter', 18, true, false),
    (22,'pointer', 18, true, false),
	(23,'terrier', 18, true, false),
    (24,'poodle', 19, true, false),
    (25,'chihuahua', 19, true, false),
	(26,'shepherd', 20, true, false),
    (27,'collie', 20, true, false);


CREATE TABLE IF NOT EXISTS users (
  user_id int(11) NOT NULL AUTO_INCREMENT,
  username varchar(255) NOT NULL UNIQUE,
  email varchar(255) NOT NULL UNIQUE,
  password varchar(255) NOT NULL,
  cash numeric(15,3) NOT NULL,
  role_id int(11) NOT NULL,
  isActive boolean NOT NULL,
  isDeleted boolean NOT NULL,
  PRIMARY KEY (user_id),
  CONSTRAINT FK_Users_Roles FOREIGN KEY(role_id) REFERENCES roles (role_id)
) ENGINE=INNODB DEFAULT CHARSET=utf8;


-- TODO

CREATE TABLE carts (
  cart_id INT(11) NOT NULL AUTO_INCREMENT,
  user_id int(11) NOT NULL,
  isCheckout boolean NOT NULL default 0,
  isDeleted boolean NOT NULL,
  checkout_date datetime NULL,
  total numeric(15,3) NULL,
  PRIMARY KEY (cart_id),
  CONSTRAINT FK_Carts_Users FOREIGN KEY(user_id) REFERENCES users (user_id)
) ENGINE=INNODB DEFAULT CHARSET=utf8;




CREATE TABLE products(
	product_id int(11) NOT NULL AUTO_INCREMENT,
	product_Name nvarchar(200) NOT NULL UNIQUE,
	product_Price numeric(15,3) NOT NULL DEFAULT '0',
  inStock int(11) NOT NULL DEFAULT '0',
  isActive boolean NOT NULL,
  isDeleted boolean NOT NULL,
  cat_id int(11) NOT NULL DEFAULT '0',
	PRIMARY KEY (product_Id),
	CONSTRAINT FK_Products_Categories FOREIGN KEY(cat_id) REFERENCES categories (cat_id)
)ENGINE=INNODB;


CREATE TABLE cart_products (
	id int(11) NOT NULL AUTO_INCREMENT,
	cart_id int(11) NOT NULL DEFAULT '0',
	product_id int(11) NOT NULL DEFAULT '0',
  quantity int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `FK__cart_id` (`cart_id`),
  KEY `FK2__product_id` (`product_id`),
  CONSTRAINT `FK2__product_id` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK__cart_id` FOREIGN KEY (`cart_id`) REFERENCES `carts` (`cart_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB;

ALTER TABLE cart_products
ADD UNIQUE KEY `my_unique_key` (`cart_id`, `product_id`);


