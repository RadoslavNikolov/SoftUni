<h1>Buildings for <?= htmlspecialchars($data->getUser()->getUsername()); ?></h1>

<h3>
    Resources:
    <p>Gold: <?= $data->getUser()->getGold(); ?></p>
    <p>Food: <?= $data->getUser()->getFood(); ?></p>
</h3>

<table border="1">
    <tr>
        <td>Building name</td>
        <td>Level</td>
        <td>Gold</td>
        <td>Food</td>
    </tr>
    <?php foreach($data->getBuildings() as $building): ?>
    <tr>
        <td><?= htmlspecialchars($building['building_name']) ?></td>
        <td><?= $building['level_id'] ?></td>
        <td><?= $building['gold'] ?></td>
        <td><?= $building['food'] ?></td>
        <td><a href="buildings.php?id=<?= $building['building_id']; ?>");">Evolve</a></td>
    </tr>
    <?php endforeach; ?>
</table>
<div>
    <a href="profile.php">[Back to profile]</a>
</div>
