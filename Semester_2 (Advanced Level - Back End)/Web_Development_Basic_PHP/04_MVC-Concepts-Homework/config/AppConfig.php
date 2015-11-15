<?php

namespace Framework\Config;

class AppConfig
{
    const DEFAULT_CONTROLLER = 'todos';
    const DEFAULT_ACTION = 'home';
    const DEFAULT_LAYOUT = 'default';
    const DEFAULT_VIEW = 'home';
    const DEFAULT_REDIRECTION = 'home';

    const VIEW_FOLDER = 'views';
    const LAYOUT_FOLDER = 'layouts';
    const VIEW_EXTENSION = '.php';

    const CONTROLLERS_NAMESPACE = 'Framework\\Controllers\\';
    const CONTROLLERS_SUFFIX = 'Controller';
}