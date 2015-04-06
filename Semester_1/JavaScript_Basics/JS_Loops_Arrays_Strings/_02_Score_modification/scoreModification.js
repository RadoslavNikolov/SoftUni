/**
 * Created by isrmn on 17.3.2015 г..
 */
function modificateScore(input) {
    var resultArr = input.filter(function(num){
        if(num > 0 && num < 400){
            return num;
        }
    });
    resultArr = resultArr.map(function(num){
        return parseFloat((num *= 0.8).toFixed(1));
    });
    resultArr.sort(function(a,b){
        return a > b;
    });
    console.log(resultArr);
}

modificateScore([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);