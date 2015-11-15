<?php
session_start();
if (isset($_SESSION['username'])) : ?>
    <h1>Welcome  <?= htmlspecialchars($_SESSION['username'])?> </h1>
    <div class="logout"><a href="logout.php">[Logout]</a></div>
<?php else :
    header('Location: login.php');
    die;
endif; ?>
