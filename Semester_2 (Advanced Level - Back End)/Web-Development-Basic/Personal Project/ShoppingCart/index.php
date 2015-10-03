<?php
namespace ShoppingCart;

session_start();

ini_set('display_errors', 1);

///**
// * Secure the session
// */
//if(isset($_SESSION['HTTP_USER_AGENT']))
//{
//    if($_SESSION['HTTP_USER_AGENT'] != md5($_SERVER['HTTP_USER_AGENT']))
//    {
//        session_regenerate_id();
//        $_SESSION['HTTP_USER_AGENT'] = md5($_SERVER['HTTP_USER_AGENT']);
//    }
//}
//else
//{
//    $_SESSION['HTTP_USER_AGENT'] = md5($_SERVER['HTTP_USER_AGENT']);
//}

require_once ("Autoloader.php");
Autoloader::init();
$router = new \ShoppingCart\Routers\Router();
$frontController = new \ShoppingCart\FrontController($router);
$app = new \ShoppingCart\Application($frontController);
$app->start();




