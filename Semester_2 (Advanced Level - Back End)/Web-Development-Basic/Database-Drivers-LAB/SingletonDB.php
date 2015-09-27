<?php

//namespace DB;
 class SingletonDB
{
    static private $PDOInstance;
    private $_pdo;

    /**
     * sdb constructor.
     */
    private function __construct()
    {
        try {
            $this->_pdo = new PDO("mysql:host=localhost;dbname=translations", "root", "");
        } catch (PDOException $e){
            die("PDO CONNECTION ERROR: " . $e->getMessage() . "<br/>");
        }

        $this->_pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        $this->_pdo->exec("set names utf8");
    }

    public static function getInstance(){
        if (self::$PDOInstance === null)//don't check connection, check instance
        {
            self::$PDOInstance = new SingletonDB();
        }
        return self::$PDOInstance;
    }

     public function query($query, $tags = array()){
         $sth = $this->_pdo->prepare($query);
         $sth->execute($tags);

         return $sth;
     }

    //to TRULY ensure there is only 1 instance, you'll have to disable object cloning
    public function __clone()
    {
        return false;
    }
    public function __wakeup()
    {
        return false;
    }
}