<?php
namespace ShoppingCart\Models;


use ShoppingCart\Repositories\CategoryRepository;

class Category {
    private $cat_id;
    private $cat_name;
    private $parent_id;
    private $isActive;
    private $isDeleted;

    function __construct($cat_name, $cat_id = null, $parent_id = null, $isActive = true, $isDeleted = false)
    {
        $this->setCatId($cat_id);
        $this->setCatName($cat_name);
        $this->setParentId($parent_id);
        $this->setIsActive($isActive);
        $this->setIsDeleted($isDeleted);
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
     * @return mixed
     */
    public function getIsActive()
    {
        return $this->isActive;
    }

    /**
     * @param mixed $isActive
     */
    public function setIsActive($isActive)
    {
        $this->isActive = $isActive;
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