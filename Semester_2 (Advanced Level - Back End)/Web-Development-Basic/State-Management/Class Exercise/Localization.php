<?php
/**
 * Created by PhpStorm.
 * User: toshiba
 * Date: 9/17/2015
 * Time: 8:31 PM
 */

class Localization {
    const LANG_EN = 'en';
    const LANG_BG = 'bg';
    const LANG_DEFAULT = self::LANG_EN;

    public static $string = [
        'greeting_header_hello' => [
            self::LANG_EN => 'Hello',
            self::LANG_BG => 'Здравей'
        ],
        'informal_hello' => [
            self::LANG_EN => 'Hello',
            self::LANG_BG => "Здрасти"
        ],
        'welcome_message' => [
            self::LANG_EN => 'Welcome to our site',
            self::LANG_BG => 'Добре дошли в нашия сайт'
        ]
    ];


    static function __($tag){
        $lang = isset($_COOKIE['lang'])
            ? $_COOKIE['lang']
            : self::LANG_DEFAULT;

        return self::$string[$tag][$lang];
    }
}