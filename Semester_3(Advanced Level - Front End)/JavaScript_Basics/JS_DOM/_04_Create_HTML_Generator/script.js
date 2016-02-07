/**
 * Created by radko on 29.3.2015 г..
 */
var createParagraph = function(id,text) {
    var div = document.getElementById(id);
    var p = document.createElement('p');
    var text = document.createTextNode(text);
    p.appendChild(text);

    if(div != null) {
        div.appendChild(p);
    } else {
        var newDiv = document.createElement('div');
        newDiv.appendChild(p);
        newDiv.setAttribute('id',id);
        document.body.appendChild(newDiv);
    }
}

var createDiv = function(id,addClass) {
    var div = document.getElementById(id);
    var newDiv= document.createElement('div');
    newDiv.setAttribute('class',addClass);

    if(div != null) {
        div.appendChild(newDiv);
    } else {
        var divID = document.createElement('div');
        divID.setAttribute('id',id);
        divID.appendChild(newDiv)
        document.body.appendChild(divID);
    }
}
var createLink = function(id,text,url) {
    var div = document.getElementById(id);
    var a = document.createElement('a');
    var text = document.createTextNode(text);
    a.appendChild(text);
    a.setAttribute('href',url)

    if(div != null) {
        div.appendChild(a);
    } else {
        var newDiv = document.createElement('div');
        newDiv.appendChild(a);
        newDiv.setAttribute('id',id);
        document.body.appendChild(newDiv);
    }
}

HTMLGen = { "createParagraph" : createParagraph,
    "createDiv" : createDiv,
    "createLink" : createLink}


HTMLGen.createParagraph('wrapper', 'Soft Uni');
HTMLGen.createDiv('wrapper', 'section');
HTMLGen.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');