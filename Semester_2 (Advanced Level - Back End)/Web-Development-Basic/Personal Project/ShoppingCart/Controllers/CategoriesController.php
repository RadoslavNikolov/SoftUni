<?php
namespace ShoppingCart\Controllers;


use ShoppingCart\Helpers\HelpFunctions;
use ShoppingCart\Helpers\Partials\PartialAside;
use ShoppingCart\Repositories\CategoryRepository;
use ShoppingCart\Repositories\UserRepository;
use ShoppingCart\View;
use ShoppingCart\ViewModels\CategoriesViewModel;

class CategoriesController extends Controller{


    /**
     * @return array
     * @Authorize
     */
    public function getCategories(){
        $getCategories = CategoryRepository::create()->getNestedCategories();

        return $getCategories;
    }


    /**
     * @return View
     * @Authorize
     */
    public function show(){
        if(!$this->isLogged()){
            header("Location: " . HelpFunctions::url() . "users/login");
            exit;
        }

        $categories = CategoryRepository::create()->getCategories();
        $viewModel = new CategoriesViewModel($categories);

//        $this->render($this->escapeAll($user));
        return new View($this->escapeAll($viewModel));
    }


    /**
     * @param null $cat_id
     * @param null $condition
     * @return View
     * @throws \Exception
     * @Authorize
     */
    public function edit($cat_id = null, $condition = null){
        if(!$this->isLogged()){
            header("Location: " . HelpFunctions::url() . "users/login");
            exit;
        }

        if(!empty($condition) && !empty($cat_id)){
            $category = CategoryRepository::create()->getCategoryById($cat_id);

            if(strtolower($condition) === 'changeactive'){
                if($category->isActive() == false){
                    $category->setActive(true);
                }else {
                    $category->setActive(false);
                }
                if($category->save()){
                    PartialAside::clearAside();
                    $this->updateCategoriesInJson();
                }
            }

            if(strtolower($condition) === 'changedelete'){
                if($category->isDeleted() == false){
                    $category->setDeleted(true);
                }else {
                    $category->setDeleted(false);
                }

                if($category->save()){
                    PartialAside::clearAside();
                    $this->updateCategoriesInJson();
                }
            }

            header("Location: " . HelpFunctions::url() . "categories/show");
            exit;
        }

        $categories = CategoryRepository::create()->getAllCategories();
        $categories = array_map(function($v){
            return $v['cat_name'];
        }, $categories);

        $viewModel = new CategoriesViewModel($categories);

//        $this->render($this->escapeAll($user));
        return new View($this->escapeAll($viewModel));
    }
}