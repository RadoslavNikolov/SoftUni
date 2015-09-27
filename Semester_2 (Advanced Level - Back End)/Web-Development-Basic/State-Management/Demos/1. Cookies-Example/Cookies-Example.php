<!DOCTYPE html>
<html>
<body>
<?php
var_dump($_COOKIE);
if (isset($_COOKIE["user"])) :
    echo "Welcome " . $_COOKIE["user"] . "!";
else :
    echo "Welcome guest!";
endif;
setcookie("user", "Nakov", time() + 5); // expires in 5 sec.
$_COOKIE['user'] = 'Nakov';
?>
</body>
</html>
