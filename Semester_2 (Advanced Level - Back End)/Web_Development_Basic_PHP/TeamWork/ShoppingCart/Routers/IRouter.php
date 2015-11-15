<?php

namespace ShoppingCart\Routers;


interface IRouter {
    /**
     * @return string (Controller's name)
     */
    public function getControllerName();
    /**
     * @return string (Action's name)
     */
    public function getActionName();

    /**
     * @return array (Params)
     */
    public function getParams();

}