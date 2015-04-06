/**
 * Created by radko on 31.3.2015 г..
 */

function solve(input) {
    var regex = /[^?&=]+=[^?&=]+/g;
    input.forEach(function(strLine){
        var output = {};
        var outputStr = '';
        while(match = regex.exec(strLine)) {
            //console.log(match);
            var row = match[0].split('=');
            var fieldName = row[0].replace(/(%20|[+])+/g,' ').trim();
            var fieldValue = row[1].replace(/(%20|[+])+/g,' ').trim();
            if(output.hasOwnProperty(fieldName)) {
                output[fieldName].push(fieldValue);
            } else {
                output[fieldName] = [fieldValue];
            }
        }
        //console.log(output);
        for(var name in output) {
            outputStr += (name + '=[' + output[name].join(', ') + ']');
        }
        console.log(outputStr);
    });

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
//    solve(input[arr])
//}