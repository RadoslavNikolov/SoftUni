<?php
date_default_timezone_set("Europe/Sofia");
$input = $_GET['text'];
preg_match_all('/(.*?)\s*%\s*(.*?)\s*;\s*(\d{2}-\d{2}-\d{4})\s*-\s*(.*)/',$input,$matches);
//var_dump($matches);
$output = [];
if(count($matches) === 5) {
    for ($i = 0; $i < count($matches[1]); $i++) {
        $articleName = htmlspecialchars(trim($matches[1][$i]));
        if(!preg_match('/[A-Za-z\s-]+/',$articleName)){
            continue;
        }
        $author = htmlspecialchars(trim($matches[2][$i]));
        if(!preg_match('/[A-Za-z.\s-]+/',$author)){
            continue;
        }
        $date = date_create(trim($matches[3][$i]));
        $date = $date->format('F');
        $article = htmlspecialchars(trim($matches[4][$i]));
        if(strlen($article) > 100) {
            $article = substr($article,0,100);
        }

        $output[] = "<div>\n" .
            "<b>Topic:</b> <span>$articleName</span>\n" .
            "<b>Author:</b> <span>$author</span>\n" .
            "<b>When:</b> <span>$date</span>\n" .
            "<b>Summary:</b> <span>$article...</span>\n" .
            "</div>";
    }
    echo implode("\n",$output);
}
