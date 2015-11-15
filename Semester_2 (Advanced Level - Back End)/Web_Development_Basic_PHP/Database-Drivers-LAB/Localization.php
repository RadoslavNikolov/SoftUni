<?php
require_once 'SingletonDB.php';


class Localization {
    const LANG_EN = 'en';
    const LANG_BG = 'bg';
    static $LANG_DEFAULT;

    static function __($tag){
        $lang = isset($_COOKIE['lang'])
            ? $_COOKIE['lang']
            : self::LANG_DEFAULT;

        $query = SingletonDB::getInstance()->query("
            SELECT
                text_{$lang}
            FROM
                translations
            WHERE
                tag = ?;
        ", [$tag]);

        $row = $query->fetch(PDO::FETCH_NUM);

        return $row[0];
    }

    static function getLang(){
        $query = SingletonDB::getInstance()->query("SHOW COLUMNS FROM translations");
        $res = $query->fetchAll(PDO::FETCH_ASSOC);

        $count = 1;
        $possibleLanguages = array();

        foreach($res as $c => $column){
            if(substr( $column['Field'], 0, 5 ) === "text_" ){
                $possibleLanguages[] = str_replace('text_','',$column['Field'],$count);
            }
        }

        return $possibleLanguages;
    }
}