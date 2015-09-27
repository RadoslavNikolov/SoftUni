<?php
namespace ShoppingCart\Controllers;


use ShoppingCart\Repositories\CategoryRepository;

class CategoryController extends Controller{

    public function getCategories(){
        $getCategories = CategoryRepository::create()->getNestedCategories();

        return $getCategories;
    }
}