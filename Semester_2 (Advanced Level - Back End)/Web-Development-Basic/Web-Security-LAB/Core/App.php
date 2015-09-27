<?php
namespace Core;

use Core\Database;

class App {
    /**
     * @var Database
     */
    private $db;

    /**
     * @var User
     */
    private $user = null;

    private $buildingRepository = null;

    public function __construct(Database $db)
    {
        $this->db = $db;
    }

    public function isLogged() {
        return isset($_SESSION['id']);
    }

    public function isFormSecured($formToken){
        if ($formToken != $_SESSION['formToken']) {
            throw new \Exception('Invalid request');
        }

        return true;
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
            User::GOLD_DEFAULT,
            User::FOOD_DEFAULT
        ]);

        var_dump($result->getError());

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
            $_SESSION['id'] = $userRow['id'];
            $_SESSION['formToken'] = uniqid(mt_rand(), true);

            $user = $this->getUserModel($userRow);
            return $user;
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

    public function getUser(){
        if($this->user != null){
            return $this->user;
        }

        if($this->isLogged()){
            $userRow = $this->getUserInfo($_SESSION['id']);
            $this->user = $this->getUserModel($userRow);

            return $this->user;
        }

        return null;
    }

    public function editUser(User $user){
        $result = $this->db->prepare("
            UPDATE users
            SET password = ?, username = ?
            WHERE id = ?
        ");


        $result->execute([
            password_hash($user->getPass(), PASSWORD_DEFAULT),
            $user->getUsername(),
            $user->getId()
        ]);

        return $result->rowCount() > 0;
    }

    public function createBuildings(){
        if($this->buildingRepository == null){
            $this->buildingRepository = new BuildingRepository($this->db, $this->getUser());
        }

        return $this->buildingRepository;
    }
}