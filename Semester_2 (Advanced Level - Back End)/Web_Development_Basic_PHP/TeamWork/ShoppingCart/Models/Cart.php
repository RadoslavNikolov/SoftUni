<?php
namespace ShoppingCart\Models;


use DateTime;
use ShoppingCart\Repositories\CartRepository;

class Cart {
    private $cart_id;
    private $user_id;
    private $checkout;
    private $deleted;

    /**
     * @var Datetime
     */
    private $checkoutDate;

    private $total;


    function __construct($user_id, $cart_id= null, $checkout = false, $deleted = false, $date = null, $total = null)
    {
        $this->setCartId($cart_id);
        $this->setUserId($user_id);
        $this->setCheckout($checkout);
        $this->setDeleted($deleted);
        $this->setCheckoutDate($date);
        $this->setTotal($total);
    }

    /**
     * @return DateTime
     */
    public function getCheckoutDate()
    {
        return $this->checkoutDate;
    }

    /**
     * @param DateTime $checkoutDate
     */
    public function setCheckoutDate($checkoutDate)
    {
        $this->checkoutDate = $checkoutDate;
    }

    /**
     * @return mixed
     */
    public function getTotal()
    {
        return $this->total;
    }

    /**
     * @param mixed $total
     */
    public function setTotal($total)
    {
        $this->total = $total;
    }


    /**
     * @return mixed
     */
    public function getCartId()
    {
        return $this->cart_id;
    }

    /**
     * @param mixed $cart_id
     */
    public function setCartId($cart_id)
    {
        $this->cart_id = $cart_id;
    }

    /**
     * @return mixed
     */
    public function getUserId()
    {
        return $this->user_id;
    }

    /**
     * @param mixed $user_id
     */
    public function setUserId($user_id)
    {
        $this->user_id = $user_id;
    }

    /**
     * @return boolean
     */
    public function isCheckout()
    {
        return $this->checkout;
    }

    /**
     * @param boolean $checkout
     */
    public function setCheckout($checkout)
    {
        $this->checkout = $checkout;
    }

    /**
     * @return boolean
     */
    public function isDeleted()
    {
        return $this->deleted;
    }

    /**
     * @param boolean $deleted
     */
    public function setDeleted($deleted)
    {
        $this->deleted = $deleted;
    }


    public function save()
    {
        return CartRepository::create()->save($this);
    }

}