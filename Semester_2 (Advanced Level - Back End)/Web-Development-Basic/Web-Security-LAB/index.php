<?php
use Config\DatabaseConfig;
use Core\Database;

session_start();

ini_set('display_errors', 1);

spl_autoload_register(function($className) {
    $classPath = str_replace("\\", "/", $className);

//    var_dump($classPath);
    require_once $classPath . ".php";
});

require_once 'core/app.php';

Database::setInstance(
    DatabaseConfig::DB_INSTANCE,
    DatabaseConfig::DB_DRIVER,
    DatabaseConfig::DB_USER,
    DatabaseConfig::DB_PASS,
    DatabaseConfig::DB_NAME,
    DatabaseConfig::DB_HOST
);

$app = new \Core\App(Database::getInstance(DatabaseConfig::DB_INSTANCE));


function loadTemplate($templateName, $data = null){
    require_once 'templates/' . $templateName . '.php';
}

