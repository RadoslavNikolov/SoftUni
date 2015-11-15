<?php
namespace ShoppingCart;


use ShoppingCart\Config\ApplicationConfig;
use ShoppingCart\Helpers\Validations;

class View
{
    public static $controllerName;
    public static $actionName;
    public static $viewBag = [];

    /*
     * @see loadViewAndModel if 2 arguments are passed
     * @see loadOnlyModel if 1 argument is passed
     * @see loadOnlyView if none arguments are passed
     */
    public function __construct()
    {
        $params = func_get_args();

        if (count($params) >= ApplicationConfig::PARAMS_COUNT_MODEL_AND_VIEW) {
            $view = $params[0];
            $model = $params[1];
            $this->initModelView($view, $model);
        } else {
            $model = isset($params[0]) ? $params[0] : null;
            $this->initModelOnly($model);
        }
    }

    private function initModelView($view, $model)
    {
        $view = str_replace('/',DIRECTORY_SEPARATOR, $view);
        $view = str_replace('\\',DIRECTORY_SEPARATOR, $view);

        $file = ApplicationConfig::VIEW_FOLDER
            .DIRECTORY_SEPARATOR
            .$view
            .ApplicationConfig::VIEW_EXTENSION;

        if(Validations::viewModelValidation($model, $file)){
            require $file;
        }
    }

    private function initModelOnly($model)
    {
        $file = ApplicationConfig::VIEW_FOLDER
            .DIRECTORY_SEPARATOR
            .self::$controllerName
            .DIRECTORY_SEPARATOR
            .self::$actionName
            .ApplicationConfig::VIEW_EXTENSION;


        if(Validations::viewModelValidation($model, $file)){
            require $file;
        }
    }

    private function initViewOnly()
    {
        $file = ApplicationConfig::VIEW_FOLDER
            .DIRECTORY_SEPARATOR
            .self::$controllerName
            .DIRECTORY_SEPARATOR
            .self::$actionName
            .ApplicationConfig::VIEW_EXTENSION;

        require $file;
    }
}