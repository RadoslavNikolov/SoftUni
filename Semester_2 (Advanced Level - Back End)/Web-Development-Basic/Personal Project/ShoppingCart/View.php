<?php
namespace ShoppingCart;


class View
{
    const PARAMS_COUNT_MODEL_AND_VIEW = 2;
    const VIEW_FOLDER = 'Views';
    const VIEW_EXTENSION = '.phtml';
    /**
     * View constructor.
     */
    static $controllerName;
    static $actionName;

    /*
     * @see loadViewAndModel if 2 arguments are passed
     * @see loadOnlyModel if 1 argument is passed
     * @see loadOnlyView if none arguments are passed
     */
    public function __construct()
    {
        $params = func_get_args();

        if (count($params) >= self::PARAMS_COUNT_MODEL_AND_VIEW) {
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

        require self::VIEW_FOLDER
            .DIRECTORY_SEPARATOR
            .$view
            .self::VIEW_EXTENSION;
    }

    private function initModelOnly($model)
    {
        require self::VIEW_FOLDER
            .DIRECTORY_SEPARATOR
            .self::$controllerName
            .DIRECTORY_SEPARATOR
            .self::$actionName
            .self::VIEW_EXTENSION;
    }

    private function initViewOnly()
    {
        require self::VIEW_FOLDER
            .DIRECTORY_SEPARATOR
            .self::$controllerName
            .DIRECTORY_SEPARATOR
            .self::$actionName
            .self::VIEW_EXTENSION;
    }
}