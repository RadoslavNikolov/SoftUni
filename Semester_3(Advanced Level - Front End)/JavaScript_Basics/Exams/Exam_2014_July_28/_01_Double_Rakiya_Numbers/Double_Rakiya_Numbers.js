/**
 * Created by isrmn on 16.3.2015 г..
 */
function solve(input) {
    console.log('<ul>');
    var start = parseInt(input[0]);
    var end = parseInt(input[1]);
    for (var i = start; i <= end; i++) {
        if(i.toString().length >= 4) {
            if(isRakiya(i.toString())) {
                var outputStr = '<li><span class=\'rakiya\'>' + i + '</span><a href="view.php?id=' + i + '>View</a></li>';
                console.log(outputStr);
            } else {
                var outputStr = '<li><span class=\'num\'>' + i + '</span></li>';
                console.log(outputStr);
            }
        } else {
            var outputStr = '<li><span class=\'num\'>' + i + '</span></li>';
            console.log(outputStr);
        }
    }
    console.log('</ul>');
    
    function isRakiya(numAsStr) {
        var isRakiyaFlag = false;
        for (var i = 0; i < numAsStr.length-3; i++) {
            for (var j = i+2; j < numAsStr.length-1; j++) {
                var num1 = parseInt(numAsStr.substring(i,i+2));
                var num2 = parseInt(numAsStr.substring(j,j+2));
                if(num1 === num2) {
                    isRakiyaFlag = true;
                    break;
                }
            }
            if(isRakiyaFlag === true) {
                break;
            }
        }
        return isRakiyaFlag;
    }
}

//var input = [
//    [1211,1213]
//];
//for(var str in input) {
//    sumNumbers(input[str]);
//}