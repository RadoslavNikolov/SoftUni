<?php

namespace Framework;

use Framework\Config\AppConfig;
use Framework\Helpers\Helpers;

class FrontController
{
    private $controllerName;
    private $actionName;
    private $requestParams = [];

    private $controller;

    public function __construct(\Framework\Routers\Router $router){


        $this->controllerName = $router->getControllerName();
        $this->actionName = $router->getActionName();
        $this->requestParams = $router->getParams();
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
            header("Location: " . Helpers::url());
        }
    }

    private function initController(){
        $controllerName = AppConfig::CONTROLLERS_NAMESPACE
            . $this->controllerName
            . AppConfig::CONTROLLERS_SUFFIX;

        try {
            class_exists($controllerName, false);
            $this->controller = new $controllerName();
        } catch (\Exception $e) {
            var_dump($e);
            header('Location: ' . Helpers::url());
            exit;
        }
    }
}