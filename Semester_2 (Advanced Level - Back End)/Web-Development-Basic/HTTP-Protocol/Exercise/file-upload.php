<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>File Upload</title>
</head>
<body>
<strong>Upload File</strong>
<form action="file-upload.php" method="post" enctype="multipart/form-data">
    Select image to upload:
    <input type="file" name="fileToUpload" id="fileToUpload"/>
    <input type="submit" value="Upload Image" name="submit">
</form>
</body>
</html>
<?php

$target_dir = "uploads/";

var_dump($_FILES);
var_dump($_FILES['fileToUpload']);

$target_file = $target_dir . basename($_FILES['fileToUpload']['name']);
$uploadOK = 1;
$imageFileType = pathinfo($target_file, PATHINFO_EXTENSION);
var_dump($imageFileType);

//Check if image file is actual img or fake one.
if (isset($_POST['submit'])) {
    $check = getimagesize($_FILES['fileToUpload']['tmp_name']);
    var_dump($check);

    if ($check !== false) {
        echo 'File is an image - ' . $check['mime'] . '.';
    }else{
        echo 'File is not an image.';
        $uploadOK = 0;
    }

    //Check if file already exists
    if (file_exists($target_file)) {
        echo "<br> Sorry, file already exists.";
        $uploadOK = 0;
    }
    
    //Check file size and use limit
    if ($_FILES['fileToUpload']['size'] > 1700000) {
        echo "<br>Sorry, your file is to large.";
        $uploadOK = 0;
    }

    //Limit file type
    if ($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg" && $imageFileType != "gif") {
        echo "<br>Sorry, only JPG, JPEG, PNG and GIF file are allowed.";
        $uploadOK = 0;
    }

    if ($uploadOK == 0) {
        echo "<br>Sorry, your file was not uploaded.";
    }else {
        if (move_uploaded_file($_FILES['fileToUpload']['tmp_name'], $target_file)){
//
            //Other way to save file in target destination
//            $file = file($target_file);
//            file_put_contents($target_file, $file);
            echo "<br>The file " . basename($_FILES['fileToUpload']['name']) . " has been uploaded";
        }else{
            echo "Sorry, there was an error uploading your file.";
        }
    }
}