<?php
date_default_timezone_set('Europe/Sofia');
preg_match_all("/[^A-Za-z0-9](\\d+)[^A-Za-z]/",$_GET['numbersString'],$numbers);
$sum = 0;
foreach($numbers[1] as $num){
    $sum += $num;
}
$sum = strrev($sum);
//var_dump($sum);

preg_match_all("/(\\d{4}-\\d{2}-\\d{2})/",$_GET['dateString'],$dates);
//var_dump($dates);

if(empty($dates[1])) {
    echo "<p>No dates</p>";
} else {
    echo "<ul>";
    foreach($dates[1] as $dateStr) {
        $date = DateTime::createFromFormat('Y-m-d',$dateStr);
//        var_dump($date);
        $timeModifier = "+{$sum} day";
        $date->modify($timeModifier);
//        var_dump($date);
        echo "<li>" . htmlspecialchars($date->format('Y-m-d')) . "</li>";
    }
    echo "</ul>";
}
