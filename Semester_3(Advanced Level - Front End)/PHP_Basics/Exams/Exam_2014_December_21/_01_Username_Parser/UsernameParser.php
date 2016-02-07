<?php
$inputText = trim($_GET['list']);
$length = $_GET['length'];
$show = isset($_GET['show']);
$inputArr = explode("\n",$inputText);
//var_dump($inputArr);
//var_dump($length);

echo "<ul>";
foreach($inputArr as $username){
    $username = trim($username);
    if(strlen($username) < $length) {
        if($show){
            echo "<li style=\"color: red;\">" . htmlspecialchars($username) . "</li>";
        }
    } else {
        echo "<li>" . htmlspecialchars($username) . "</li>";
    }
}
echo "</ul>";