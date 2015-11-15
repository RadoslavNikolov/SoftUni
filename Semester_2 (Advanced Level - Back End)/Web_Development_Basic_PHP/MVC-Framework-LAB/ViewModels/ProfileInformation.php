<?php
/**
 * Created by PhpStorm.
 * User: toshiba
 * Date: 9/25/2015
 * Time: 2:53 PM
 */

namespace SoftUni\ViewModels;


class ProfileInformation {
    public $error = false;
    public $success = false;


    public $userId = null;
    public $username = null;
    public $gold = null;
    public $food = null;

    public $buildings = [];

}