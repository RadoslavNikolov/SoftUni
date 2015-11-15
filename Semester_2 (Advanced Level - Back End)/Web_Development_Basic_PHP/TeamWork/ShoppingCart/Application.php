<?php
namespace ShoppingCart;


use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;

class Application
{

    /**
     * @var \ShoppingCart\FrontController
     */
    private $frontController;

    /**
     * @param \ShoppingCart\FrontController $frontController
     */
    public function __construct($frontController){
        $this->setFrontController($frontController);
    }

    /**
     * @param \ShoppingCart\FrontController $frontController
     */
    public function setFrontController($frontController) {
        $this->frontController = $frontController;
    }

    public function start(){
        Database::setInstance(
            DatabaseConfig::DB_INSTANCE,
            DatabaseConfig::DB_DRIVER,
            DatabaseConfig::DB_USER,
            DatabaseConfig::DB_PASS,
            DatabaseConfig::DB_NAME,
            DatabaseConfig::DB_HOST
        );

        $this->frontController->dispatch();
    }





    private function initController(){
        $controllerName =
            self::CONTROLLERS_NAMESPACE
            .$this->controllerName
            . self::CONTROLLERS_SUFFIX;

        $this->controller = new $controllerName;
    }
}