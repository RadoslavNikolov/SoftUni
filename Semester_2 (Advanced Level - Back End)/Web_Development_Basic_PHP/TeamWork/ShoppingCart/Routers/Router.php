<?php
namespace ShoppingCart\Routers;

use ShoppingCart\Config\ApplicationConfig;
use ShoppingCart\Config\UserConfig;
use ShoppingCart\Helpers\HelpFunctions;
use ShoppingCart\Helpers\ScannerHelper;
use ShoppingCart\Repositories\UserRepository;

class Router implements IRouter{
    private $controller = null;
    private $action = null;
    private $requestParams = [];

    function __construct()
    {
        $this->init();
    }

    private function init(){
        $this->setRequest();
    }

    private function setRequest(){
        $uri = $_SERVER['REQUEST_URI'];
        $uri = rtrim($uri, DIRECTORY_SEPARATOR);
        $uri = rtrim($uri, '/');;

        $self = $_SERVER['PHP_SELF'];
        $index = basename($self);
        $directories = str_replace($index, '', $self);
        $requestString = str_replace($directories, '', $uri);
        $requestParams = explode("/", $requestString);

        $this->controller = array_shift($requestParams);
        $this->action = array_shift($requestParams);
        $this->requestParams = $requestParams;




        //Check for custom Route
        $this->checkCustomRoute($requestString);

        //Check for @Authorize and @Admin annotations
        $this->checkAnnotations();

        //Check binding model
        if($_SERVER['REQUEST_METHOD'] == 'POST'){
            $this->checkBindingModel();
        }


    }


    /**
     * @return null|string
     */
    public function getControllerName(){
        if ($this->controller == null   ) {
            return ApplicationConfig::DEFAULT_CONTROLLER;
        }

        return $this->controller;
    }


    /**
     * @return null|string
     */
    public function getActionName(){
        if ($this->action == null   ) {
            return ApplicationConfig::DEFAULT_ACTION;
        }

        return $this->action;
    }

    /**
     * @return array
     */
    public function getParams(){
        return $this->requestParams;
    }

    private function checkCustomRoute($requestString){
        $route = '@Route("' . $requestString . '")';

        $annotations = UserConfig::getInstance()->getMethodsAnnotations();

        foreach($annotations as $value){

            if(in_array($route, $value['annotations'], true)){
                $class = $value['class'];
                $this->action = $value['name'];

                $controller = explode(DIRECTORY_SEPARATOR, $class);
                $controller =strtolower(array_pop($controller));
                $controller = str_replace("controller", "", $controller);
                $this->controller = $controller;
            }
        }
    }


    private function checkBindingModel(){
        $controller = ApplicationConfig::CONTROLLERS_NAMESPACE
            . ucfirst($this->getControllerName())
            . ApplicationConfig::CONTROLLERS_SUFFIX;

        $reflector = new \ReflectionClass($controller);
        $method = $reflector->getMethod($this->action);

        if(!$method->getParameters()){
            return;
        }

        $param = $method->getParameters()[0];

        //If argument type is interface not class return
        if(interface_exists($param->getClass()->name, false)){
            return;
        }

        //If not exist class such as argument type return
        if(!class_exists($param->getClass()->name, false)){

        }

        $paramReflectorClass = new \ReflectionClass($param->getClass()->getName());
        $bindingModelName = $paramReflectorClass->getName();
        $bindingModel = new $bindingModelName();
        $paramClassFields = $paramReflectorClass->getProperties();

        foreach($paramClassFields as $field) {

            $doc = $field->getDocComment();
            $annotation = ScannerHelper::docBlockParser($doc);
            $fieldName = $field->getName();

            $setter = 'set' . $field->getName();

            if(!empty($annotation)){
                if (strtolower($annotation[0]) == '@require') {

                    if (!isset($_POST[$fieldName])) {
                        $setter = 'set' . $field->getName();
                        $bindingModel->$setter("{$fieldName} is required");
                        continue;
                    }

                    $setter = 'set' . $field->getName();
                    $bindingModel->$setter($_POST[$fieldName]);

                } else {

                    if (isset($_POST[$fieldName])) {
                        $bindingModel->$setter($_POST[$fieldName]);
                    }
                }
            }
        }

        $this->requestParams = array($bindingModel);
    }

    private function checkAnnotations()
    {
        $actionPath = ApplicationConfig::CONTROLLERS_NAMESPACE
            . ucfirst($this->getControllerName())
            . ApplicationConfig::CONTROLLERS_SUFFIX
            . DIRECTORY_SEPARATOR
            . $this->getActionName();

        $annotations = UserConfig::getInstance()->getMethodsAnnotations();

        if(empty($annotations)){
            return;
        }
        if(!in_array($actionPath, $annotations)){
            return;
        }

        $currentActionAnnotations = $annotations[$actionPath];

        if (in_array('@Authorize', $currentActionAnnotations['annotations'], true) || in_array('@authorize', $currentActionAnnotations['annotations'], true)) {
            if (!HelpFunctions::isLogged()) {
                throw new \Exception("You are not authorized!");
            }
        }

        if (in_array('@Admin', $currentActionAnnotations['annotations'], true) || in_array('@admin', $currentActionAnnotations['annotations'], true)) {
            if (!HelpFunctions::isLogged()) {
                throw new \Exception("You are not logged!");
            }

            if($_SESSION['user_role'] != 'administrator'){
                throw new \Exception("You do not have administrative privileges!");
            }
        }
    }
}