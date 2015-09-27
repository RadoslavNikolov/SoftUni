<h1>Hello, <?= htmlspecialchars($data->getUsername()); ?></h1>

<?php if(isset($_GET['error'])): ?>
    <h2>An error occurred</h2>
<?php elseif(isset($_GET['success'])): ?>
    <h2>Successfully updated profile</h2>
<?php endif ?>


<h3>
    Resources:
    <p>Gold: <?= $data->getGold(); ?></p>
    <p>Food: <?= $data->getFood(); ?></p>
</h3>

<form action="" method="post">
    <div>
        <input type="text" name="username" value="<?= htmlspecialchars($data->getUsername()); ?>"/>
        <input type="password" name="password"/>
        <input type="password" name="confirm"/>
        <input type="submit" name="edit" value="Edit"/>
        <input type="hidden" name="formToken" value="<?= htmlspecialchars($_SESSION['formToken'])?>">
    </div>
</form>

Go to:
<div>
    <a href="buildings.php">Buildings</a>
</div>

<div>
    <a href="logout.php">[Logout]</a>
</div>