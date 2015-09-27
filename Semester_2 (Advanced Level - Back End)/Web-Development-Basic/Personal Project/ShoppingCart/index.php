<?php
namespace ShoppingCart;

use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;

session_start();
ini_set('display_errors', 1);

//echo 'tesst index.php';

//var_dump($_SERVER);
require_once ("Autoloader.php");

Autoloader::init();

$uri = $_SERVER['REQUEST_URI'];
$self = $_SERVER['PHP_SELF'];
$index = basename($self);

$directories = str_replace($index, '', $self);

$requestString = str_replace($directories, '', $uri);
$requestParams = explode("/", $requestString);
$controller = array_shift($requestParams);
$action = array_shift($requestParams);
//var_dump($controller);
//var_dump($action);
//var_dump($requestParams);

$fullQualifiedController = '\\ShoppingCart\\Controllers\\' . ucfirst($controller) . 'Controller';
$controllerInstance = new $fullQualifiedController();


Database::setInstance(
    DatabaseConfig::DB_INSTANCE,
    DatabaseConfig::DB_DRIVER,
    DatabaseConfig::DB_USER,
    DatabaseConfig::DB_PASS,
    DatabaseConfig::DB_NAME,
    DatabaseConfig::DB_HOST
);

$app = new Application(ucfirst($controller), $action, $requestParams);
$app->start();


//
//function loadTemplate($templateName, $data = null){
//    require_once 'templates/' . $templateName . '.php';
//}