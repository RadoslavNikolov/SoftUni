<?php
/**
 * Created by PhpStorm.
 * User: isrmn
 * Date: 25.9.2015 �.
 * Time: 10:13 �.
 */

namespace SoftUni;


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

    public function __construct()
    {
        $params = func_get_args();

        if (count($params) == self::PARAMS_COUNT_MODEL_AND_VIEW) {
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
}