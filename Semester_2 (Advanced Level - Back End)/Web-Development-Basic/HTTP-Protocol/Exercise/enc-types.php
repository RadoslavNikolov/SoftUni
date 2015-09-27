<strong>application/x-www-form-urlencoded:</strong>
<form action="enc-types.php" method="post" enctype="application/x-www-form-urlencoded">
    Name:
    <input type="text" name="name">
    <input type="file" name="file"/>
    <input type="submit" value="Upload" name="submit">
</form>

<strong>multipart/form-data:</strong>
<form action="enc-types.php" method="post" enctype="multipart/form-data">
    Name:
    <input type="text" name="name">
    <input type="file" name="file"/>
    <input type="submit" value="Upload" name="submit">
</form>

<strong>text/plain:</strong>
<form action="enc-types.php" method="post" enctype="text/plain">
    Name:
    <input type="text" name="name">
    <input type="file" name="file"/>
    <input type="submit" value="Upload" name="submit">
</form>

<?php
echo "POST:<br>";
var_dump($_POST);

echo "Request:<br>";
var_dump($_REQUEST);

echo "Files:<br>";
var_dump($_FILES);
