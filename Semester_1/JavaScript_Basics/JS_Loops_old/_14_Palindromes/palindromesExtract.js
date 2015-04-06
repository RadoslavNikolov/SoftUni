/**
 * Created by isrmn on 16.3.2015 г..
 */
function findPalindromes(input) {
    var inputAsArr = input.toLowerCase().split(/\W+/).filter(function(v) {
        return v !== '';
    });
    //console.log(inputAsArr);
    var palindromes = [];
    for (var i = 0; i < inputAsArr.length; i++) {
        //split word to make it array. The array can be reversed using reverse()
        var reversed = inputAsArr[i].split('').reverse().join('');
        if(inputAsArr[i] === reversed){
            palindromes.push(reversed);
        }
    }
    console.log(palindromes.join(', '));

}
findPalindromes('There is a man, his name was Bob.');