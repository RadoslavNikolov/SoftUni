<?php
require_once 'Localization.php';
$possibleLanguages = Localization::getLang();
Localization::$LANG_DEFAULT = $possibleLanguages[0];

if(isset($_GET['lang'])){
    $lang = $_GET['lang'];

    if(!in_array($lang, $possibleLanguages)){
        throw new Exception('Wrong language!');
    }

    setcookie('lang', $lang);
    $_COOKIE['lang'] = $lang;
}

if(isset($_POST['save'])){

    foreach($_POST as $tag => $value){

        foreach($value as $id => $text){
            var_dump($tag, $text, $id);
            $query = SingletonDB::getInstance()->query("UPDATE translations SET ? = ? WHERE id = ? ", [$tag, $text, $id]);
        }
    }

}

