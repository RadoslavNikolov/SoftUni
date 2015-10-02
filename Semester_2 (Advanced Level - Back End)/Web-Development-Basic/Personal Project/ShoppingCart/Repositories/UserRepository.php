<?php

namespace ShoppingCart\Repositories;

use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;
//use ShoppingCart\Models\Cart;
use ShoppingCart\Models\Role;
use ShoppingCart\Models\User;
//use ShoppingCart\Models\Product;


class UserRepository
{
    /**
     * @var \ShoppingCart\Core\Database
     */
    private $db;

    /**
     * @var UserRepository
     */
    private static $inst = null;

    private function __construct($db)
    {
        $this->db = $db;
    }

    /**
     * @return UserRepository
     */
    public static function create()
    {
        if (self::$inst == null)
        {
            self::$inst = new self(Database::getInstance(DatabaseConfig::DB_INSTANCE));
        }

        return self::$inst;
    }


    /**
     * @param $username
     * @return bool
     */
    public function userExists($username){
        $result = $this->db->prepare("
            SELECT user_id FROM users WHERE username = ? AND isDeleted = FALSE");
        $result->execute([$username]);

        return $result->rowCount() > 0;
    }


    /**
     * @param $email
     * @return bool
     */
    public function emailExists($email){
        $result = $this->db->prepare("
            SELECT user_id FROM users WHERE email = ? isDeleted = FALSE");
        $result->execute([$email]);

        return $result->rowCount() > 0;
    }


    /**
     * @param $username
     * @param $password
     * @return \ShoppingCart\Models\User
     * @throws \Exception
     */
    public function login($username, $password){
        $result = $this->db->prepare("
            SELECT
                user_id, username, email, password, cash, role_id, isActive, isDeleted
            FROM
                users
            WHERE
              username = ? AND isActive = TRUE AND isDeleted = FALSE ");
        $result->execute([$username]);

        if(!$result->rowCount() > 0) {
            throw new \Exception("Invalid username or user is not active");
        }

        $userRow = $result->fetch();

        if(password_verify($password, $userRow['password'])){
            return $this->getUserModel($userRow);
        }

        throw new \Exception("Invalid password");
    }


    /**
     * @param $userRow
     * @return \ShoppingCart\Models\User
     */
    public function getUserModel($userRow){
        $user = new User(
            $userRow['username'],
            $userRow['email'],
            $userRow['password'],
            $userRow['cash'],
            $userRow['isActive'],
            $userRow['isDeleted'],
            $userRow['user_id'],
            $userRow['role_id']
        );

        return  $user;
    }

    /**
     * @param $role_id
     * @return Role
     * @throws \Exception
     */
    public function getUserRole($role_id){
        $result = $this->db->prepare("
            SELECT
                role_id, role_name, isDeleted
            FROM
                roles
            WHERE
              role_id = ? AND isDeleted = FALSE ");

        $result->execute([$role_id]);

        if(!$result->rowCount() > 0) {
            throw new \Exception("Invalid role_id");
        }

        $userRow = $result->fetch();
        $role = new Role($userRow['role_name'], $userRow['role_id'], $userRow['isDeleted']);

        return $role;
    }



//    /**
//     * @param $user
//     * @param $password
//     * @return bool|User
//     */
//    public function getOneByDetails($user, $password)
//    {
//        $query = "SELECT user_id, username, email, password, cash, isActive
//        FROM users WHERE username = ? AND isActive = 1 ";
//
////        echo "getoneByDetail";
//
//        $this->db->query($query,
//            [
//                $user
//            ]
//        );
//
//        $result = $this->db->row();
//        if (empty($result)) return false;
//
//        if (password_verify($password, $result['password'])) {
//            return $this->getOne($result['user_id']);
//        }else{
//            echo "not valid";
//        }
//
//        return false;
//    }
//
    public function getUserById($userId)
    {
        $result = $this->db->prepare("
            SELECT
                user_id, username, email, password, cash, role_id, isActive, isDeleted
            FROM
                users
            WHERE
              user_id = ? AND isActive = TRUE AND isDeleted = FALSE ");
        $result->execute([$userId]);

        if(!$result->rowCount() > 0) {
            throw new \Exception("Invalid user_id or user is not active");
        }

        $userRow = $result->fetch();

        return $this->getUserModel($userRow);
    }



    /**
     * @return User[]
     */
    public function getAll()
    {
        $query = "SELECT user_id, username, email, password, cash, role_id, isActive, isDeleted
        FROM users";

        $result = $this->db->prepare($query);
        $result->execute([]);
        $resultCollection = $result->fetchAll();
        $collection = [];

        foreach ($resultCollection as $row)
        {
            $collection[] = new User(
                $row['username'],
                $row['email'],
                $row['password'],
                $row['cash'],
                $row['isActive'],
                $row['isDeleted'],
                $row['user_id']
            );
        }

        return $collection;
    }


    public function deleteUser($user_id){
        $query = "
            UPDATE users SET isDeleted = TRUE
            WHERE user_id = ?
        ";

        $result = $this->db->prepare($query);
        $result->execute([$user_id]);

        if($result->rowCount() > 0 ){
            return true;
        }

        throw new \Exception("Cannot delete user");
    }

    public function save(User $user)
    {
        $query = "
            INSERT INTO users (username, email, password, cash, role_id, isActive, isDeleted)
            VALUES (?, ?, ?, ?, ?, ? , ?)
        ";
        $params = [
            $user->getUsername(),
            $user->getEmail(),
            $user->getPassword(),
            $user->getCash(),
            $user->getRoleId(),
            $user->isActive(),
            $user->isDeleted()
        ];

        if ($user->getUserId()) {
            $query = "
              UPDATE users SET
                username = ?, email = ?, cash = ?, role_id = ?, isActive = ?, isDeleted = ?
              WHERE user_id = ?";

            $params =  [
                $user->getUsername(),
                $user->getEmail(),
                $user->getCash(),
                $user->getRoleId(),
                $user->isActive(),
                $user->isDeleted(),
                $user->getUserId()
            ];

        }

        $result = $this->db->prepare($query);
        $result->execute($params);

        if($result->rowCount() > 0 ){
            if ($user->getUserId()) {
                $_SESSION['username'] = $user->getUsername();
            }
            return true;
        }

        throw new \Exception("Cannot register user");
    }
}