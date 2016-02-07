<?php

$nationalities = ['Austrian', 'Bulgarian', 'Canadian', 'German', 'Israeli', 'Indian', 'Rumanian', 'Other'];

$skillLevels = ['Beginner', 'Intermediate', 'Advanced', 'Expert'];

$langLevels = ['A1', 'A2', 'B1', 'B2', 'C1', 'C2'];
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>CV generator</title>
    <link rel="stylesheet" href="CSS/style.css" type="text/css"/>
    <script src="JS/script.js" type="text/javascript" defer></script>
</head>
<body>
    <div id="wrapper">
        <form action="" method="POST">
            <fieldset id="personal-info">
                <legend>Personal Information</legend>
                <input type="text" name="first-name" id="first-name" required="true" placeholder="First Name"/>
                <input type="text" name="last-name" id="last-name" required="true" placeholder="Last name"/>
                <input type="email" name="email" id="email" required="true" placeholder="Email"/>
                <input type="tel" name="telephone" id="telephone" required="true" placeholder="Phone Number"/>

                <label for="female">Female</label>
                <input type="radio" id="female" name="gender" value="female" required/>
                <label for="male">Male</label>
                <input type="radio" id="male" name="gender" value="male"/>

                <p>Birth Date</p>
                <input type="date" name="birth-date" id="birth-date"/>
                <p>Nationality</p>
                <select name="nationality" required>
                    <option selected value="" disabled>Choose Nationality</option>
                    <?php for ($i = 0; $i <count($nationalities) ; $i++):?>
                        <option value="<?= htmlentities($nationalities[$i]) ?>"> <?= htmlentities($nationalities[$i]) ?> </option>
                    <?php endfor; ?>
                </select>
            </fieldset>

            <fieldset>
                <legend>Last Work Position</legend>
                <label for="company">Company Name</label>
                <input type="text" id="company" name="company"/></br>
                <label for="start-work-date">From</label>
                <input type="date" id="start-work-date" name="start-work-date"/></br>
                <label for="end-work-date">To</label>
                <input type="date" id="end-work-date" name="end-work-date"/>
            </fieldset>

            <fieldset>
                <legend>Computer Skills</legend>
                <p>Programming languages</p>
                <div id="prog-lang" >
                    <div id="pr-lang-hidden" class="hidden">
                        <input type="text"/>
                        <select>
                            <option selected value="" disabled>-Skill Level-</option>
                            <?php for ($i = 0; $i <count($skillLevels) ; $i++):?>
                                <option value="<?= htmlentities($skillLevels[$i]) ?>"> <?= htmlentities($skillLevels[$i]) ?> </option>
                            <?php endfor; ?>
                        </select>
                        <input type="button" onclick="removeProgLanguage(''')" value="Remove Language"/>
                    </div>
                </div>
                <input type="button" onclick="addProgLanguage()" value="Add Language"/>
            </fieldset>

            <fieldset>
                <legend>Other Skills</legend>
                <p>Languages</p>
                <div id="lang" >
                    <div id="lang-hidden" class="hidden">
                        <input type="text"/>
                        <select>
                            <option selected value="" disabled>-Comprehension-</option>
                            <?php for ($i = 0; $i <count($langLevels) ; $i++):?>
                                <option value="<?= htmlentities($langLevels[$i]) ?>"> <?= htmlentities($langLevels[$i]) ?> </option>
                            <?php endfor; ?>
                        </select>
                        <select>
                            <option selected value="" disabled>-Reading-</option>
                            <?php for ($i = 0; $i <count($langLevels) ; $i++):?>
                                <option value="<?= htmlentities($langLevels[$i]) ?>"> <?= htmlentities($langLevels[$i]) ?> </option>
                            <?php endfor; ?>
                        </select>
                        <select>
                            <option selected value="" disabled>-Writing-</option>
                            <?php for ($i = 0; $i <count($langLevels) ; $i++):?>
                                <option value="<?= htmlentities($langLevels[$i]) ?>"> <?= htmlentities($langLevels[$i]) ?> </option>
                            <?php endfor; ?>
                        </select>
                        <input type="button" onclick="removeLanguage()" value="Remove Language"/>
                    </div>
                </div>
                <input type="button" onclick="addLanguage()" value="Add Language"/>
                <p>Driver`s License</p>
                <label for="B">B</label>
                <input type="checkbox" id="B" name="drv-license[]" value="B"/>
                <label for="A">A</label>
                <input type="checkbox" id="A" name="drv-license[]" value="A"/>
                <label for="C">C</label>
                <input type="checkbox" id="C" name="drv-license[]" value="C"/>
            </fieldset>
            <input type="submit" value="Generate CV">
        </form>
        <?php require 'CVGenerator.php'; ?>
    </div>
</body>
</html>