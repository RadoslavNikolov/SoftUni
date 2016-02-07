<?php
date_default_timezone_set('Europe/Sofia');
$inputArr = preg_split("/\r?\n/", $_GET['messages']);
$currDate = strtotime(trim($_GET['currentDate']));
$output = [];

$latestTime = 0;
foreach($inputArr as $line) {
    $tempArr = preg_split("/\\s+\\/\\s+/", trim($line), -1, PREG_SPLIT_NO_EMPTY);
    $message = $tempArr[0];
    $tempDate = strtotime($tempArr[1]);
    $output[$tempDate] = $message;
    if ($tempDate > $latestTime) {
        $latestTime = $tempDate;
    }
}
ksort($output);
//var_dump($output);
foreach($output as $key => $value) {
    echo "<div>" . htmlspecialchars($value) . "</div>\n";
}

$timestamp = getTimeMark($latestTime, $currDate);
echo "<p>Last active: <time>$timestamp</time></p>";

function getTimeMark($latestTime, $currDate) {
    $timeDiff = $currDate - $latestTime;
    $timeStamp = '';

    $lastDay = date('z',$latestTime);
    $currDay = date('z',$currDate);
    if($lastDay == $currDay) {
        if( $timeDiff < 60) {
            $timeStamp = 'a few moments ago';
        } else if($timeDiff < 60 * 60) {
            $minutes = floor($timeDiff / 60);
            $timeStamp = "$minutes minute(s) ago";
        } else if($timeDiff < 60 * 60 * 24) {
            $hours = floor($timeDiff / (60 * 60));
            $timeStamp = "$hours hour(s) ago";
        }
    } else if($lastDay + 1 == $currDay) {
        $timeStamp = 'yesterday';
    } else {
        $timeStamp = date('d-m-Y', $latestTime);
    }

    return $timeStamp;
}