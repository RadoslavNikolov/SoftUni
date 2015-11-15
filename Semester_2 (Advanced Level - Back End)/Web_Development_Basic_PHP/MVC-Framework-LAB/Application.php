<?php
namespace SoftUni;

class Application
{
    const CONTROLLERS_NAMESPACE = "SoftUni\\Controllers\\";
    const CONTROLLERS_SUFFIX = "Controller";
    private $controllerName = null;
    private $actionName = null;
    private $requestParams = [];

    /**
     * Application constructor.
     * @param null $controller
     * @param null $action
     * @param array $params
     */
    public function __construct($controller, $action, array $params)
    {
        $this->setControllerName($controller);
        $this->setActionName($action);
        $this->setRequestParams($params);
    }

    /**
     * @return null
     */
    public function getControllerName()
    {
        return $this->controllerName;
    }

    /**
     * @param null $controllerName
     */
    public function setControllerName($controllerName)
    {
        $this->controllerName = $controllerName;
    }

    /**
     * @return null
     */
    public function getActionName()
    {
        return $this->actionName;
    }

    /**
     * @param null $actionName
     */
    public function setActionName($actionName)
    {
        $this->actionName = $actionName;
    }

    /**
     * @return array
     */
    public function getRequestParams()
    {
        return $this->requestParams;
    }

    /**
     * @param array $requestParams
     */
    public function setRequestParams($requestParams)
    {
        $this->requestParams = $requestParams;
    }


    public function start(){

        $this->initController();
        View::$controllerName = $this->controllerName;
        View::$actionName = $this->actionName;

        call_user_func_array([
            $this->controller,
            $this->actionName
            ],
            $this->requestParams
        );

    }


    private function initController(){
        $controllerName =
            self::CONTROLLERS_NAMESPACE
            .$this->controllerName
            . self::CONTROLLERS_SUFFIX;

        $this->controller = new $controllerName;
    }
}