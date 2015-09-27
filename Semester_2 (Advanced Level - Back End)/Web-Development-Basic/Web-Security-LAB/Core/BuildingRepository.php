<?php
namespace Core;


class BuildingRepository {
    /**
     * @var Database
     */
    private $db;

    /**
     * @var User
     */
    private $user = null;

    public function __construct(Database $db, User $user)
    {
        $this->db = $db;
        $this->user = $user;
    }

    /**
     * @return User
     */
    public function getUser()
    {
        return $this->user;
    }



    public function getBuildings(){
        $result = $this->db->prepare("
           SELECT
                l.building_id,
                b.building_name,
                ub.level_id,
                l.gold,
                l.food
            FROM
              user_buildings AS ub
            INNER JOIN buildings AS b
              ON b.id = ub.building_id
              INNER JOIN buildingsLevels as l
            ON ub.building_id = l.building_id
            WHERE ub.level_id + 1 = l.level
            AND ub.user_id = ?
        ");

        $result->execute([$_SESSION['id']]);

//        var_dump($result->getError());
        return $result->fetchAll();
    }

    public function evolve($buildingId){
        $result = $this->db->prepare("
            SELECT
                l.level,
                l.gold,
                l.food
            FROM
              user_buildings AS ub
            JOIN buildingsLevels as l
            ON l.building_id = ub.building_id
            AND ub.level_id + 1 = l.level
            WHERE ub.building_id = ?
        ");

        $result->execute([$buildingId]);

//        var_dump($result->getError());

        $building = $result->fetch();

        if(!$result->rowCount() > 0){
            throw new \Exception("Max building level reached");
        }

        if($building['food'] > $this->user->getFood() || $building['gold'] > $this->user->getGold()){
            throw new \Exception("Insufficient resources");
        }

        $resourceUpdate = $this->db->prepare("
            UPDATE user_buildings
            SET level_id = ?
            WHERE user_id = ? AND building_id = ?
        ");

        $resourceUpdate->execute([
            $building['level'],
            $this->user->getId(),
            $buildingId
        ]);

//        var_dump($result->getError());

        if($resourceUpdate->rowCount() > 0){
            $userUpdate = $this->db->prepare("
                UPDATE users
                SET gold = ?, food = ?
                WHERE id = ?
             ");

            $userUpdate->execute([
                $this->user->getGold() - $building['gold'],
                $this->user->getFood() - $building['food'],
                $this->user->getId()
            ]);

//            var_dump($result->getError());

            if(!$userUpdate->rowCount() > 0){
                throw new \Exception("Insufficient resources");
            }

            return true;
        }
    }
}