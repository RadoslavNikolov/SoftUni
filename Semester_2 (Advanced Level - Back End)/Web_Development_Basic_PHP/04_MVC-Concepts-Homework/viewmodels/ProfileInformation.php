<?php

namespace SoftUni\ViewModels;

class ProfileInformation
{
    public $error = false;
    public $success = false;

    /**
     * @var \Framework\ViewModels\User
     */
    private $user = null;

    public function setUser(\Framework\ViewModels\User $user){
        $this->user = $user;
    }

    /**
     * @return \Framework\ViewModels\User
     */
    public function getUser(){
        return $this->user;
    }
}