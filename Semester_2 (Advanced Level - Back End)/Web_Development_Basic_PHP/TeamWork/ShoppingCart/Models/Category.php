<?php
namespace ShoppingCart\Models;


use ShoppingCart\Repositories\CategoryRepository;

class Category {
    private $cat_id;
    private $cat_name;
    private $parent_id;
    private $active;
    private $deleted;

    function __construct($cat_name, $cat_id = null, $parent_id = null, $active = true, $deleted = false)
    {
        $this->setCatName($cat_name);
        $this->setCatId($cat_id);
        $this->setParentId($parent_id);
        $this->setActive($active);
        $this->setDeleted($deleted);
    }


    /**
     * @return mixed
     */
    public function getCatId()
    {
        return $this->cat_id;
    }

    /**
     * @param mixed $cat_id
     */
    public function setCatId($cat_id)
    {
        $this->cat_id = $cat_id;
    }

    /**
     * @return mixed
     */
    public function getCatName()
    {
        return $this->cat_name;
    }

    /**
     * @param mixed $cat_name
     */
    public function setCatName($cat_name)
    {
        $this->cat_name = $cat_name;
    }

    /**
     * @return mixed
     */
    public function getParentId()
    {
        return $this->parent_id;
    }

    /**
     * @param mixed $parent_id
     */
    public function setParentId($parent_id)
    {
        $this->parent_id = $parent_id;
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