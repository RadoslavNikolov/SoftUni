<?php

namespace Framework\Controllers;

use Framework\Config\AppConfig;
use Framework\Helpers\Helpers;
use Framework\View;

abstract class BaseController
{
    public function render($model, $layout = AppConfig::DEFAULT_LAYOUT, $view = null) {
        View::initView($model, $layout, $view);
    }

    public function isLoggedIn(){
        return isset($_SESSION['userId']);
    }

    public function authorize($redirectionPath, $authorizeLogged = true) {

        if (!$this->isLoggedIn() && $authorizeLogged === true) {
            $this->redirect($redirectionPath);
        }

        if ($this->isLoggedIn() && $authorizeLogged === false) {
            $this->redirect($redirectionPath);
        }
    }

    public function redirect($path = AppConfig::DEFAULT_REDIRECTION) {
        header("Location: " . Helpers::url() . $path);
        exit;
    }
}