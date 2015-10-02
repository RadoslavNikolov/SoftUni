<?php
namespace ShoppingCart\Config;


class ApplicationConfig {

    const DEFAULT_CONTROLLER = 'users';
    const DEFAULT_ACTION = 'show';
    const DEFAULT_VIEW = 'show';

    const PARAMS_COUNT_MODEL_AND_VIEW = 2;
    const VIEW_FOLDER = 'Views';
    const VIEW_EXTENSION = '.phtml';

    const CONTROLLERS_NAMESPACE = "ShoppingCart\\Controllers\\";
    const CONTROLLERS_SUFFIX = "Controller";

}