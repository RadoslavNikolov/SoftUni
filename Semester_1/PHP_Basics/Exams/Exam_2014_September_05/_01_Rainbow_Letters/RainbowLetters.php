<?php
$inputText = $_GET['text'];
$red = (int)$_GET['red'];
$green = (int)$_GET['green'];
$blue = (int)$_GET['blue'];
$n = (int)$_GET['nth'];

$red = str_pad(dechex((int)$red),2,"0");
$green = str_pad(dechex((int)$green),2,"0");
$blue = str_pad(dechex((int)$blue),2,"0");
$color = "#" . $red . $green . $blue;
$output = "<p>";
for ( $i = 0; $i < strlen($inputText); $i++) {
    $letter = htmlspecialchars($inputText[$i]);
    if(($i+1) % $n === 0) {
        $output .= "<span style=\"color: {$color}\">{$letter}</span>";
    } else {
        $output .= $letter;
    }
}
$output .= "</p>";
echo $output;