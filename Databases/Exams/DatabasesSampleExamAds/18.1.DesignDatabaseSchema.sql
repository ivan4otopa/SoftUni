CREATE DATABASE `orders`;

CREATE TABLE `products`
(
	`id` int NOT NULL AUTO_INCREMENT,
    `name` nvarchar(30) NOT NULL,
    `price` decimal NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `customers`
(
	`id` int NOT NULL AUTO_INCREMENT,
    `name` nvarchar(30) NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `orders`
(
	`id` int NOT NULL AUTO_INCREMENT,
    `date` datetime NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `order_items`
(
	`id` int NOT NULL AUTO_INCREMENT,
    `order_id` int NOT NULL,
    `product_id` int NOT NULL,
    `quantity` decimal(10, 2) NOT NULL,
    PRIMARY KEY (`id`),
    KEY `fk_order_items_orders_idx` (`order_id`),
    KEY `fk_order_items_products_idx` (`product_id`),
    CONSTRAINT `fk_order_items_orders_idx` FOREIGN KEY (`order_id`) REFERENCES `orders` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_order_items_products_idx` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
)