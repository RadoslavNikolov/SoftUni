<?php
namespace ShoppingCart\Controllers;


use ShoppingCart\Helpers\HelpFunctions;
use ShoppingCart\Helpers\Partials\PartialAside;
use ShoppingCart\Models\BindingModels\CategoryAddBindingModel;
use ShoppingCart\Models\BindingModels\CategoryBindingModel;
use ShoppingCart\Models\BindingModels\RegisterBindingModel;
use ShoppingCart\Models\Category;
use ShoppingCart\Repositories\CategoryRepository;
use ShoppingCart\Repositories\UserRepository;
use ShoppingCart\View;
use ShoppingCart\ViewModels\CategoriesViewModel;
use ShoppingCart\ViewModels\RegisterInformation;

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
            $this->redirect('users', 'login');
        }

        $categories = CategoryRepository::create()->getCategories();
        $viewModel = new CategoriesViewModel($categories);

        return new View($this->escapeAll($viewModel));
    }



    /**
     * @param \ShoppingCart\Models\BindingModels\CategoryBindingModel $model
     * @Route("categories/add/post")
     * @return View
     */
    public function post(CategoryBindingModel $model){
        $catName = $model->getCategoryname();
        $parentId = !intval($model->getParentid()) ? null : intval($model->getParentid());
        $catRepo = CategoryRepository::create();

        var_dump($catRepo->getCategoryByName($catName));
        if($catRepo->getCategoryByName($catName)){
            $this->redirect('categories', 'add', ["?error=Category name " . $catName . " already exist!"]);
        }

        $newCategory = new Category($catName,null, $parentId );
        if($newCategory->save()){
            PartialAside::clearAside();
            $this->updateCategoriesInJson();
        };

        $this->redirect('categories', 'add', ["?success=Category name " . $catName . " added!"]);
    }



    public function add(){
        if(!$this->isLogged()){
            header("Location: " . HelpFunctions::url() . "users/login");
            exit;
        }

        $categories = CategoryRepository::create()->getAllCategories();

        $categories = array_map(function($a){
            return array(
                'id' => $a['cat_id'],
                'name' => $a['cat_name']);
        }, $categories);

        $viewModel = new CategoriesViewModel($categories);

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
            $this->redirect('users', 'login');
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

            $this->redirect('categories', 'show');
        }

        $categories = CategoryRepository::create()->getAllCategories();

        $categories = array_map(function($a){
            return array(
                'id' => $a['cat_id'],
                'name' => $a['cat_name']);
        }, $categories);

        $viewModel = new CategoriesViewModel($categories);

        return new View($this->escapeAll($viewModel));
    }
}