<?php

$inputArr = explode("C|_|",trim($_GET['luggage']));
$typeLuggage = $_GET['typeLuggage'];
$room = trim($_GET['room']);
$minWeight = $_GET['minWeight'];
$maxWeight = $_GET['maxWeight'];

//var_dump($inputArr);
//var_dump($typeLuggage);
$output = [];

foreach($inputArr as $line) {
    $splitLineArr = explode(';',$line);
    $tempType = $splitLineArr[0];
    $tempRoom = $splitLineArr[1];
    $tempPieces = $splitLineArr[2];
    $tempWeight = (int)$splitLineArr[3];

    if(!in_array($tempType,$typeLuggage)){
        continue;
    }
    if($room !== $tempRoom) {
        continue;
    }
    if (!array_key_exists($tempType, $output) ||
        !array_key_exists($tempRoom, $output[$tempType])) {
        $output[$tempType][$tempRoom]['luggagePieces'][] = $tempPieces;
        $output[$tempType][$tempRoom]['weight'] = $tempWeight;

    } else {

        $output[$tempType][$tempRoom]['luggagePieces'][] = $tempPieces;
        $output[$tempType][$tempRoom]['weight'] += $tempWeight;
    }
}
ksort($output);

foreach ($output as $key => $value) {
//    var_dump($value[$room]['luggagePieces']);
    usort($value[$room]['luggagePieces'], function($a, $b){
        return strcmp($a, $b);
    });
    $output[$key] = $value;
}

echo '<ul>';
foreach ($output as $key => $value) {
    if ($value[$room]['weight'] < $minWeight ||
        $value[$room]['weight'] > $maxWeight)
    { continue; }
    $weight = $value[$room]['weight'];
    echo '<li><p>'. $key .'</p>';
    echo '<ul><li><p>'. $room .'</p>';
    echo '<ul><li><p>'. implode(', ', $value[$room]['luggagePieces']) .' - '. $weight .'kg</p>';
    echo '</li></ul></li></ul></li>';
}
echo '</ul>';


