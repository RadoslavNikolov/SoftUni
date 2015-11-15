<?php
namespace ShoppingCart\Core;

use ShoppingCart\Core\Drivers\DriverFactory;

class Database {
    private static $inst = [];
    private $db = null;

    private function __construct(\PDO $db)
    {
        $this->db = $db;

    }


    public static function setInstance(
        $instanceName,
        $driver,
        $user,
        $pass,
        $dbName,
        $host = null
    )
    {
        $driver = DriverFactory::create($driver, $user, $pass, $dbName, $host);

        $pdo = new \PDO($driver->getDsn(), $user, $pass);

        self::$inst[$instanceName] = new self($pdo);
    }



    public static function getInstance($instanceName = 'default')
    {
        if(!isset(self::$inst[$instanceName])){
            throw new \Exception('Instance with that name was not set');

        }

        return self::$inst[$instanceName];
    }

    public function prepare($statement, array $driverOptions = []){
        $statement = $this->db->prepare($statement,$driverOptions);

//        var_dump($statement);

        return new Statement($statement);
    }

    public function query($query){
        $this->db->query($query);
    }

    public function lastInsertId($name = null){
        return $this->db->lastInsertId($name);
    }
}

class Statement {
    private $stmt;

    public function __construct(\PDOStatement $stmt)
    {
        $this->stmt = $stmt;
    }

    public function fetch($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetch($fetchStyle);
    }

    public function fetchAll($fetchStyle = \PDO::FETCH_ASSOC){
        return $this->stmt->fetchAll($fetchStyle);
    }

    public function bindParam($parameter, $variable, $dataType = \PDO::PARAM_STR, $length = null, $driver_options = null){
        return $this->stmt->bindParam($parameter, $variable, $dataType, $length, $driver_options);
    }

    public function execute($params = []){
        return $this->stmt->execute($params);
    }

    public function getError(){
        return $this->stmt->errorInfo();
    }

    public function rowCount()
    {
        return $this->stmt->rowCount();
    }


}