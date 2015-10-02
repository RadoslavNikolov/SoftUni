<?php
namespace ShoppingCart\Repositories;


use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;
use ShoppingCart\Models\Role;

class RoleRepository {


    /**
     * @var \ShoppingCart\Core\Database
     */
    private $db;

    /**
     * @var RoleRepository
     */
    private static $inst = null;

    private function __construct($db)
    {
        $this->db = $db;
    }

    /**
     * @return RoleRepository
     */
    public static function create()
    {
        if (self::$inst == null)
        {
            self::$inst = new self(Database::getInstance(DatabaseConfig::DB_INSTANCE));
        }

        return self::$inst;
    }


    public function save(Role $role)
    {
        $query = "
            INSERT INTO roles (role_name, isDeleted)
            VALUES (?, ?)
        ";
        $params = [
            $role->getRoleName(),
            $role->isDeleted()
        ];

        if ($role->getRoleId()) {
            $query = "
              UPDATE roles SET
                role_name = ?, isDeleted = ?
              WHERE user_id = ?";

            $params[] = $role->getRoleId();
        }

        $result = $this->db->prepare($query);
        $result->execute($params);

        if($result->rowCount() > 0 ){
            return true;
        }

        throw new \Exception("Cannot register role");
    }

}