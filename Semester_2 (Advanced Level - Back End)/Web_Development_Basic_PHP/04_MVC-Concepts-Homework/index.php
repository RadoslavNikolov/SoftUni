<?php
session_start();

require_once 'Autoloader.php';
\Framework\Autoloader::init();
$router = new Framework\Routers\Router();
$frontController = new \Framework\FrontController($router);
$app = new \Framework\App($frontController);
$app->start();