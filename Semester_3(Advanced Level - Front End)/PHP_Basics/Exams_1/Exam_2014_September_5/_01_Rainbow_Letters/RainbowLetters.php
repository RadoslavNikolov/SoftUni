<?php
$input = $_GET['text'];
$red = $_GET['red'];
$green = $_GET['green'];
$blue = $_GET['blue'];
$nth = $_GET['nth'];

$red = str_pad(dechex($red),2,"0",STR_PAD_LEFT);
$green = str_pad(dechex($green),2,"0",STR_PAD_LEFT);
$blue = str_pad(dechex($blue),2,"0",STR_PAD_LEFT);
$color = "#" . $red . $green . $blue;
//var_dump($color);
echo "<p>";
for ($i = 1; $i <= strlen($input) ; $i++) {
    if($i % $nth === 0) {
        echo '<span style="color: ' . $color . '">' .  htmlspecialchars($input[$i-1]) .'</span>';
    } else {
        echo "" . htmlspecialchars($input[$i-1]);
    }
}
echo "</p>";
