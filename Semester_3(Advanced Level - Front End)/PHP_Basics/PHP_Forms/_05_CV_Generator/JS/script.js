/**
 * Created by isrmn on 18.4.2015 г..
 */

var variables = {prLang: 0, lang: 0};

function addProgLanguage() {
    variables.prLang++;

    var inputDiv = document.getElementById('pr-lang-hidden').cloneNode(true);
    inputDiv.id = 'pr-lang' + variables.prLang;
    inputDiv.className = 'show';

    var progLang = inputDiv.getElementsByTagName('input')[0];
    progLang.value = '';
    progLang.name = 'pr-lang[]';
    progLang.required = 'required';

    var skills = inputDiv.getElementsByTagName('select')[0];
    skills.name = 'pr-skill[]';
    skills.required = 'required';

    var removeBtn = inputDiv.getElementsByTagName('input')[1];
    removeBtn.setAttribute("onclick","removeProgLanguage(" + ('\'pr-lang' + variables.prLang + '\')') );

    document.getElementById('prog-lang').appendChild(inputDiv);
}

function addLanguage() {
    variables.lang++;

    var inputDiv = document.getElementById('lang-hidden').cloneNode(true);
    inputDiv.id = 'lang' + variables.lang;
    inputDiv.className = 'show';

    var lang = inputDiv.getElementsByTagName('input')[0];
    lang.value = '';
    lang.name = 'lang[]';
    lang.required = 'required';

    var langSkills = inputDiv.getElementsByTagName('select');
    langSkills[0].name = 'lang-comprehension[]';
    langSkills[0].required = 'required';
    langSkills[1].name = 'lang-reading[]';
    langSkills[1].required = 'required';
    langSkills[2].name = 'lang-writing[]';
    langSkills[2].required = 'required';

    var removeBtn = inputDiv.getElementsByTagName('input')[1];
    removeBtn.setAttribute("onclick","removeLanguage(" + ('\'lang' + variables.lang + '\')') );

    document.getElementById('lang').appendChild(inputDiv);
}


function removeProgLanguage(id) {
    var inputDiv = document.getElementById(id);
    document.getElementById('prog-lang').removeChild(inputDiv);
}

function removeLanguage(id) {
    var inputDiv = document.getElementById(id);
    document.getElementById('lang').removeChild(inputDiv);
}