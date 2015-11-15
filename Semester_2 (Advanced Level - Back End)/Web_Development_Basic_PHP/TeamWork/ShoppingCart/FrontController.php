<?php

namespace ShoppingCart;

use ShoppingCart\Config\ApplicationConfig;
use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Config\UserConfig;
use ShoppingCart\Core\Database;
use ShoppingCart\Helpers\HelpFunctions;

class FrontController {

    private $controllerName;
    private $actionName;
    private $requestParams = [];

    private $controller;

    public function __construct(\ShoppingCart\Routers\IRouter $router){


        $this->controllerName = $router->getControllerName();
        $this->actionName = $router->getActionName();
        $this->requestParams = $router->getParams();
    }


    private function init(){
        $this->setDb();
        $this->setRequest();
        $this->dispatch();
    }



    private function initController(){
        $controllerName = ApplicationConfig::CONTROLLERS_NAMESPACE
            . $this->controllerName
            . ApplicationConfig::CONTROLLERS_SUFFIX;

        try {
            class_exists($controllerName, false);
            $this->controller = new $controllerName();
        } catch (\Exception $e) {
            header('Location: ' . Helpers::url());
            exit;
        }
    }

    public function dispatch(){
        $this->initController();

        VIEW::$controllerName = $this->controllerName;
        VIEW::$actionName = $this->actionName;

        if (!call_user_func_array(
            [
                $this->controller,
                $this->actionName
            ],
            $this->requestParams
        )) {
            header("Location: " . HelpFunctions::url());
        }
    }









}