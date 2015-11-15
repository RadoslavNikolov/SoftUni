<?php
/**
 * Created by PhpStorm.
 * User: radko
 * Date: 30.9.2015 г.
 * Time: 10:04
 */

namespace ShoppingCart\Helpers;


use RecursiveDirectoryIterator;
use RecursiveIteratorIterator;
use ReflectionClass;
use RegexIterator;

class ScannerHelper {

    private static $classesAnnotations = [];
    private static $methodsAnnotations = [];

    public static  function classesScanner(){

        $rootDirectoryPath = HelpFunctions::getFullBasePath();
        $fqcns = array();
        $classes = [];

        $allFiles = new RecursiveIteratorIterator(new RecursiveDirectoryIterator($rootDirectoryPath));
        $phpFiles = new RegexIterator($allFiles, '/\.php$/');
        foreach ($phpFiles as $phpFile) {
            $content = file_get_contents($phpFile->getRealPath());
            $tokens = token_get_all($content);
            $namespace = '';
            for ($index = 0; isset($tokens[$index]); $index++) {
                if (!isset($tokens[$index][0])) {
                    continue;
                }
                if (T_NAMESPACE === $tokens[$index][0]) {
                    $index += 2; // Skip namespace keyword and whitespace
                    while (isset($tokens[$index]) && is_array($tokens[$index])) {
                        $namespace .= $tokens[$index++][1];
                    }
                }
                if (T_CLASS === $tokens[$index][0]) {
                    $index += 2; // Skip class keyword and whitespace
                    $fqcns[] = $namespace.'\\'.$tokens[$index][1];
                }
            }
        }

        foreach($fqcns as $classPath){
            $tokens = explode('\\',$classPath);
            $className = array_pop($tokens);
            $namespace = implode(DIRECTORY_SEPARATOR,$tokens);

            $namespace = str_replace('/',DIRECTORY_SEPARATOR, $namespace);
            $namespace = str_replace('\\',DIRECTORY_SEPARATOR, $namespace);

            $classes[$className] = array(
                "name_space" => $namespace,
                "class_name" => $className,
                "fullPath" => $classPath
            );
        }

        return $classes;
    }

    /**
     * @return array
     */
    public static function getClassesAnnotations()
    {
        return self::$classesAnnotations;
    }

    /**
     * @return array
     */
    public static function getMethodsAnnotations()
    {
        return self::$methodsAnnotations;
    }



    public static function annotationScanner(){

        self::$methodsAnnotations = [];
        self::$classesAnnotations = [];
        $allClasses = self::classesScanner();

        foreach($allClasses as $class => $value){
//            var_dump($value['fullPath']);
            self::getDocBlock($value['fullPath']);
        }

    }

    private static function getDocBlock($class){
        $reflector = new ReflectionClass($class);
        $classDocBlock = $reflector->getDocComment();


        $annotations = self::docBlockParser($classDocBlock);
        if(!empty($annotations)){
            self::$classesAnnotations[$class] = $annotations;
        }

        $methods = $reflector->getMethods();

        foreach($methods as $method){
            $methodDocBlock = $method->getDocComment();
            $annotations = self::docBlockParser($methodDocBlock);

            if(!empty($annotations)){

                $key = $method->class . DIRECTORY_SEPARATOR . $method->getName();
                $key = str_replace('/',DIRECTORY_SEPARATOR, $key);
                $key = str_replace('\\',DIRECTORY_SEPARATOR, $key);

                self::$methodsAnnotations[$key] = array (
                    "name" => $method->getName(),
                    "class" => $method->class,
                    "annotations" => $annotations
                );
            }
        }
    }

    public static function docBlockParser($data){
        preg_match_all('/(@\w+)(.*)\r?\n/', $data, $matches);
        foreach($matches[0] as &$match){
            $match = trim(preg_replace('/\s\s+/', '', $match));
        }
        return $matches[0];
    }


}