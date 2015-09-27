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

        //Start drop down menu "Products"
        $code = $code  . '</span></li>
                            <li>
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

        //Start drop down menu "Profile"
        $code = $code  . '<li>
                            <span class="top-heading">Profile</span>
                            <i class="caret"></i>
                            <div class="dropdown">
                                <div class="dd-inner">
                                    <div class="column">
                                        <h3>Profile Menu</h3>';

        $code = $code . HelpFunctions::anchor('users', 'edit', [], 'Edit Profile');
        $code = $code . HelpFunctions::anchor('users', 'delete', [], 'Delete Profile');
        $code = $code . "</div>
                </div>
            </div>
        </li>";
        //End drop down menu "Profile"

        //Start drop down menu "Cart"
        $code = $code  . '<li>
                            <span class="top-heading">Cart</span>
                            <i class="caret"></i>
                            <div class="dropdown">
                                <div class="dd-inner">
                                    <div class="column">
                                        <h3>Cart Menu</h3>';
        if($role == 'customer' || $role == 'editor'){
            $code = $code . HelpFunctions::anchor('users', 'cart', [], 'Get Cart');
            $code = $code . HelpFunctions::anchor('users', 'cart', ['all'], 'Get All Ny Carts');
        } else {
            $code = $code . HelpFunctions::anchor('admin', 'carts', [], 'Get users carts');
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