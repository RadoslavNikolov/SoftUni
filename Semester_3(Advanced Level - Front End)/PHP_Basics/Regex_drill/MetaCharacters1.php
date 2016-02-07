<?php

$string = 'This is a [templateVar]';

preg_match_all("/[\\[\\]]/",$string,$matches);

foreach($matches[0] as $value) {
    echo $value;
}

preg_match_all("/[^\\[\\]]/",$string,$matches);
echo "\n";
foreach($matches[0] as $value) {
    echo $value;
}

$string = 'sex at noon taxes';
echo "\n";
echo preg_match("/s.x/",$string,$matches);


$string = 'sex'."\n".'at'."\n".'noon'."\n".'taxes'."\n";
echo "\n";
echo nl2br($string);
echo preg_match_all("/\\s/",$string,$matches);


$string = 'php';
echo "\n" . preg_match("/ph*p/",$string,$matches);
echo "\n" . preg_match("/ph+p/",$string,$matches);

$string = 'PHP123';
echo "\n" . preg_match("/PHP[0-9]{3}/",$string,$matches);