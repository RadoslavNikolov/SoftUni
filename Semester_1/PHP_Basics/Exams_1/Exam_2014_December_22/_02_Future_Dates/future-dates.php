<?php
date_default_timezone_set('Europe/Sofia');
preg_match_all("/[^a-zA-Z0-9](\\d+)[^a-zA-Z]/",$_GET['numbersString'],$numMatches);
preg_match_all("/(\\d{4}-\\d{2}-\\d{2})/",$_GET['dateString'],$dateMatches);

//var_dump($numMatches);
//var_dump($dateMatches);
$sum = 0;
if(!empty($numMatches[1])) {
    foreach($numMatches[1] as $number) {
        $sum += $number;
    }
}
$sum = strrev($sum);
if(!empty($dateMatches[1])) {
    echo "<ul>";
    foreach($dateMatches[1] as $date) {
        $tempDate = date_create($date);
        $timeModifier = "+{$sum} day";
        $tempDate->modify($timeModifier);
        echo "<li>" . htmlspecialchars($tempDate->format('Y-m-d')) . "</li>";
    }
    echo "</ul>";
} else {
    echo "<p>No dates</p>";
}
