<?php
namespace ShoppingCart\Models;


use ShoppingCart\Repositories\CategoryRepository;

class Role {
    private $role_id;
    private $role_name;
    private $deleted;

    function __construct($role_name, $role_id = null, $deleted = false)
    {
        $this->setRoleId($role_id);
        $this->setRoleName($role_name);
        $this->setDeleted($deleted);
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


    public function save()
    {
        return CategoryRepository::create()->save($this);
    }

}