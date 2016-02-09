/**
 * Created by radko on 29.3.2015 г..
 */


function validateEmail () {
    var inputStr = document.getElementById("input-field").value;
    var isValid;
    var outputStr = inputStr.match(/([A-Za-z0-9\-_.]+)@([A-Za-z0-9\-_]+).([A-Za-z]{2,})/gi);
    if(outputStr != null) {
        outputStr = outputStr[0].toString();
        isValid = true;
    } else {
        isValid = false;
    }

    var outputElem = document.getElementById("output-field");
    if(isValid) {
        outputElem.value = outputStr;
        outputElem.style.backgroundColor = "green";
    } else {
        outputElem.value = inputStr;
        outputElem.style.backgroundColor = "red";
    }
}

