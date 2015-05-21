<?php
$childName = trim($_GET['childName']);
$wantedPresent = trim($_GET['wantedPresent']);
$riddles = explode(';',trim($_GET['riddles']));

$childName = str_replace(' ','-',$childName);
$output = "\$giftOf" . htmlspecialchars($childName) . " = $[wasChildGood] ? '" . htmlspecialchars($wantedPresent) . "' : '";
//$riddleIndex = strlen($childName) % count($riddles);
//if($riddleIndex == 0) {
//    $riddleIndex = count($riddles) - 1;
//} else {
//    $riddleIndex = $riddleIndex - 1;
//}
$riddleIndex = 0;
for ($i = 1; $i < strlen($childName); $i++) {
  $riddleIndex++;
    if($riddleIndex >= count($riddles)){
        $riddleIndex = 0;
    }
}
$output .= $riddles[$riddleIndex] . "';";
echo $output;