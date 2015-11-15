<?php
/**
 * Created by PhpStorm.
 * User: radko
 * Date: 1.10.2015 г.
 * Time: 11:13
 */

namespace ShoppingCart\Helpers;


class Validations {

    public static function viewModelValidation($model, $file){
        $f = fopen($file, 'r');
        $line = fgets($f);
        fclose($f);

        preg_match_all('/(@\w+)(.*)\r?\n/', $line, $matches);

        if(!empty($matches[1]) && !empty($matches[2])){
            $annotation = trim(preg_replace('/\s\s+/', '', $matches[1][0]));
            $content = trim(preg_replace('/\s\s+/', '', $matches[2][0]));
            $modelInstance = preg_split('/\s+/', $content)[0];

            if($annotation == '@var'){
                if($model instanceof $modelInstance){
                    return true;
                }

                throw new \Exception("Submitted model was not right instance.");
            }
        }


        return true;
    }
}