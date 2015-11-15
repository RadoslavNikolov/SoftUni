<?php

namespace Framework;

use Framework\Config\DatabaseConfig;
use Framework\Database\Database;

class App
{
    /**
     * @var \Framework\FrontController
     */
    private $frontController;

    /**
     * @param \Framework\FrontController $frontController
     */
    public function __construct($frontController){
        $this->setFrontController($frontController);
    }

    /**
     * @param \Framework\FrontController $frontController
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
}