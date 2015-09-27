<?php
namespace Data;

use Data\iMovable;
use Data\iAreaCalculable;
use Traits\JsonXmlTrait;

abstract class Shape implements iMovable, iAreaCalculable{
    protected $x;
    protected $y;

    function __construct($x, $y)
    {
        $this->setX($x);
        $this->setY($y);
    }

    /**
     * @return mixed
     */
    public function getX()
    {
        return $this->x;
    }

    /**
     * @param mixed $x
     */
    public function setX($x)
    {
        $this->x = $x;
    }

    /**
     * @return mixed
     */
    public function getY()
    {
        return $this->y;
    }

    /**
     * @param mixed $y
     */
    public function setY($y)
    {
        $this->y = $y;
    }

    function move($deltax, $deltaY){
        $this->setX($this->getX() + $deltax);
        $this->setY($this->getY() + $deltaY);
    }

    use JsonXmlTrait;
}