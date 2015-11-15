<?php
namespace SoftUni\Models;

use SoftUni\Config\DatabaseConfig;
use SoftUni\Core\Database;
use SoftUni\ViewModels\ProfileInformation;

class User
{
//    private $id;
//    private $username;
//    private $pass;
//    private $gold;
//    private $food;

    /**
     * @var \SoftUni\Core\Database
     */
    private $db = null;


    const GOLD_DEFAULT = 1500;
    const FOOD_DEFAULT = 1500;

    function __construct()
//        $username, $pass, $id = null, $gold = null, $food = null
    {
//        $this->setId($id);
//        $this->setUsername($username);
//        $this->setPass($pass);
//        $this->setGold($gold);
//        $this->setFood($food);

        $this->setInstance();
    }

    private function setInstance(){
        if ($this->db === null)//don't check connection, check instance
        {
            $this->db = Database::getInstance(DatabaseConfig::DB_INSTANCE);
        }
    }


    public function userExists($username){
        $result = $this->db->prepare("SELECT id FROM users WHERE username = ?");
        $result->execute([$username]);

        return $result->rowCount() > 0;
    }

    public function register($username, $password){
//        echo 'register user';
        if($this->userExists($username)){
            throw new \Exception("User already registered");
        }

        $result  = $this->db->prepare("
            INSERT INTO users (username, password, gold, food)
            VALUES (?, ?, ?, ?);
        ");

        $result->execute([
            $username,
            password_hash($password, PASSWORD_DEFAULT),
            self::GOLD_DEFAULT,
            self::FOOD_DEFAULT
        ]);

//        var_dump($result->getError());

        if($result->rowCount() > 0){
            $userId = $this->db->lastInsertId();

            $this->db->query("
            INSERT INTO user_buildings (user_id, building_id, level_id)
            SELECT $userId, id, 0 FROM buildings
            ");

//            var_dump($result->getError());

            return true;
        }

        throw new \Exception("Cannot register user");
    }

    public function login($username, $password){
        $result = $this->db->prepare("SELECT id, username, password, gold, food FROM users WHERE username = ?");
        $result->execute([$username]);

        if(!$result->rowCount() > 0) {
            throw new \Exception("Invalid username");
        }

        $userRow = $result->fetch();

        if(password_verify($password, $userRow['password'])){
            return $userRow['id'];
        }

        throw new \Exception("Invalid password");
    }

    public function getUserModel($userRow){
        $user = new User(
            $userRow['username'],
            $userRow['password'],
            $userRow['id'],
            $userRow['gold'],
            $userRow['food']
        );
        return $user;
    }

    public function getUserInfo($id){
        $result = $this->db->prepare("
            SELECT
                id, username, password, gold, food
            FROM
              users
            WHERE id = ?
        ");

        $result->execute([$id]);

        return $result->fetch();
    }

    public function editUser($id, $username, $password){
        $result = $this->db->prepare("
            UPDATE users
            SET password = ?, username = ?
            WHERE id = ?
        ");


        $result->execute([
            password_hash($password, PASSWORD_DEFAULT),
            $username,
            $id
        ]);


        return $result->rowCount() > 0;
    }

    public function createBuildings(){
        if($this->buildingRepository == null){
            $this->buildingRepository = new BuildingRepository($this->db, $this->getUser());
        }

        return $this->buildingRepository;
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

    public function evolve($buildingId, ProfileInformation $viewModel){
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

        if($building['food'] > $viewModel->food || $building['gold'] > $viewModel->gold){
            throw new \Exception("Insufficient resources");
        }

        $resourceUpdate = $this->db->prepare("
            UPDATE user_buildings
            SET level_id = ?
            WHERE user_id = ? AND building_id = ?
        ");

        $resourceUpdate->execute([
            $building['level'],
            $viewModel->userId,
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
                $viewModel->gold - $building['gold'],
                $viewModel->food - $building['food'],
                $viewModel->userId
            ]);

//            var_dump($result->getError());

            if(!$userUpdate->rowCount() > 0){
                throw new \Exception("Insufficient resources");
            }

            return true;
        }
    }

}