<?php
date_default_timezone_set("Europe/Sofia");
$inputArray = preg_split("/\r?\n/", $_GET['text'], -1, PREG_SPLIT_NO_EMPTY);
$facebook = [];
foreach($inputArray as $line) {
    $lineArray = explode(";",trim($line));
//    var_dump($lineArray);
    $facebook[] = [
        'author' => trim($lineArray[0]),
        'date' => date_create($lineArray[1]),
        'post' => trim($lineArray[2]),
        'likes' => (int)$lineArray[3],
        'comments' => explode("/", trim($lineArray[4]))
    ];
}

usort($facebook, function($a, $b){
    return $a['date'] < $b['date'];
});

//var_dump($facebook);

foreach($facebook as $post) {
    $author = htmlspecialchars($post['author']);
    $date = $post['date']->format('j F Y');
    $status = htmlspecialchars($post['post']);
    $likes = $post['likes'];
    $comments = $post['comments'];

    echo "<article><header><span>$author</span><time>$date</time></header>";
    echo "<main><p>$status</p></main>";
    echo '<footer><div class="likes">' . $likes . ' people like this</div>';
//    var_dump($post['comments']);

    if(!empty($comments) && !empty($comments[0])) {
        echo '<div class="comments">';
        foreach($comments as $comment) {
            echo "<p>" . htmlspecialchars(trim($comment)) . "</p>";
        }
        echo "</div>";
    }
    echo "</footer></article>";
}