<?php
namespace SoftUni\Helpers;

class HelpFunctions {
    const LOCAL_HOST = 'localhost:6300';


    public static function generateUrl(){
        $self = $_SERVER['PHP_SELF'];
        $index = basename($self);
        $directories = str_replace($index, '', $self);

        return $directories;
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

        $data = $data . '">' . $text . "</a>";

        return $data;
    }

    public static function createBuildingsTable (array $models, $link){
        if(!empty($models)){
            $data = '<table border="1">';

            $data = $data . "<tr>";
            $columnNames = array_keys($models[0]);
            foreach($columnNames as $value){
                $data = $data . '<td>' . ucfirst(htmlspecialchars($value)) . '</td>';
            }
            if($link){
                $data = $data . '<td></td>';
            }
            $data = $data . "<tr>";

            foreach($models as $model){
                $data = $data . "<tr>";
                foreach($model as $value){
                    $data = $data . '<td>' . htmlspecialchars($value) . '</td>';
                }
                $data = $data . "<td>" . \SoftUni\Helpers\HelpFunctions::anchor('users', 'buildings', array($model['building_id']) ,'[Evolve]') . "</td>";
                $data = $data . "<tr>";
            }
            $data = $data . '</table>';

            return $data;
        }

        return false;
    }

}