<?php
namespace ShoppingCart\Models;

use ShoppingCart\Repositories\UserRepository;

class User
{
    private $user_id;
    private $username;
    private $email;
    private $password;
    private $cash;
    private $role_id;
    private $active;
    private $deleted;

    private $error = false;
    private $success = false;

    /**
     * @var Cart[];
     */
    private $carts = [];

    /**
     * User constructor.
     * @param $username
     * @param $email
     * @param $password
     * @param int $cash
     * @param bool|string $active
     * @param bool $deleted
     * @param $id
     * @param int $role_id
     */
    public function __construct($username, $email, $password, $cash, $active = true, $deleted = false, $id = null, $role_id = 1)
    {
        $this->setUsername($username);
        $this->setEmail($email);
        $this->setPassword($password);
        $this->setCash($cash);
        $this->setActive($active);
        $this->setDeleted($deleted);
        $this->setUserId($id);
        $this->setRoleId($role_id);
    }

    /**
     * @return mixed
     */
    public function getRoleId()
    {
        return $this->role_id;
    }

    /**
     * @param mixed $role_id
     */
    public function setRoleId($role_id)
    {
        $this->role_id = $role_id;
    }



    /**
     * @return boolean
     */
    public function isDeleted()
    {
        return $this->deleted;
    }



    /**
     * @param mixed $deleted
     */
    public function setDeleted($deleted)
    {
        $this->deleted = $deleted;
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
     * @return mixed
     */
    public function getCash()
    {
        return $this->cash;
    }

    /**
     * @param mixed $cash
     */
    public function setCash($cash)
    {
        if(!empty($cash)){
            $this->cash = $cash;
        } else {
            $this->cash = UserConfig::USERS_INITIAL_CASH;
        }
    }


    /**
     * @return mixed
     */
    public function getUsername()
    {
        return $this->username;
    }

    /**
     * @param mixed $username
     */
    public function setUsername($username)
    {
        $this->username = $username;
    }

    /**
     * @return mixed
     */
    public function getEmail()
    {
        return $this->email;
    }

    /**
     * @param mixed $email
     */
    public function setEmail($email)
    {
        $this->email = $email;
    }

    /**
     * @return mixed
     */
    public function getPassword()
    {
        return $this->password;
    }

    /**
     * @param mixed $password
     */
    public function setPassword($password)
    {
        if(substr( $password, 0, 7 ) === "$22$10$"){
            $this->password = $password;

        }else {
            $this->password = password_hash($password, PASSWORD_DEFAULT);
        }
    }

    /**
     * @return boolean
     */
    public function isActive()
    {
        return $this->active;
    }

    /**
     * @param mixed $active
     */
    public function setActive($active)
    {
        $this->active = $active;
    }

    /**
     * @return Cart[]
     */
    public function getCarts()
    {
        return $this->carts;
    }

    /**
     * @param Cart[] $carts
     */
    public function setCarts($carts)
    {
        $this->carts = $carts;
    }

    /**
     * @return boolean
     */
    public function isError()
    {
        return $this->error;
    }

    /**
     * @param boolean $error
     */
    public function setError($error)
    {
        $this->error = $error;
    }

    /**
     * @return boolean
     */
    public function isSuccess()
    {
        return $this->success;
    }

    /**
     * @param boolean $success
     */
    public function setSuccess($success)
    {
        $this->success = $success;
    }


    public function save()
    {
        return UserRepository::create()->save($this);
    }
}