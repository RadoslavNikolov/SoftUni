<?php
namespace SoftUni;

class Autoloader
{

    public static function init(){
        spl_autoload_register(function($class) {
        $pathParams = explode('\\', $class);
        $path = implode(DIRECTORY_SEPARATOR, $pathParams);
        $path = str_replace($pathParams[0], "", $path);
//            var_dump($path);


//        if (!is_readable($path . '.php')) {
//            throw new \Exception();
//        }

        require_once $path . ".php";
        });

    }

}