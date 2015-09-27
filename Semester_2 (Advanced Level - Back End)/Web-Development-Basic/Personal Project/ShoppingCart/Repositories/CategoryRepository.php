<?php
namespace ShoppingCart\Repositories;


use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;
use ShoppingCart\Models\Category;

class CategoryRepository{

    /**
     * @var \ShoppingCart\Core\Database
     */
    private $db;

    /**
     * @var CategoryRepository
     */
    private static $inst = null;

    private function __construct($db)
    {
        $this->db = $db;
    }

    /**
     * @return CategoryRepository
     */
    public static function create()
    {
        if (self::$inst == null)
        {
            self::$inst = new self(Database::getInstance(DatabaseConfig::DB_INSTANCE));
        }

        return self::$inst;
    }


    public function getNestedCategories(){
        $query = "
        SELECT root.cat_name as root_name,
              down1.cat_name as down1_name,
              down2.cat_name as down2_name,
              down3.cat_name as down3_name
        FROM categories as root
        LEFT OUTER
          JOIN categories as down1
            ON down1.parent_id = root.cat_id
        LEFT OUTER
          JOIN categories as down2
            ON down2.parent_id = down1.cat_id
        LEFT OUTER
          JOIN categories as down3
            ON down3.parent_id = down2.cat_id
        WHERE root.parent_id is NULL
        ORDER BY root_name ASC , down1_name ASC , down2_name ASC, down3_name ASC";


        $result = $this->db->prepare($query);
        $result->execute([]);

        var_dump($result->getError());

        return $result->fetchAll();
    }

    public function getAllCategories($isActive = true, $isDeleted = false){
        $query = "
        SELECT cat.cat_id as cat_id,
              cat.cat_name as cat_name,
              cat.parent_id as parent_id,
              cat.isActive as isActive,
              cat.isDeleted as isDeleted
        FROM categories as cat
        WHERE cat.isActive = ? AND cat.isDeleted = ?
        ORDER BY cat_name ASC";

        $params = [
            $isActive,
            $isDeleted
        ];

        $result = $this->db->prepare($query);
        $result->execute($params);

        var_dump($result->getError());

        return $result->fetchAll();
    }


    public function save(Category $category)
    {
        $query = "
            INSERT INTO categories (cat_name, parent_id, isActive, isDeleted)
            VALUES (?, ?, ?, ?)
        ";
        $params = [
            $category->getCatName(),
            $category->getParentId(),
            $category->getIsActive(),
            $category->getIsDeleted()
        ];

        if ($category->getCatId()) {
            $query = "
              UPDATE categories SET
                cat_name = ?, parend_id = ?, isActive = ?, isDeleted = ?
              WHERE cat_id = ?";

            $params[] = $category->getCatId();
        }

        $result = $this->db->prepare($query);
        $result->execute($params);

        if($result->rowCount() > 0 ){
            return true;
        }

        throw new \Exception("Cannot register category");
    }



}