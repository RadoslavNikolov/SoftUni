<?php
namespace Todo;

use Todo\Configs;
require_once"Configs/DbConfig.php";

class Db
{
    /**
     * @var \PDO
     */
    private $conn;

    /**
     * @var \PDOStatement
     */
    private $stmt;

    /**
     * @var Db
     */
    private static $inst = null;

    private function __construct()
    {
        $user = Configs\DbConfig::USER;
        $pass = Configs\DbConfig::PASS;
        $dbName = Configs\DbConfig::DBNAME;
        $host = Configs\DbConfig::HOST;

        $dsn = 'mysql:dbname='.$dbName .';host='. $host;
        $this->conn = new \PDO($dsn, $user, $pass);

        $this->conn->setAttribute(\PDO::ATTR_ERRMODE, \PDO::ERRMODE_EXCEPTION);
        $this->conn->exec("set names utf8");
    }

//    public static function setInstance()
//    {
//        echo "setinstance";
//        if (self::$inst == null)
//        {
//            self::$inst = new self;
//        }
//    }

    /**
     * @return Db
     */
    public static function getInstance()
    {
        if (self::$inst === null)//don't check connection, check instance
        {
            self::$inst = new self;
        }

        return self::$inst;
    }

    /**
     * @param $query
     * @param array $params
     */
    public function query($query, array $params = [])
    {
        $this->stmt = $this->conn->prepare($query);
        $this->stmt->execute($params);
    }

    /**
     * @return array
     */
    public function fetchAll()
    {
        return $this->stmt->fetchAll();
    }

    /**
     * @return mixed
     */
    public function row()
    {
//        var_dump($this->stmt->fetch());
        return $this->stmt->fetch();
    }

    /**
     * @return int
     */
    public function rows()
    {
        return $this->stmt->rowCount();
    }

    public function createUser($username, $password){

        $passwordHash = password_hash($password, PASSWORD_BCRYPT);

        if(!$this->containsUser($username)) {
            $query = "
            INSERT INTO users (username, passwordHash)
            VALUES (?, ?)
        ";
            $params = [
                $username,
                $passwordHash
            ];
            $this->query($query, $params);

            return true;
        }

        return false;
    }

    public function containsUser($username){
        $query = "SELECT id FROM users WHERE username = ?";
        $params = [
            $username,
        ];
        $this->query($query, $params);

        return $this->rows() > 0;
    }

    public function getUser($username, $password){

        if($this->isUserValid($username, $password)){
            $query = "SELECT id, username FROM users WHERE username = ?";
            $params = [
                $username,
            ];
            $this->query($query, $params);
        }
        return $this->row();
    }

    public function isUserValid($username, $password){

        $query = "SELECT id, username, passwordHash FROM users WHERE username = ?";
        $params = [
            $username,
        ];

        $this->query($query, $params);
        $passwordHash = $this->row()['passwordHash'];

        return password_verify($password, $passwordHash);
    }

    public function getTodoItems($user_id){
        $query = "SELECT id, todo_item FROM todos WHERE user_id = ?";
        $params = [
            $user_id,
        ];
        $this->query($query, $params);

        return $this->fetchAll();
    }

    public function getTodo($todo_id){
        $query = "SELECT id, todo_item FROM todos WHERE id = ?";
        $params = [
            $todo_id,
        ];
        $this->query($query, $params);

        return $this->row();
    }

    public function addTodoItem($user_id, $todo_text){
        $query = "INSERT INTO todos (user_id, todo_item) VALUES (?, ?)";
        $params = [
            $user_id,
            $todo_text
        ];
        $this->query($query, $params);

        return $this->rows() > 0;

    }

    public function containsTodo($user_id, $todo_text){
        $query = "SELECT id FROM todos WHERE user_id = ? AND todo_item = ?";
        $params = [
            $user_id,
            $todo_text
        ];
        $this->query($query, $params);

        return $this->rows() > 0;

    }

    public function deleteTodoItem($todo_id){
        $query = "DELETE FROM todos WHERE id = ?";
        $params = [
            $todo_id
        ];
        $this->query($query, $params);

        return $this->rows() > 0;
    }
}