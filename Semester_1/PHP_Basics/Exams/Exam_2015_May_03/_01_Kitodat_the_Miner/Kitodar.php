<?php
$inputText = $_GET['data'];
$inputArr = preg_split("/\\s*,\\s*/",$inputText,-1, PREG_SPLIT_NO_EMPTY);
//var_dump($inputArr);
$output = [
    'gold' => 0,
    'silver' => 0,
    'diamonds' => 0
];

foreach($inputArr as $line) {
    preg_match_all("/mine\\s*(\\w+)\\s*(\\w+)\\s*(\\d+)/",trim($line),$matches);
    if(!empty($matches[0][0])) {
        $typeOfOre = strtolower(trim($matches[2][0]));
//        var_dump($typeOfOre);
        if($typeOfOre == 'gold' || $typeOfOre == 'silver' || $typeOfOre == 'diamonds') {
            $output[$typeOfOre] += (int)$matches[3][0];
        }
    }
}
foreach($output as $key => $ore) {
    echo "<p>*" . ucfirst($key) . ": " . $ore . "</p>";
}

//var_dump($output);
