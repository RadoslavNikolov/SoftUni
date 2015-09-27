<?php
/**
 * Created by PhpStorm.
 * User: toshiba
 * Date: 9/18/2015
 * Time: 8:37 AM
 */

namespace Data;


class Circle extends Shape{

    private $radius;

    function __construct($x, $y, $radius)
    {
        parent::__construct($x,$y);
        $this->setRadius($radius);
    }

    /**
     * @return mixed
     */
    public function getRadius()
    {
        return $this->radius;
    }

    /**
     * @param mixed $radius
     */
    public function setRadius($radius)
    {
        $this->radius = $radius;
    }

    function __toString()
    {
        return 'Circle(' . $this->getX() . ', ' . $this->getY() . ', ' .$this->getRadius()  . ')';
    }


    function CalcArea()
    {
        return $this->getRadius() * $this->getRadius() * M_PI;
    }
}