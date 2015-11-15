<?php
namespace ShoppingCart\Helpers\Partials;


use ShoppingCart\Helpers\HelpFunctions;

class PartialAside
{
    private static $aside = null;

    public static function create()
    {
        if (self::$aside == null)
        {
            self::createAside();
        }

        return self::$aside;
    }


    private static function createAside(){
        if(empty($_SESSION)){
            $code = '<aside><div id="acdnmenu">You must first login</div>div></aside>';

            self::$aside = $code;
            return;
        }

        $content = file_get_contents('Resources\asideCategoriesJson.json',TRUE);
        $categories = json_decode($content, true);

        $code = '<aside><div id="acdnmenu"><ul><li id="main-li">';

        foreach($categories as $key => $root){
            $code = $code . '<li>' . HelpFunctions::anchor('products', 'byName', [$key], ucfirst($key));
            $code = $code . '<ul>';

            foreach($root as $key1 => $root1){
                $code = $code . '<li>' . HelpFunctions::anchor('products', 'byName', [$key1], ucfirst($key1));
                $code = $code . '<ul>';
                foreach($root1 as $key2 => $root2){
                    $code = $code . '<li>' . HelpFunctions::anchor('products', 'byName', [$key2], ucfirst($key2));
                    $code = $code . '<ul>';

                    foreach($root2 as $key3=> $root3){
                        $code = $code . '<li>' . HelpFunctions::anchor('products', 'byName', [$key3], ucfirst($key3)) . '</li>';
                    }

                    $code = $code . '</ul>';
                    $code = $code . '</li>';
                }

                $code = $code . '</ul>';
                $code = $code . '</li>';
            }

            $code = $code . '</ul>';
            $code = $code . '</li>';
        }

        $code = $code . '</li></ul></div></aside>';

        self::$aside = $code;
    }

    public static function clearAside(){
        self::$aside = null;
    }
}