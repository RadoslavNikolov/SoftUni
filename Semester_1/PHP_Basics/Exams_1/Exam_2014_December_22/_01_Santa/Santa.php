<?php
$childName = trim($_GET['childName']);
$wantedPresent = trim($_GET['wantedPresent']);
$riddlesArray = explode(";",trim($_GET['riddles']));

$childName = preg_replace("/\\s+/","-",$childName);
$wantedIndex = 0;
for ($i = 1; $i < strlen($childName); $i++) {
    $wantedIndex++;
    if($wantedIndex >= count($riddlesArray)) {
        $wantedIndex = 0;
    }

}
//var_dump(strlen($childName));
//var_dump($wantedIndex);

echo "\$giftOf" . htmlspecialchars($childName) . " = $[wasChildGood] ? '" . htmlspecialchars($wantedPresent) . "' : '" . htmlspecialchars($riddlesArray[$wantedIndex]) . "';";