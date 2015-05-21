<?php
$input = trim($_GET['list']);
$length = intval($_GET['length']);
$show = isset($_GET['show']);

$inputArray = preg_split("/\r?\n/",$input,-1,PREG_SPLIT_NO_EMPTY);
if(!empty($inputArray)) {
    echo "<ul>";
    foreach($inputArray as $user) {
        if(strlen(trim($user)) >= $length) {
            echo "<li>" . htmlspecialchars(trim($user)) . "</li>";
        } else {
            if($show) {
                echo '<li style="color: red;">' . htmlspecialchars(trim($user)) . "</li>";
            }
        }
    }
    echo "</ul>";
}
