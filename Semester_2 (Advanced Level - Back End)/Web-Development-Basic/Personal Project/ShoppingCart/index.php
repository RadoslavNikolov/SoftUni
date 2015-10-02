<?php
namespace ShoppingCart;

session_start();
ini_set('display_errors', 1);

require_once ("Autoloader.php");
Autoloader::init();
$router = new \ShoppingCart\Routers\Router();
$frontController = new \ShoppingCart\FrontController($router);
$app = new \ShoppingCart\Application($frontController);
$app->start();
