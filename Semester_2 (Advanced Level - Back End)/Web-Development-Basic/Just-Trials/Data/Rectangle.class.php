<?php
/**
 * Created by PhpStorm.
 * User: toshiba
 * Date: 9/18/2015
 * Time: 8:42 AM
 */

namespace Data;


class Rectangle extends Shape{
    private $width;
    private $height;

    function __construct($x, $y, $width, $height)
    {
        parent::__construct($x,$y);
        $this->setWidth($width);
        $this->setHeight($height);
    }

    /**
     * @return mixed
     */
    public function getWidth()
    {
        return $this->width;
    }

    /**
     * @param mixed $width
     */
    public function setWidth($width)
    {
        $this->width = $width;
    }

    /**
     * @return mixed
     */
    public function getHeight()
    {
        return $this->height;
    }

    /**
     * @param mixed $height
     */
    public function setHeight($height)
    {
        $this->height = $height;
    }

    function __toString()
    {
        return 'Rect(' . $this->getX() . ', ' . $this->getY()
            . ', size: ' . $this->getWidth() . ' x ' . $this->getHeight()
            . ')';
    }


    function CalcArea()
    {
        return $this->getHeight() * $this->getWidth();
    }

    final function example(){
        echo 'I ma not virtual';
    }
}