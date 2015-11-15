<?php
namespace ShoppingCart\Helpers;

use ShoppingCart\Config\UserConfig;

class HelpFunctions {
    const LOCAL_HOST = 'localhost:6300';


    /**
     * @return mixed
     * @see Return full path of the root directory
     */
    public static function getFullBasePath(){
        $entryPointPath = $_SERVER['SCRIPT_FILENAME'];
        $basePath = str_replace(UserConfig::ENTRY_POINT,'',$entryPointPath);
        $basePath = str_replace('/',DIRECTORY_SEPARATOR, $basePath);
        $basePath = str_replace('\\',DIRECTORY_SEPARATOR, $basePath);

        return $basePath;
    }

    public static function anchor($controller, $action,  array $parameters, $text){
        $self = $_SERVER['PHP_SELF'];
        $index = basename($self);
        $directories = str_replace($index, '', $self);

        $data = '<a href="' . $directories;
        if(!empty($controller)){
            $data = $data . $controller;
        }

        if(!empty($action)){
            $data = $data . DIRECTORY_SEPARATOR . $action;
        }

        if(!empty($parameters)){
            foreach($parameters as $p){
                $data = $data . DIRECTORY_SEPARATOR . $p;
            }
        }

        $data = str_replace('/',DIRECTORY_SEPARATOR, $data);
        $data = str_replace('\\',DIRECTORY_SEPARATOR, $data);

        $data = $data . '">' . $text . "</a>";

        return $data;
    }


    public static function createCategoryTable (array $models){
        if(!empty($models)){
            $data = '<table border="1">';

            $data = $data . "<tr>";
            $columnNames = array_keys($models[0]);
            foreach($columnNames as $value){
                $data = $data . '<th>' . ucfirst(htmlspecialchars($value)) . '</th>';
            }

            $data = $data . "<tr>";

            foreach($models as $model){
                $data = $data . "<tr>";

                foreach($model as $key => $value){
                    $data = $data . '<td>' . htmlspecialchars($value) . '</td>';
                }

                if(($_SESSION['user_role'] == 'administrator') && $model['isActive'] === '1'){

                    $data = $data . "<td>" . HelpFunctions::anchor('categories', 'edit', array($model['CategoryID'], 'changeActive') ,'[Set UnActive]') . "</td>";

                } else if($_SESSION['user_role'] == 'administrator' && $model['isActive'] === '0'){
                    $data = $data . "<td>" . HelpFunctions::anchor('categories', 'edit', array($model['CategoryID'], 'changeActive') ,'[Set Active]') . "</td>";
                }

                if(($_SESSION['user_role'] == 'administrator' || $_SESSION['user_role'] == 'editor') && $model['isDeleted'] === '0'){
                    $data = $data . "<td>" . HelpFunctions::anchor('categories', 'edit', array($model['CategoryID'], 'changeDelete') ,'[Delete]') . "</td>";

                } else if(($_SESSION['user_role'] == 'administrator' || $_SESSION['user_role'] == 'editor') && $model['isDeleted'] === '1'){
                    $data = $data . "<td>" . HelpFunctions::anchor('categories', 'edit', array($model['CategoryID'], 'changeDelete') ,'[UnDelete]') . "</td>";
                }

                $data = $data . "<tr>";
            }
            $data = $data . '</table>';

            return $data;
        }

        return false;
    }

    public static function url(){
        $self = $_SERVER['PHP_SELF'];
        $index = basename($self);
        $directories = str_replace($index, '', $self);
        return $directories;
    }


    public static function convertCategorieToAsideArray($array){
        $tempArray = [];
        foreach($array as $value){
            $root_name = $value['root_name'];
            $down1_name = $value['down1_name'];
            $down2_name = $value['down2_name'];
            $down3_name = $value['down3_name'];

            if(empty($root_name)){
                continue;
            }
            if(!array_key_exists($root_name, $tempArray)){
                $tempArray[$root_name] = array();
            }

            if(empty($down1_name)){
                continue;
            }
            if(!array_key_exists($down1_name, $tempArray[$root_name])){
                $tempArray[$root_name][$down1_name] = array();

            }

            if(empty($down2_name)){
                continue;
            }
            if(!array_key_exists($down2_name, $tempArray[$root_name][$down1_name])){
                $tempArray[$root_name][$down1_name][$down2_name] = array();

            }

            if(empty($down3_name)){
                continue;
            }

            if(!array_key_exists($down3_name, $tempArray[$root_name][$down1_name][$down2_name])){
                $tempArray[$root_name][$down1_name][$down2_name][$down3_name] = array();
            }
        }


        return $tempArray;
    }


    /**
     * @return bool
     */
    public static function isLogged() {
        return isset($_SESSION['user_id']);
    }

}