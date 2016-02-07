<?php

$string = 'abcdefghijklmnopqrstuvwxyz0abc123456789abc';

echo preg_match("/abc/", $string) . "\n";
$temp =  strpos($string, "abc");
var_dump($temp);
echo $temp!== false ? $temp : "No match";
echo "\n" . strpbrk($string, "abc");


//match the beginning of the string
echo "\n";
if(preg_match("/^abc/", $string)) {
    echo 'The string begins with abc';
} else {
    echo "No match found";
}

//match the beginning of the string case in-sensitive

echo "\n";
if(preg_match("/^ABC/i", $string)) {
    echo 'The string begins with abc';
} else {
    echo "No match found";
}

//match at the end of the string

echo "\n";
if(preg_match("/ABC\\z/i", $string)) {
    echo 'The string end with abc';
} else {
    echo "No match found";
}