/**
 * Created by radko on 29.3.2015 г..
 */
function createParagraph(id,text) {
    var div = document.getElementById('wrapper');
    p = document.createElement('p');
    text = document.createTextNode(text);
    p.appendChild(text);

    if(div != null) {
            div.appendChild(p);
    } else {
        newDiv = document.createElement('div');
        newDiv.appendChild(p);
        newDiv.setAttribute('id','wrapper');
        document.body.appendChild(newDiv);
    }
}

createParagraph('wrapper', 'Some text');