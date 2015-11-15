<?php
namespace ShoppingCart\Controllers;

use ShoppingCart\Helpers\HelpFunctions;
use ShoppingCart\Repositories\CategoryRepository;
use ShoppingCart\View;

abstract class Controller
{


    /**
     * @return bool
     */
    public function isLogged() {
        return isset($_SESSION['user_id']);
    }


    /**
     * @param null $model
     * @param null $view
     * @return View
     */
    public function render($model = null, $view = null) {

        if(!empty($model) && !empty($view)){
             return new View($model, $view);
        } else {

            $caller = debug_backtrace()[1];
            $action = $caller['function'];
            $token = explode(DIRECTORY_SEPARATOR, strtolower($caller['class']));
            $controller = strtolower(str_replace('controller', "", array_pop($token)));
            $target = "" . $controller . "/" . $action;

            return new View($model, $target);
        }




//
//        return new View($model, $view);
//        View::initView($model,$view);
    }

    /**
     * @param null $controller
     * @param null $action
     * @param array $params
     */
    protected function redirect(
        $controller = null, $action = null, $params = [])
    {
        $uri = $controller ? $controller . '/' : '';
        $uri .= $action ? $action : '';
        if (!empty($params)) {
            $uri .= '/';
            foreach($params as $param) {
                $uri .= $param . '/';
            }
        }


        header('Location: ' . HelpFunctions::url() . $uri);
        die;
    }

    /**
     * @param $toEscape
     * @return string
     */
    protected function escapeAll(&$toEscape){
        if(is_array($toEscape)){
            foreach($toEscape as $key => &$value){
                if(is_object($value)){
                    $reflection = new \ReflectionClass($value);
                    $properties = $reflection->getProperties();

                    foreach($properties as &$property){
                        $property->setAccessible(true);
                        $property->setValue($value, $this->escapeAll($property->getValue($value)));
                    }
                }else if(is_array($value)){
                    $this->escapeAll($value);
                } else {
                    $value = htmlspecialchars($value);
                }
            }
        } else if(is_object($toEscape)){
            $reflection = new \ReflectionClass($toEscape);
            $properties = $reflection->getProperties();

            foreach($properties as &$property){
                $property->setAccessible(true);
                $property->setValue($toEscape, $this->escapeAll($property->getValue($toEscape)));
            }
        } else {
            $toEscape = htmlspecialchars($toEscape);
        }

        return $toEscape;
    }


    protected function updateCategoriesInJson(){
        $catRepo = CategoryRepository::create();

        $categories = $this->escapeAll($catRepo->getAllCategories());
        $asideCategories = HelpFunctions::convertCategorieToAsideArray($this->escapeAll($catRepo->getNestedCategories()));

        file_put_contents('Resources\categoriesJson.json', json_encode($categories, true));
        file_put_contents('Resources\asideCategoriesJson.json', json_encode($asideCategories, true));
    }
}