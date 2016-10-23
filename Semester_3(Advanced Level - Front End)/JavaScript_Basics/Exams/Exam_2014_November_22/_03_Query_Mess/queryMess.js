/**
 * Created by toshiba on 4.4.2015 г..
 */
/**
 * Created by isrmn on 2.4.2015 г..
 */
function solve(input) {
    //console.log(input);

    var pattern = /[^?&=]+=[^?&=]+/g;
    for(var index in input){
        var output = {};
        var outputStr = '';
        while(match = pattern.exec(input[index])) {
            var line = match[0].replace().split('=');
            var filed = line[0].replace(/(%20|[+])+/g,' ').trim();
            var value = line[1].replace(/(%20|[+])+/g,' ').trim();
            if(!output[filed]) {
                output[filed] = [];
            }
            output[filed].push(value);
        }
        for(var index in output) {
            //console.log(output[index]);
            outputStr += (index + '=[' + output[index].join(', ') + ']');
        }
        console.log(outputStr);
    }


}

//var input = [
//    ['login=student&password=student'],
//    ['field=value1&field=value2&field=value3', 'http://example.com/over/there?name=ferret'],
//    ['foo=%20foo&value=+val&foo+=5+%20+203',
//     'foo=poo%20&value=valley&dog=wow+',
//     'url=https://softuni.bg/trainings/coursesinstances/details/1070',
//     'https://softuni.bg/trainings.asp?trainer=nakov&course=oop&course=php']
//];
//
//for (var arr in input) {
//    sumNumbers(input[arr])
//}