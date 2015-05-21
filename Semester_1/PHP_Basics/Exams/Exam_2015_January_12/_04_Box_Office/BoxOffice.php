<?php
$inputArray = preg_split("/\r?\n/",$_GET['list'],-1,PREG_SPLIT_NO_EMPTY);

$order = $_GET['order'];
$genre = $_GET['filter'];
$minSeats = $_GET['minSeats'];
$maxSeats = $_GET['maxSeats'];

$movies = [];

foreach($inputArray as $line) {
    preg_match_all("/(.*?)\\((.*?)\\)-\\s*(.*?)\\/\\s+(\\d+)/", trim($line),$maches);
//    var_dump($maches);

    if(trim($maches[4][0]) < $minSeats || trim($maches[4][0]) > $maxSeats) continue;
    if(trim($maches[2][0]) != $genre && $genre != 'all') continue;

    $movies[] = [
        'name' => trim($maches[1][0]),
        'genre' => trim($maches[2][0]),
        'stars' => trim($maches[3][0]),
        'seats' => intval(trim($maches[4][0]))
    ];
}

usort($movies, function($a, $b) use ($order) {
    $compare = strcmp($a['name'], $b['name']);
    if($compare === 0) {
        return $a['seats'] > $b['seats'];
    }
    if($order == 'descending') {
        $compare *= -1;
    }
    return $compare;
});

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

