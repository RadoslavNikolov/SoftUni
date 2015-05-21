<?php
$input = preg_split("/\\r?\\n/",$_GET['text'],-1,PREG_SPLIT_NO_EMPTY);
$artistFilter = trim($_GET['artist']);
$property = trim($_GET['property']);
$order = trim($_GET['order']);
//var_dump($property);
$iTunes = [];
$output = [];
foreach($input as $line) {
    $lineArray = explode("|",$line);
    $name = trim($lineArray[0]);
    $genre = trim($lineArray[1]);
    $artists = explode(", ",trim($lineArray[2]));
    sort($artists);
    $downloads = (int)trim($lineArray[3]);
    $rating = (float)trim($lineArray[4]);
    if(!in_array($artistFilter,$artists)) continue;

    $iTunes[] = [
        'name' => $name,
        'genre' => $genre,
        'artists' => $artists,
        'downloads' => $downloads,
        'rating' => $rating
    ];
}


usort($iTunes, function($a, $b) use ($order, $property) {
    switch($property) {
        case 'name' :
            if ($a['name'] == $b['name']) {
                return strcmp($a['name'], $b['name']);
            }
            return ($order == "ascending" ^ $a['name'] < $b['name']) ? 1 : -1;
        break;
        case 'genre' :
            if ($a['genre'] == $b['genre']) {
                return strcmp($a['name'], $b['name']);
            }
            return ($order == "ascending" ^ $a['genre'] < $b['genre']) ? 1 : -1;
            break;
        case 'downloads' :
            if ($a['downloads'] == $b['downloads']) {
                return strcmp($a['name'], $b['name']);
            }
            return ($order == "ascending" ^ $a['downloads'] < $b['downloads']) ? 1 : -1;
            break;
        case 'rating' :
            if ($a['rating'] == $b['rating']) {
                return strcmp($a['name'], $b['name']);
            }
            return ($order == "ascending" ^ $a['rating'] < $b['rating']) ? 1 : -1;
            break;
        default: break;

    }
});

$output[] = "<table>\n" .
    "<tr><th>Name</th><th>Genre</th><th>Artists</th><th>Downloads</th><th>Rating</th></tr>\n";

foreach($iTunes as $song) {
    $output[] = "<tr><td>" . htmlspecialchars($song['name']) . "</td><td>" . htmlspecialchars($song['genre']) . "</td><td>" . htmlspecialchars(implode(", ",$song['artists'])) . "</td><td>" . $song['downloads'] . "</td><td>" . $song['rating'] . "</td></tr>\n";

}
$output[] = "</table>";

foreach($output as $line) {
    echo $line;
}

