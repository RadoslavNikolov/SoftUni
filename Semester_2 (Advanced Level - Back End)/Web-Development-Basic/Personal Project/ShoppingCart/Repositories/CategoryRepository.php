<?php
namespace ShoppingCart\Repositories;


use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;
use ShoppingCart\Helpers\Partials\PartialAside;
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

    public function getCategories($isActive = null, $isDeleted = null, $cat_id = null){

        $query = "
            SELECT root.cat_id AS CategoryID,
                  root.cat_name AS CategoryName,
                  root.parent_id as ParentID,
                  down1.cat_name as ParentName,
                  root.isActive as isActive,
                  root.isDeleted as isDeleted
            FROM categories as root
            LEFT OUTER
              JOIN categories as down1
                ON down1.cat_id = root.parent_id
              ORDER BY categoryID ASC";

        $params = [
        ];

        if(!is_null($cat_id)){
            $query .= "WHERE root.cat_id = ?";

            $params[] = $cat_id;
        }

        if(!is_null($isDeleted)){
            $query .= "WHERE root.isDeleted = ?";

            $params[] = $isDeleted;
        }

        if(!is_null($isActive)){
            $query .= "WHERE root.isActive = ?";

            $params[] = $isActive;
        }

        $result = $this->db->prepare($query);
        $result->execute([]);

//        var_dump($result->getError());

        return $result->fetchAll();
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
        WHERE root.isDeleted = FALSE AND root.isActive = TRUE AND root.parent_id is NULL
        ORDER BY root_name ASC , down1_name ASC , down2_name ASC, down3_name ASC";


        $result = $this->db->prepare($query);
        $result->execute([]);

        return $result->fetchAll();
    }



    public function getCategoryById($cat_id){
        $query = "
        SELECT cat.cat_id as cat_id,
              cat.cat_name as cat_name,
              cat.parent_id as parent_id,
              cat.isActive as isActive,
              cat.isDeleted as isDeleted
        FROM categories as cat
        WHERE cat.cat_id = ?";

        $params = [
            $cat_id
        ];

        $result = $this->db->prepare($query);
        $result->execute($params);

        if(!$result->rowCount() > 0) {
            throw new \Exception("Invalid user_id or user is not active");
        }

        $categoryRow = $result->fetch();

        return $this->getCategoryModel($categoryRow);
    }


    /**
     * @param $categoryRow
     * @return \ShoppingCart\Models\Category
     */
    public function getCategoryModel($categoryRow){
        $user = new Category(
            $categoryRow['cat_name'],
            $categoryRow['cat_id'],
            $categoryRow['parent_id'],
            $categoryRow['isActive'],
            $categoryRow['isDeleted']
        );

        return  $user;
    }

    public function getAllCategories($isActive = '1', $isDeleted = '0'){
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

//        var_dump($result->getError());

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
            $category->isActive(),
            $category->isDeleted()
        ];

        if ($category->getCatId()) {
            $query = "
              UPDATE categories SET
                cat_name = ?, parent_id = ?, isActive = ?, isDeleted = ?
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