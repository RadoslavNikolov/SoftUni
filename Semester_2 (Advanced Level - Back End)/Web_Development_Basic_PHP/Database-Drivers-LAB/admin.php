<?php
require_once 'translations.php';
require_once 'Localization.php';
$db = SingletonDB::getInstance();
$resTranslations = $db->query("
SELECT id, tag, text_en, text_bg FROM translations
");
$translations = $resTranslations->fetchAll(PDO::FETCH_ASSOC);
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Translation Class Exercise</title>
</head>
<header>

</header>
<body>
<form action="translations.php" method="POST">
    <?php foreach($translations as $translation): ?>
    <div class="spurce-translation">
        <?= $translation['text_' . Localization::$LANG_DEFAULT]; ?>
        <?php foreach($translation as $key => $value): ?>
            <?php  if(substr($key, 0, 5 ) === "text_" && $key != 'text_' . Localization::$LANG_DEFAULT) : ?>
                <div><textarea name="<?= $key . "[" . $translation['id'] . "]"?>" id="" cols="30" rows="10"><?= $value?></textarea></div>
            <?php endif ?>
        <?php endforeach ?>
    </div>
    <?php endforeach ?>
    <input type="submit" name="save" value="Save"/>
</form>
</body>
</html>


