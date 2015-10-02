<?php
/**
 * Created by PhpStorm.
 * User: isrmn
 * Date: 29.9.2015 �.
 * Time: 15:14 �.
 */

namespace ShoppingCart\Helpers;


class FormViewHelper
{
    private static $elementType;

    private static $name;
    private static $value;
    private static $content;
    private static $tag;
    private static $hasCloseTag = false;
    private static $attributes = [];
    private static $_instance = null;
    private static $hasFormTag = false;
    private static $hasNewLine = false;

    private static $elements;

    private function __construct () { }



    /**
     * @return \ShoppingCart\Helpers\FormViewHelper
     */
    public static function init()
    {
        if (self::$_instance === null) {
            self::$_instance = new self;
        }

        self::clearFields();
        self::$elements = null;

        return self::$_instance;
    }

    /**
     * @param mixed $name
     * @return $this
     *
     */
    public function setName($name)
    {
        self::$name = $name;
        return self::$_instance;
    }

    /**
     * @param mixed $value
     * @return $this
     */
    public function setValue($value)
    {
        self::$value = $value;
        return self::$_instance;
    }

    /**
     * @param mixed $value
     * @return $this
     */
    public function setContent($value)
    {
        self::$content = $value;
        return self::$_instance;
    }

    /**
     * @param $attribute
     * @return $this
     */
    public function setAttribute($attributeKey, $attributeValue)
    {
        self::$attributes[$attributeKey] = $attributeValue;
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function setNewLine(){
        self::$hasNewLine = true;
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function initForm(){
        self::$tag = 'form';
        self::$hasFormTag = true;
        self::$hasCloseTag = true;
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function initLabel(){
        self::$tag = 'label';
        self::$hasCloseTag = true;
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function initSubmit(){
        self::$tag = 'input';
        self::$elementType = 'submit';
        return self::$_instance;
    }

    /**
    * @return $this
    */
    public static function initTextBox(){
        self::$tag = 'input';
        self::$elementType = 'text';
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function initPasswordBox(){
        self::$tag = 'input';
        self::$elementType = 'password';
        return self::$_instance;
    }


    /**
     * @return $this
     */
    public static function initNumberBox(){
        self::$tag = 'input' ;
        self::$elementType = 'number';
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function initHiddenBox(){
        self::$tag = 'input';
        self::$elementType = 'hidden';
        return self::$_instance;
    }

    /**
     * @return $this
     */
    public static function create(){
       self::$elements .= '<' . self::$tag;

        if(self::$elementType){
            self::$elements .= ' type="' . self::$elementType . '"';
        }

        if(self::$name){
            self::$elements .= ' name="' . self::$name . '"';
        }

        if(self::$value){
            self::$elements .= ' value="' . self::$value . '"';
        }

        foreach(self::$attributes as $key => $value){
            self::$elements .= ' ' . $key . '="' . $value . '"';
        }

        if(self::$hasCloseTag == true){

            self::$elements .= '>' ;
        }else {
            self::$elements .= "/>";
        }

        if(self::$content){
            self::$elements .= self::$content;
        }

        if(self::$hasCloseTag = true && strtolower(self::$tag) != 'form'){
            self::$elements .= '</' . self::$tag . '>';
        }

        if(self::$hasNewLine){
            self::$elements .= '</br>';
        }
        self::clearFields();
        return self::$_instance;
    }

    private static function clearFields(){
        self::$name = null;
        self::$value = null;
        self::$attributes = [];
        self::$elementType = null;
        self::$content = null;
        self::$tag = null;
        self::$hasCloseTag = false;
        self::$hasNewLine = false;
    }

    public static function render(){
        if(self::$hasFormTag){
            self::$elements .= '</form>';
        }
        return self::$elements;
    }
}