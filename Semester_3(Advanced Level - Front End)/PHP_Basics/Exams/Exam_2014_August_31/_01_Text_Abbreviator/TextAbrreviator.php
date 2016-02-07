<?php
$inputStr = trim($_GET['list']);
$maxSize = $_GET['maxSize'];
$inputArr = explode("\n",$inputStr);
$output = "<ul>";

foreach($inputArr as $str) {
    $string = trim($str);
    if(strlen($string) > 0) {
        if(strlen($string) > $maxSize) {
            $string = substr($string,0,$maxSize) . "...";
        }
        $output .= "<li>" . htmlspecialchars($string) . "</li>";
    }
}
$output .= "</ul>";
echo $output;