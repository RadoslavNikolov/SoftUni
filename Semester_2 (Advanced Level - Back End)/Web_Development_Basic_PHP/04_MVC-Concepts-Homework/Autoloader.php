<?php

namespace Framework;

include 'helpers/Helpers.php';
use Framework\Helpers\Helpers;

class Autoloader
{
    public static function init(){
        spl_autoload_register(function($class){
            $pathParams = explode('\\', $class);
            $path = implode(DIRECTORY_SEPARATOR, $pathParams);
            $path = str_replace($pathParams[0], "", $path);


            if (!file_exists(substr($path . '.php', 1))) {
                header("Location: " . Helpers::url());
                exit;
            }

            require_once $path . '.php';
        });
    }
}