/**
* Created by toshiba on 5.4.2015 г..
*/
function solve(input) {
    var directions = input[0].trim().split(/\s*,\s*/g);
    //console.log(directions);
    var row = 0;
    var col= 0;
    var results = {
        '&': 0,
        '*': 0,
        '#': 0,
        '!': 0,
        'wall hits': 0
    };
    var output = [];
    var outputStr = [];
    for (var i = 1; i < input.length; i++) {
        output.push(input[i].split(/\s*,\s*/g));
    }
    //console.log(output);
    directions.forEach(function(direction){
        switch (direction.toLowerCase()) {
            case 'right' : if(col+1 < output[row].length) {
                col+=1;
                eat();
            } else {
                results['wall hits'] += 1;
            }
                break;
            case 'left' : if( col-1 >= 0) {
                col-=1;
                eat();
            } else {
                results['wall hits'] += 1;
            }
                break;
            case 'up' : if( row-1 >= 0) {
                row-=1;
                eat();
            } else {
                results['wall hits'] += 1;
            }
                break;
            case 'down' : if( row+1 < output.length) {
                row+=1;
                eat();
            } else {
                results['wall hits'] += 1;
            }
                break;
            default : break;
        }
    });

    function eat() {
        var str = output[row][col];
        //console.log(str);
        var pattern = /({[!*&#]})/g;
        while(match = pattern.exec(str)) {
            //console.log(match[0]);
            switch (match[0]) {
                case '{&}':
                    results['&'] += 1;
                    break;
                case '{*}':
                    results['*'] += 1;
                    break;
                case '{#}':
                    results['#'] += 1;
                    break;
                case '{!}':
                    results['!'] += 1;
                    break;
                default :break;
            }
        }
        var eatedStr = str.replace(/({[!*&#]})/g,'@');
        if(eatedStr !== '') {
            outputStr.push(eatedStr);
        }
    }
    var tempStr = '';
    console.log('{"&":' + results['&'] + ',"*":' + results['*'] + ',"#":' + results['#'] + ',"!":' + results['!'] + ',"wall hits":' + results['wall hits'] + '}');
    if(results['wall hits'] === directions.length) {
        console.log('no');
    } else {
        console.log(outputStr.join('|'));
    }
}


//var input = [ 'right, right, down, left, left',
//    'qwekjs, asda, mxz',
//    'qwekjs, asda, xnca',
//    'qwekjs, asda, xnca',
//    'qwekjs, asda, xnca'];

//var input = ['right, up, up, down','asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj','tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip','poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne'];

//var input = ['up, right, left, down','as{!}xnk'];
//solve(input);