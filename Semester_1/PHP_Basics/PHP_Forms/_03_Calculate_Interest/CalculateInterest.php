<?php
    if(isset($_GET['amount'], $_GET['interest'], $_GET['currency'], $_GET['period'])) {
        if(isset($_GET['capitalization-period'])){
            $inputValues = [
                'capitalization-period' => $_GET['capitalization-period']
            ];
        } else {
            $inputValues = [
                'capitalization-period' => 1
            ];
        }
        $inputValues['amount'] = $_GET['amount'];
        $inputValues['interest'] = $_GET['interest'] / 12;
        $inputValues['period'] = $_GET['period'];
        $sum = $inputValues['amount'];
        for ($i = 0; $i < $inputValues['period']; $i += $inputValues['capitalization-period']) {
          $sum *= (1+($inputValues['interest'] * $inputValues['capitalization-period']) / 100);
        }
    }
?>

<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Calculate Interest</title>
</head>
<body>
<div id="wrapper">
    <form action="" method="get">
        <div>
            <label for="amount">Enter Amount:</label>
            <input type="text" id="amount" name="amount" required />
        </div>
        <div>
            <input type="radio" name="currency" id="USD" value="$" required />
            <label for="USD">USD</label>
            <input type="radio" name="currency" id="EUR" value="€" />
            <label for="EUR">EUR</label>
            <input type="radio" name="currency" id="BGN" value="lv" />
            <label for="BGN">BGN</label>
        </div>
        <div>
            <label for="interest">Compound Interest Amount</label>
            <input type="text" name="interest" id="interest" required />
        </div>
        <div>
            <select name="period" required>
                <option selected value="" disabled>Period</option>
                <option value="6">6 Months</option>
                <option value="12">1 Year</option>
                <option value="24">2 Years</option>
                <option value="60">5 Years</option>
                <input type="submit" value="Calculate">
            </select>
        </div>
        <input type="checkbox" id="invoice-checkbox" onchange="togglecheckbox(this)"/>
        <label for="invoice-checkbox">Change capitalization period</label>
        <div id="capitalization-change">
            <select name="capitalization-period">
                <option selected value="" disabled>Capit.Period</option>
                <option value="6">Every 6 Month</option>
                <option value="12">Every Year</option>
                <option value="<?= $inputValues['period'] ?>">No capitalization</option>
            </select>
        </div>
    </form>
    <?php if (isset($sum)): ?>
        <p>The interest capitalizes every <?= htmlentities($inputValues['capitalization-period'])?>  month<?= $inputValues['capitalization-period'] != 1 ? 's' : ''?></p>
        <p><?= htmlentities($_GET['currency']) . ' ' . htmlentities(round($sum, 2)) ?></p>
    <?php endif ?>
</div>

<script type="text/javascript">
    var cb = document.getElementById("capitalization-change");
    togglecheckbox(cb)

    function togglecheckbox(cb){
        if(cb.checked) {
            document.getElementById("capitalization-change").hidden = false;
        } else {
            document.getElementById("capitalization-change").hidden = true;
        }
    }

</script>
</body>
</html>