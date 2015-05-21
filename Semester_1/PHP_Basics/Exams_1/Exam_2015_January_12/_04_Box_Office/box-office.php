<?php
$inputArray = preg_split("/\r?\n/",$_GET['list'],-1,PREG_SPLIT_NO_EMPTY);
$minSeats = $_GET['minSeats'];
$maxSeats = $_GET['maxSeats'];
$genre = $_GET['filter'];
$order = $_GET['order'];

$primarySort = [];
$secondarySort = [];
$movies = [];

foreach($inputArray as $line) {
    preg_match_all("/(.*?)\\((.*?)\\)\\s*-\\s*(.*?)\\/\\s*(\\d+)/",trim($line),$matches);
    if(trim($matches[4][0]) < $minSeats || trim($matches[4][0]) > $maxSeats) continue;
    if(trim($matches[2][0]) != $genre && $genre != 'all') continue;
    $movies[] = [
        'name' => trim($matches[1][0]),
        'genre' => trim($matches[2][0]),
        'stars' => trim($matches[3][0]),
        'seats' => intval($matches[4][0])
    ];
    $primarySort[] = trim($matches[1][0]);
    $secondarySort[] = intval($matches[4][0]);
}

$sort = SORT_ASC;
if($order === 'descending') {
    $sort = SORT_DESC;
}
array_multisort($primarySort,$sort,$secondarySort,SORT_ASC,$movies);

foreach($movies as $movie) {
    $stars = explode(",", $movie['stars']);

    echo '<div class="screening"><h2>' . htmlspecialchars(trim($movie['name'])) . '</h2><ul>';
    foreach($stars as $star) {
        echo '<li class="star">' . htmlspecialchars(trim($star)) . '</li>';
    }
    echo '</ul>';
    echo '<span class="seatsFilled">' . $movie['seats'] . " seats filled</span>";
    echo "</div>";
}
