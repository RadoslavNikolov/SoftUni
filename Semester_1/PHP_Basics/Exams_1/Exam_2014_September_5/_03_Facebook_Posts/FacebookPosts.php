<?php
date_default_timezone_set("Europe/Sofia");
$input = $_GET['text'];
$inputArray = preg_split("/\r?\n/",$input,-1,PREG_SPLIT_NO_EMPTY);
//var_dump($inputArray);
$primarySort = [];
$logsArray = [];
foreach($inputArray as $line) {
    $lineArray = preg_split("/\\s*\\;\\s*/",$line,-1,PREG_SPLIT_NO_EMPTY);
    $author = trim($lineArray[0]);
    $date = date_create($lineArray[1]);
    $post = trim($lineArray[2]);
    $likes = (int)$lineArray[3];

    if(isset($lineArray[4])) {
        $commentsArray = preg_split("/\\s*\\/\\s*/",$lineArray[4],-1,PREG_SPLIT_NO_EMPTY);
    } else {
        $commentsArray = [];
    }

    $primarySort[] = $date;
    $logsArray[] = [
        'author' => $author,
        'date' => $date,
        'post' => $post,
        'likes' => $likes,
        'comments' => $commentsArray
    ];
}
array_multisort($primarySort,SORT_DESC,$logsArray);

//print
foreach($logsArray as $post) {
    $author = htmlspecialchars($post['author']);
    $date = $post['date']->format('j F Y');
    $status = htmlspecialchars($post['post']);
    $likes = $post['likes'];
    $comments = $post['comments'];
    echo "<article><header><span>$author</span><time>$date</time></header>";
    echo "<main><p>$status</p></main>";
    echo '<footer><div class="likes">' . $likes . ' people like this</div>';
    if(!empty($comments) && !empty($comments[0])) {
        echo '<div class="comments">';
        foreach($comments as $comment) {
            echo "<p>" . htmlspecialchars(trim($comment)) . "</p>";
        }
        echo "</div>";
    }
    echo "</footer></article>";
}
