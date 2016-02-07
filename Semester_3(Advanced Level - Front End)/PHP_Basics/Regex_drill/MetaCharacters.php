<?php

$string = '1+1-2';

if(preg_match("/^1\\+1/i", $string)) {
    echo "There is match";
} else {
    echo 'There is no match';
}

$string = 'big';
echo "\n";
echo preg_match("/b[aoiu]g/",$string,$matches);


$string = 'abcefghijklmnopqrstuvwxyz0123456789';

preg_match("/[^b]/", $string,$matches);
var_dump($matches);
foreach($matches as $key=>$value) {
        echo $key . ' ->' . $value;
}

preg_match_all("/[^b]/",$string,$matches);
//var_dump($matches);
foreach($matches[0] as $value) {
    echo $value;
}

//foreach ($matches[0] as $value) {
//    echo $value . "\n";
//}

preg_match_all("/[^0-9]/",$string,$matches);
echo "\n";
foreach($matches[0] as $value) {
    echo $value;
}
