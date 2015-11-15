<?php

namespace Framework\ViewModels;

class User
{
    private $id;
    private $username;
    private $pass;

    /**
     * User constructor.
     * @param $id
     * @param $username
     * @param $pass
     */
    public function __construct($username, $pass, $id = null)
    {
        $this->setId($id)
            ->setUsername($username)
            ->setPass($pass);
    }

    /**
     * @return mixed
     */
    public function getId() {
        return $this->id;
    }

    /**
     * @param mixed $id
     * @return User
     */
    public function setId($id) {
        $this->id = $id;
        return $this;
    }

    /**
     * @return mixed
     */
    public function getUsername() {
        return $this->username;
    }

    /**
     * @param mixed $username
     * @return User
     */
    public function setUsername($username) {
        $this->username = $username;
        return $this;
    }

    /**
     * @return mixed
     */
    public function getPass() {
        return $this->pass;
    }

    /**
     * @param mixed $pass
     * @return User
     */
    public function setPass($pass) {
        $this->pass = $pass;
        return $this;
    }
}