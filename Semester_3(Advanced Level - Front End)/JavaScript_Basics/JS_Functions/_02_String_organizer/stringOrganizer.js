/**
 * Created by isrmn on 19.3.2015 г..
 */
function sortLetters(str,ascending) {
    var strArray = str.split('');
    strArray.sort(function(a,b){
        if(ascending) {
            return a.toLowerCase() > b.toLowerCase();
        } else {
            return a.toLowerCase() < b.toLowerCase();
        }

    });
    console.log(strArray.join(''));
}
sortLetters('HelloWorld', true);
sortLetters('HelloWorld', false);