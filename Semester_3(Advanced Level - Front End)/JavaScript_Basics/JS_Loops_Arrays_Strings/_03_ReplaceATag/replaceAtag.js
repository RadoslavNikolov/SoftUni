function replaceATag (str) {
    str = str.replace('<a','[URL');
    var temps = str.match(/>(\w+)<\/a>/g).toString();
    var patt = temps.replace('>',']');
    patt = patt.replace('</a>','[/URL]');
    str = str.replace(temps,patt);
    console.log(str);

}
replaceATag('<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>');