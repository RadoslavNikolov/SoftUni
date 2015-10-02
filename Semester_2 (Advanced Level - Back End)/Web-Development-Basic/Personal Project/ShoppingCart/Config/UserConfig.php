<?php

namespace ShoppingCart\Config;


use ShoppingCart\Helpers\ScannerHelper;

/**
 * Class UserConfig
 * @package ShoppingCart\Config
 */
class UserConfig {

    const ENTRY_POINT = 'index.php';
    const USERS_INITIAL_CASH = 1500;


    private  $classesAnnotations = [];
    private  $methodsAnnotations = [];
    private static $inst = null;


    private function __construct()
    {
        ScannerHelper::annotationScanner();
        $this->classesAnnotations = ScannerHelper::getClassesAnnotations();
        $this->methodsAnnotations = ScannerHelper::getMethodsAnnotations();
    }

    /**
     * @return array
     */
    public function getClassesAnnotations()
    {
        return $this->classesAnnotations;
    }

    /**
     * @return array
     */
    public function getMethodsAnnotations()
    {
        return $this->methodsAnnotations;
    }


    /**
     * @return null|UserConfig
     */
    public static function getInstance()
    {
        if (self::$inst == null)
        {
            self::$inst = new self();
        }

        return self::$inst;
    }
}