<?php
namespace ShoppingCart\Models\BindingModels;


class CategoryBindingModel {
    /**
     * @Require
     */
    private $categoryname;

    /**
     * @Require
     */
    private $parentid;

    private $error = false;
    private $success = false;

    /**
     * @return mixed
     */
    public function getCategoryname()
    {
        return $this->categoryname;
    }

    /**
     * @param mixed $categoryname
     */
    public function setCategoryname($categoryname)
    {
        $this->categoryname = $categoryname;
    }

    /**
     * @return mixed
     */
    public function getParentid()
    {
        return $this->parentid;
    }

    /**
     * @param mixed $parentid
     */
    public function setParentid($parentid)
    {
        $this->parentid = $parentid;
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


}