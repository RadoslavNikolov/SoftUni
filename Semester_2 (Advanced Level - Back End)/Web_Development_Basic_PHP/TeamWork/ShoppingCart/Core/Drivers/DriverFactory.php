<?php
namespace ShoppingCart\Core\Drivers;

class DriverFactory {

    public static function create($driver, $user, $pass, $dbName, $host)
    {
        switch(strtolower($driver)){
            case 'mysql':
                return new MySQLDriver($user,$pass,$dbName,$host); break;
            default : break;
        }
    }
}