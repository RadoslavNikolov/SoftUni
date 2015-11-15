<?php
namespace ShoppingCart\Models\BindingModels;

class RegisterBindingModel {
    /**
     * @Require
     */
    private $username;

    /**
     * @Require
     */
    private $email;

    /**
     * @Require
     */
    private $password;

    /**
     * @Require
     */
    private $confPassword;


    private $cash = null;
    private $error = false;
    private $success = false;

    /**
     * @return mixed
     */
    public function getConfPassword()
    {
        return $this->confPassword;
    }

    /**
     * @param mixed $confPassword
     */
    public function setConfPassword($confPassword)
    {
        $this->confPassword = $confPassword;
    }




    /**
     * @return null
     */
    public function getCash()
    {
        return $this->cash;
    }

    /**
     * @param null $cash
     */
    public function setCash($cash)
    {
        $this->cash = $cash;
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
        $this->password = $password;
    }



}