<?php
namespace Traits;

trait JsonXmlTrait{
    public function toJSON(){
        $arr = (array)$this;
        return json_encode($arr);
    }
}