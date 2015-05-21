<?php
if( isset($_POST['first-name'], $_POST['last-name'], $_POST['email'], $_POST['telephone'],
    $_POST['gender'], $_POST['birth-date'], $_POST['nationality'], $_POST['company'], $_POST['start-work-date'],
    $_POST['end-work-date'])):

    function validateFields($fields) {
        $pattern = [
            'name' => '/^[A-Za-z]{2,20}$/',
            'company' => '/^[A-Za-z\d]{2,20}$/',
            'phone' => '/^[\d+\- ]+$/',
            'email' => '/^[A-Za-z\d]+@[A-Za-z\d]+.[A-Za-z]+$/'
        ];

        if(!preg_match($pattern['name'], $fields['fName'])) {
            echo "<p>Only letters Between 2 and 20 symbols are allowed for First Name</p>";
            exit;
        }
        if(!preg_match($pattern['name'], $fields['lName'])) {
            echo "<p>Only letters Between 2 and 20 symbols are allowed for Last Name</p>";
            exit;
        }
        if(!preg_match($pattern['email'], $fields['email'])) {
            echo "<p>Only Letters, Numbers, one '@' and one '.' are allowed for Email</p>";
            exit;
        }
        if(!preg_match($pattern['phone'], $fields['phone'])) {
            echo "<p>Only numbers, +, - and space are allowed for Phone Number</p>";
            exit;
        }
        if(!preg_match($pattern['company'], $fields['company'])) {
            echo "<p>Only letters and numbers Between 2 and 20 symbols are allowed for Company Name</p>";
            exit;
        }
        foreach($fields['lang'] as $value) {
            if(isset($_POST['lang']) && !preg_match($pattern['name'], $value)) {
                echo "<p>Only letters Between 2 and 20 symbols are allowed for Language</p>";
                exit;
            }
        }
    }


$inputData = [
    'fName' => $_POST['first-name'],
    'lName' => $_POST['last-name'],
    'email' => $_POST['email'],
    'phone' => $_POST['telephone'],
    'gender' => $_POST['gender'],
    'birthDate' => $_POST['birth-date'],
    'nationality' => $_POST['nationality'],
    'company' => $_POST['company'],
    'startWorkDate' => $_POST['start-work-date'],
    'endWorkDate' => $_POST['end-work-date'],
    'pr-lang' => isset($_POST['pr-lang']) ? $_POST['pr-lang'] : ['-'],
    'pr-skill' => isset($_POST['pr-skill']) ? $_POST['pr-skill'] : ['-'],
    'lang' => isset($_POST['lang']) ? $_POST['lang'] : ['-'],
    'lang-comprehension' => isset($_POST['lang-comprehension']) ? $_POST['lang-comprehension'] : ['-'],
    'lang-reading' => isset($_POST['lang-reading']) ? $_POST['lang-reading'] : ['-'],
    'lang-writing' => isset($_POST['lang-writing']) ? $_POST['lang-writing'] : ['-'],
    'drvLicense' => isset($_POST['drv-license']) ? $_POST['drv-license'] : ['no'],
];
    validateFields($inputData);
//var_dump($inputData['lang']);
?>

<table  class="main">
    <thead>
        <tr>
            <th colspan="2">Personal Information</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>First Name</td>
            <td><?= htmlentities($inputData['fName']) ?></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><?= htmlentities($inputData['lName']) ?></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><?= htmlentities($inputData['email']) ?></td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td><?= htmlentities($inputData['phone']) ?></td>
        </tr>
        <tr>
            <td>gender</td>
            <td><?= htmlentities($inputData['gender']) ?></td>
        </tr>
        <tr>
            <td>Birth Date</td>
            <td><?= htmlentities($inputData['birthDate']) ?></td>
        </tr>
        <tr>
            <td>Nationality</td>
            <td><?= htmlentities($inputData['nationality']) ?></td>
        </tr>
    </tbody>
</table>

<table class="main">
    <thead>
    <tr>
        <th colspan="2">Last Work Position</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Company Name</td>
        <td><?= htmlentities($inputData['company']) ?></td>
    </tr>
    <tr>
        <td>From</td>
        <td><?= htmlentities($inputData['startWorkDate']) ?></td>
    </tr>
    <tr>
        <td>To</td>
        <td><?= htmlentities($inputData['endWorkDate']) ?></td>
    </tr>
    </tbody>
</table>

<table class="main">
    <thead>
    <tr>
        <th colspan="3">Computer Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Programming Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Skill Level</th>
                </tr>
                </thead>
                <tbody>
                <?php for($i = 0; $i < count($inputData['pr-lang']); $i++):?>
                    <tr>
                        <td><?= htmlentities($inputData['pr-lang'][$i]) ?></td>
                        <td><?= htmlentities($inputData['pr-skill'][$i])?></td>
                    </tr>
                <?php endfor; ?>
                </tbody>
            </table>
        </td>
    </tr>
    </tbody>
</table>

<table class="main">
    <thead>
    <tr>
        <th>Other Skills</th>
    </tr>
    </thead>
    <tbody>
    <tr>
        <td>Languages</td>
        <td>
            <table>
                <thead>
                <tr>
                    <th>Language</th>
                    <th>Comprehension</th>
                    <th>Reading</th>
                    <th>Writing</th>
                </tr>
                </thead>
                <tbody>
                <?php for($i = 0; $i < count($inputData['lang']); $i++):?>
                    <tr>
                        <td><?= htmlentities($inputData['lang'][$i]) ?></td>
                        <td><?= htmlentities($inputData['lang-comprehension'][$i])?></td>
                        <td><?= htmlentities($inputData['lang-reading'][$i])?></td>
                        <td><?= htmlentities($inputData['lang-writing'][$i])?></td>
                    </tr>
                <?php endfor; ?>
                </tbody>
            </table>
        </td>
    </tr>
    <tr>
        <td>Driver`s License</td>
        <td><?= htmlentities(implode(', ', $inputData['drvLicense']))?></td>
    </tr>
    </tbody>
</table>
<?php endif; ?>
