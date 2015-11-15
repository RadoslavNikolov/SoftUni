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

}