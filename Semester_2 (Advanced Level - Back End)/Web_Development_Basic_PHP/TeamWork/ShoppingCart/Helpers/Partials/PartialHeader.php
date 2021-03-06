<?php
namespace ShoppingCart\Helpers\Partials;

use ShoppingCart\Helpers\HelpFunctions;

class PartialHeader {

    private static $header = null;

    public static function create()
    {
        if (self::$header == null)
        {
            self::createHeader();
        }

        return self::$header;
    }


    private static function createHeader(){

        if(empty($_SESSION)){
            $code = '<nav id="ddmenu">
                    <ul>
                        <li><span class="message">Hello visitor! Please login.</span></li>';
            $code = $code . '<li class="no-sub">' . HelpFunctions::anchor('users', 'login', [], 'Login') . '</li>';
            $code = $code . '</ul></nav>';

            self::$header = $code;
            return;
        }

        $username = htmlspecialchars($_SESSION['username']);
        $role = htmlspecialchars($_SESSION['user_role']);

        $code = '<nav id="ddmenu">
                    <ul>
                        <li>
                            <span class="message">Hello, ';
        $code = $code . ucfirst($username);
        $code = $code  . '</span></li>';
        $code = $code . ' <li><span class="message">User role: ' . $_SESSION['user_role'] . '</span></li>';

        //Start drop down menu "Products"
        $code = $code . '   <li>
                                <span class="top-heading">Products</span>
                                <i class="caret"></i>
                                <div class="dropdown">
                                    <div class="dd-inner">
                                        <div class="column">
                                            <h3>Products Menu</h3>';

        $code = $code . HelpFunctions::anchor('products', 'all', [], 'List All Products');

        if($role == 'customer' || $role == 'editor'){
            $code = $code . HelpFunctions::anchor('products', 'my', [], 'List My products');
        }

        if($role != 'customer'){
            $code = $code . HelpFunctions::anchor('products', 'add', [], 'Add products');
            $code = $code . HelpFunctions::anchor('products', 'delete', [], 'Delete products');
        }

        $code = $code . "</div>
                </div>
            </div>
        </li>";
        //End drop down menu "Products"

        if($role != 'customer'){

            //Start drop down menu "Categories"
            $code = $code . '   <li>
                                <span class="top-heading">' . HelpFunctions::anchor('categories', 'show', [], 'Categories');
            $code = $code . '</span>
                                <i class="caret"></i>
                                <div class="dropdown">
                                    <div class="dd-inner">
                                        <div class="column">
                                            <h3>Categories Menu</h3>';

            $code = $code . HelpFunctions::anchor('categories', 'add', [], 'Add Category');
            $code = $code . HelpFunctions::anchor('categories', 'edit', [], 'Edit Category');
            $code = $code . HelpFunctions::anchor('categories', 'show', [], 'Delete Category');
            $code = $code . "</div>
                </div>
            </div>
        </li>";
            //End drop down menu "Products"
        }

        //Start drop down menu "Profile"
        $code = $code  . '<li>
                            <span class="top-heading">' . HelpFunctions::anchor('users', 'show', [], 'Profile');
        $code = $code . '</span>
                            <i class="caret"></i>
                            <div class="dropdown">
                                <div class="dd-inner">
                                    <div class="column">
                                        <h3>Profile Menu</h3>';

        $code = $code . HelpFunctions::anchor('users', 'edit', [], 'Edit Profile');

        if($role == 'customer' || $role == 'editor'){
            $code = $code . HelpFunctions::anchor('users', 'delete', [], 'Delete Profile');
        }

        $code = $code . "</div>
                </div>
            </div>
        </li>";
        //End drop down menu "Profile"

        //Start drop down menu "Cart"
        if($role == 'customer'){
            $code = $code  . '<li>
                            <span class="top-heading">Cart</span>
                            <i class="caret"></i>
                            <div class="dropdown">
                                <div class="dd-inner">
                                    <div class="column">
                                        <h3>Cart Menu</h3>';
            $code = $code . HelpFunctions::anchor('users', 'cart', [], 'Get Cart');
            $code = $code . HelpFunctions::anchor('users', 'cart', ['all'], 'Get All My Carts');
        }


        $code = $code . "</div>
                </div>
            </div>
        </li>";
        //End drop down menu "Cart"

        $code = $code . '<li class="no-sub">' . HelpFunctions::anchor('users', 'logout', [], 'Logout') . '</li>';
        $code = $code . '</ul></nav>';

        self::$header = $code;
    }


    public static function clearHeader(){
        self::$header = null;
    }

}