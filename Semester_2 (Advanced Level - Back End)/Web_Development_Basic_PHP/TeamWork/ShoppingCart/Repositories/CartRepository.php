<?php
namespace ShoppingCart\Repositories;


use ShoppingCart\Config\DatabaseConfig;
use ShoppingCart\Core\Database;
use ShoppingCart\Models\Cart;

class CartRepository{

    /**
     * @var \ShoppingCart\Core\Database
     */
    private $db;

    /**
     * @var CartRepository
     */
    private static $inst = null;

    private function __construct($db)
    {
        $this->db = $db;
    }

    /**
     * @return CartRepository
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
     * @param null $isCheckout
     * @param null $isDeleted
     * @param null $user_id
     * @param null $cart_id
     * @return array
     */
    public function getCarts($isCheckout = null, $isDeleted = null, $user_id = null, $cart_id = null){
        $query = "
            SELECT carts.cart_id,
                  carts.user_id,
                  users.username,
                  carts.isCheckout,
                  carts.isDeleted,
                  carts.checkout_date,
                  carts.total
            FROM carts
            JOIN users
                ON carts.user_id = users.user_id
            WHERE 1";

        $params = [
        ];

//        var_dump($isCheckout);
//        var_dump($isDeleted);
//        var_dump($user_id);
//        var_dump($cart_id);
//        die;

        if(!empty($cart_id)){
            $query .= " AND carts.cart_id = ? ";
            $params[] = $cart_id;

        }

        if(!is_null($user_id)){
            $query .= " AND carts.user_id = ? ";

            $params[] = $user_id;
        }

        if(!is_null($isDeleted)){
            $query .= " AND carts.isDeleted = ? ";

            $params[] = $isDeleted;
        }

        if(!is_null($isCheckout)){
            $query .= " AND carts.isCheckout = ? ";

            $params[] = $isCheckout;
        }

        $query .= " ORDER BY carts.cart_id ASC";

        $result = $this->db->prepare($query);
        $result->execute($params);
        $resultCollection = $result->fetchAll();
        $collection = [];

//        var_dump($result->getError());
//
//        var_dump($result);
//        var_dump($params);
//        var_dump($resultCollection);
//        die;

        foreach ($resultCollection as $row)
        {
            $collection[] = $this->getCartModel($row);
        }

        return $collection;
    }


    /**
     * @param $cartRow
     * @return \ShoppingCart\Models\Cart
     */
    public function getCartModel($cartRow){
        $cart = new Cart(
            $cartRow['user_id'],
            $cartRow['cart_id'],
            $cartRow['isCheckout'],
            $cartRow['isDeleted'],
            $cartRow['checkout_date'],
            $cartRow['total']
        );

        return  $cart;
    }


    public function save(Cart $cart)
    {
        $query = "
            INSERT INTO carts (cart_id, user_id, isCheckout, isDeleted, checkout_date, total)
            VALUES (?, ?, ?, ?, ?, ?)
        ";
        $params = [
            $cart->getCartId(),
            $cart->getUserId(),
            $cart->isCheckout(),
            $cart->isDeleted(),
            $cart->getCheckoutDate(),
            $cart->getTotal()
        ];


        if ($cart->getCartId()) {
            $query = "
              UPDATE carts SET
                user_id = ?, isCheckout = ?, isDeleted = ?
              WHERE cart_id = ?";

            $params[] = $cart->getCartId();
        }

        $result = $this->db->prepare($query);
        $result->execute($params);

        if($result->rowCount() > 0 ){
            return true;
        }

        throw new \Exception("Cannot register cart");
    }
}