<?php

namespace Framework\Routers;

use Framework\Config\AppConfig;

class Router
{
    private $controller = null;
    private $action = null;
    private $params = [];

    public function __construct() {
        $this->parseURI();
    }

    private function parseURI(){
        $uri = $_SERVER['REQUEST_URI'];
        $self = $_SERVER['PHP_SELF'];
        $index = basename($self);
        $directories = str_replace($index, '', $self);
        $requestString = str_replace($directories, '', $uri);

        if (strpos($requestString, 'index.php') === 0) {
            $requestString = substr($requestString, strlen('index.php'));
        }

        $requestParams = explode("/", $requestString);
        $this->controller = array_shift($requestParams);
        $this->action = array_shift($requestParams);
        $this->params = $requestParams;
    }

    public function getControllerName(){
        if ($this->controller == null   ) {
            return AppConfig::DEFAULT_CONTROLLER;
        }

        return $this->controller;
    }

    public function getActionName(){
        if ($this->action == null   ) {
            return AppConfig::DEFAULT_ACTION;
        }

        return $this->action;
    }

    public function getParams(){
        return $this->params;
    }
}