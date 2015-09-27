<?php
$file = './uploads/Chrysanthemum.jpg';

if (file_exists($file)) {
    // Show the image in the browser
    header('Content-Type: image/jpeg');
    header('Content-Disposition: inline; filename='.basename($file));
    header('Content-Length: ' . filesize($file));
    readfile($file);
}else{
    echo "{$file} does not exists.";
}