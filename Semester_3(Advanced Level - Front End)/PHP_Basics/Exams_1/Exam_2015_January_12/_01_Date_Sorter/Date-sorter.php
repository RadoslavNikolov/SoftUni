<?php
date_default_timezone_set("Europe/Sofia");
$input = $_GET['list'];
$currDate = date_create($_GET['currDate']);

$inputArr = preg_split('/\\r?\\n/',$input,-1,PREG_SPLIT_NO_EMPTY);
$dateArray = [];
foreach($inputArr as $date) {
    if($date == 'date') {
        continue;
    }
    $tempDate = date_create($date);
    if($date != '' && $tempDate) {
        $dateArray[] = $tempDate;
    }
}
sort($dateArray);
//var_dump($dateArray);
if(!empty($dateArray)) {
    echo "<ul>";
    foreach($dateArray as $date) {
        echo "<li>";
        if($date < $currDate) {
            echo "<em>" . htmlspecialchars(date_format($date,'d/m/Y')) . "</em>";
        } else {
            echo "" . htmlspecialchars(date_format($date,'d/m/Y'));
        }
        echo "</li>";
    }
    echo "</ul>";
}
