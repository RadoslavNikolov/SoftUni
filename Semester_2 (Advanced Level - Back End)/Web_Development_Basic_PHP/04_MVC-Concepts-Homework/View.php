<?php

namespace Framework;

use Framework\Config\AppConfig;

class View
{
    public static $controllerName;
    public static $actionName;

    public static function initView($model, $layout, $view = null){

//        $model->view = AppConfig::VIEW_FOLDER
//            . DIRECTORY_SEPARATOR
//            . self::$controllerName
//            . DIRECTORY_SEPARATOR
//            . self::$actionName
//            . AppConfig::VIEW_EXTENSION;

        if ($view == null) {
            $model->view = self::loadDefaultView();
        } else {
            $model->view = self::loadCustomView($view);
        }

        require AppConfig::VIEW_FOLDER
            . DIRECTORY_SEPARATOR
            . AppConfig::LAYOUT_FOLDER
            . DIRECTORY_SEPARATOR
            . strtolower($layout)
            . AppConfig::VIEW_EXTENSION;
    }

    private function loadCustomView($view) {
        return AppConfig::VIEW_FOLDER
            . DIRECTORY_SEPARATOR
            . $view
            . AppConfig::VIEW_EXTENSION;
    }

    private function loadDefaultView() {
        return AppConfig::VIEW_FOLDER
            . DIRECTORY_SEPARATOR
            . self::$controllerName
            . DIRECTORY_SEPARATOR
            . self::$actionName
            . AppConfig::VIEW_EXTENSION;
    }
}