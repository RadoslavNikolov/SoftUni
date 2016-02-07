<?php
    if(isset($_GET['categories'], $_GET['tags'], $_GET['months'], $_GET['submit'])) {
        $categoriesArr = explode(', ', $_GET['categories']);
        $tagsArr = explode(', ', $_GET['tags']);
        $monthsArr = explode(', ', $_GET['months']);
    }
?>
<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Sidebar Builder</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
</head>
<body>
    <div id="wrapper">
        <main>
            <form action="">
                <div class="input">
                    <label for="categories">Categories: </label>
                    <input type="text" id="categories" name="categories"/>
                </div>
                <div class="input">
                    <label for="tags">Tags: </label>
                    <input type="text" id="tags" name="tags"/>
                </div>
                <div class="input">
                    <label for="months">Months: </label>
                    <input type="text" id="months" name="months"/>
                </div>
                <div class="input">
                    <input type="submit" name="submit" value="Generate"/>
                </div>
            </form>

        </main>
        <aside>
            <section>
                <?php if(isset($categoriesArr) && count($categoriesArr) > 0): ?>
                <h2>Categories</h2>
                <ul>
                    <?php foreach($categoriesArr as $value): ?>
                        <li><a href=""><?= htmlentities($value)?></a></li>
                    <?php endforeach ?>
                </ul>
                <?php endif; ?>
            </section>
            <section>
                <?php if(isset($tagsArr) && count($tagsArr) > 0): ?>
                    <h2>Tags</h2>
                    <ul>
                        <?php foreach($tagsArr as $value): ?>
                            <li><a href=""><?= htmlentities($value)?></a></li>
                        <?php endforeach ?>
                    </ul>
                <?php endif; ?>
            </section>
            <section>
                <?php if(isset($monthsArr) && count($monthsArr) > 0): ?>
                    <h2>Months</h2>
                    <ul>
                        <?php foreach($monthsArr as $value): ?>
                            <li><a href=""><?= htmlentities($value)?></a></li>
                        <?php endforeach ?>
                    </ul>
                <?php endif; ?>
            </section>
        </aside>
    </div>
</body>
</html>