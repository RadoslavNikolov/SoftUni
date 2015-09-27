<?php
namespace ShoppingCart;

class Autoloader
{

    public static function init(){
        spl_autoload_register(function($class) {
        $pathParams = explode('\\', $class);
            array_shift($pathParams);
        $path = implode(DIRECTORY_SEPARATOR, $pathParams);


//        if (!is_readable($path . '.php')) {
//            throw new \Exception();
//        }

        require_once $path . ".php";
        });

    }

}