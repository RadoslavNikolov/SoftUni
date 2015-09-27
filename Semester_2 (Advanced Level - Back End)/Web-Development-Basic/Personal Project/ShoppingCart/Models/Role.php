<?php
namespace ShoppingCart\Models;


use ShoppingCart\Repositories\CategoryRepository;

class Role {
    private $role_id;
    private $role_name;
    private $isDeleted;

    function __construct($role_name, $role_id = null, $isDeleted = false)
    {
        $this->setRoleId($role_id);
        $this->setRoleName($role_name);
        $this->setIsDeleted($isDeleted);
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
     * @return mixed
     */
    public function getRoleName()
    {
        return $this->role_name;
    }

    /**
     * @param mixed $role_name
     */
    public function setRoleName($role_name)
    {
        $this->role_name = $role_name;
    }

    /**
     * @return mixed
     */
    public function getIsDeleted()
    {
        return $this->isDeleted;
    }

    /**
     * @param mixed $isDeleted
     */
    public function setIsDeleted($isDeleted)
    {
        $this->isDeleted = $isDeleted;
    }


    public function save()
    {
        return CategoryRepository::create()->save($this);
    }

}