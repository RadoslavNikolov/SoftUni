-- Create the database Sales if it does not exist

DROP DATABASE IF EXISTS `translations`;

CREATE DATABASE `translations`
CHARACTER SET utf8 COLLATE utf8_unicode_ci;
USE `translations`;

-- Drop all existing translations tables, so that we can create them
DROP TABLE IF EXISTS `translations`;


CREATE TABLE translations(
	id int(11) NOT NULL AUTO_INCREMENT,
	tag varchar(250) NOT NULL UNIQUE,
	text_en text NOT NULL,
	text_bg text NOT NULL,
    CONSTRAINT PK_Translations PRIMARY KEY (id)
);


-- Insert table data
INSERT INTO translations(id, tag, text_en, text_bg) VALUES
(1,'greeting_header_hello', 'Hello', 'Здравейте'),
(2,'welcome_message', 'Welcome to our site', 'Добре дошъл в нашия сайт');

ALTER TABLE Products  ADD CONSTRAINT FK_Products_Measures
FOREIGN KEY(measureId) REFERENCES Measures (measureId);

ALTER TABLE Products  ADD CONSTRAINT FK_Products_Vendors
FOREIGN KEY(vendorId) REFERENCES Vendors (vendorId);

ALTER TABLE Sales ADD CONSTRAINT FK_Sales_Products
FOREIGN KEY(productId) REFERENCES Products (productId);

ALTER TABLE Sales ADD CONSTRAINT FK_Sales_Supermarkets 
FOREIGN KEY(supermarketId) REFERENCES Supermarkets (supermarketId);

