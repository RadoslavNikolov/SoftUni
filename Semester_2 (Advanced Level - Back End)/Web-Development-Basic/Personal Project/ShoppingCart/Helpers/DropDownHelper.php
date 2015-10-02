<?php

namespace ShoppingCart\Helpers;


class DropDownHelper {
    private $attributes = [];
    private $options = '';

    public static function create(){
        return new self();
    }

    public function addAttribute($attributeName, $attributeValue){
        $this->attributes[$attributeName] = $attributeValue;
        return $this;
    }

    public function setDefaultOption($valueContent){
        $this->options = "\t<option value\"\">$valueContent</option>\n" . $this->options;
        return $this;
    }

    public function setContent($content, $valueKey = 'id', $valueContent = 'value', $keySelected = null, $valueSelected = null){

        foreach($content as $model){
            $this->options .= "\t<option";
            if($keySelected && $valueSelected){
                if($model[$keySelected] == $valueSelected){
                    $this->options = " selected";
                }
            }
            $this->options .= "value={$model[$valueKey]}>" . $model[$valueContent] . "</option>\n";
        }

        return $this;
    }

    public function render(){
        $output = "<select";
        foreach($this->attributes as $key => $value){
            $output .= " " . $key . "=" . '"' . $value . '"';
        }
        $output .= ">\n";
        $output .= $this->options;
        $output .= "</select>";

        return $output;
    }
}