<?php
$inputText = trim($_GET['list']);
$currDateStr = trim($_GET['currDate']);
$currDate = date_create($currDateStr, timezone_open("Europe/Sofia"));
$inputArr = explode("\n",$inputText);
$dates = [];
foreach($inputArr as $line) {
    $line = trim($line);
    $tempDate = date_create($line, timezone_open("Europe/Sofia"));
    if ($line != "" && $tempDate) {
        $dates[] = $tempDate;
    }
}
sort($dates);
echo "<ul>";
foreach($dates as $date) {
    if($date < $currDate) {
        echo "<li><em>" . htmlspecialchars(date_format($date,"d/m/Y")) . "</em></li>";
    } else {
        echo "<li>" . htmlspecialchars(date_format($date,"d/m/Y")) . "</li>";
    }
}
echo "</ul>";
