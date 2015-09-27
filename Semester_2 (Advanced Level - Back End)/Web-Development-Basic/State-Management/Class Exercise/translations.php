<?php
require_once 'Localization.php';

if(isset($_GET['lang'])){
    $lang = $_GET['lang'];

    if($lang != Localization::LANG_BG && $lang!=Localization::LANG_EN){
        throw new Exception('Wrong language!');
    }

    setcookie('lang', $lang);
    $_COOKIE['lang'] = $lang;


}


