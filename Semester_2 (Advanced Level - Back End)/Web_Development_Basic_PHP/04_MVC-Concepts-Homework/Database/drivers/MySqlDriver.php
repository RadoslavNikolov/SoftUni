<?php

namespace Framework\Database\Drivers;

class MySqlDriver extends DriverAbstract
{
    public function getDsn()
    {
        $dsn = 'mysql:host=' . $this->host . ';dbname=' . $this->dbName;

        return $dsn;
    }
}