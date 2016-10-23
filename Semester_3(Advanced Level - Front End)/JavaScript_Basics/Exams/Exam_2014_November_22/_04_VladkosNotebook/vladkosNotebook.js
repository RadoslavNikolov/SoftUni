/**
 * Created by isrmn on 2.4.2015 г..
 */
function solve(input) {
    var output = {};
    var sortedOutput = {};

    input.forEach(function(inputLine){
        var row = inputLine.split('|');
        //console.log(row[1]);
        var sheetColor = row[0];
        if(!output[sheetColor]) {
            output[sheetColor] = {};
            output[sheetColor]['win'] = 0;
            output[sheetColor]['loss'] = 0;
            output[sheetColor]['opponents'] = [];
            output[sheetColor]['rank'] = 0;
        }
        switch(row[1]){
            case 'age':
                if(!output[sheetColor].hasOwnProperty('age')) {
                    output[sheetColor]['age'] = row[2];
                }
                break;
            case 'name':
                if(!output[sheetColor].hasOwnProperty('name')) {
                    output[sheetColor]['name'] = row[2];
                }
                break;

            case 'win':
                if(output[sheetColor].hasOwnProperty('win')) {
                    output[sheetColor]['win'] += 1;
                }
                output[sheetColor]['opponents'].push(row[2]);
                break;
            case 'loss':
                if(output[sheetColor].hasOwnProperty('loss')) {
                    output[sheetColor]['loss'] += 1;
                }
                output[sheetColor]['opponents'].push(row[2]);
                break;
            default: break;
        }
    });

    var sheets = Object.keys(output);
    sheets.sort();
    //console.log(sheets);

    for(var index in sheets) {
        var sheet = sheets[index];
        //console.log(sheet);
        output[sheet]['opponents'].sort();
        //output[sheet]['opponents'].sort(function(a,b){
        //    return a.toLowerCase().localeCompare(b.toLowerCase());
        //});
        output[sheet]['rank'] = ((parseFloat(output[sheet]['win']) + 1)/(parseFloat(output[sheet]['loss']) + 1)).toFixed(2);
        delete output[sheet]['win'];
        delete output[sheet]['loss'];
        if(output[sheet].hasOwnProperty('age') && output[sheet].hasOwnProperty('name')){
            sortedOutput[sheet] = {
                'age': output[sheet]['age'],
                'name': output[sheet]['name'],
                'opponents': output[sheet]['opponents'],
                'rank': output[sheet]['rank']
            }
        }
    }
    console.log(JSON.stringify(sortedOutput));
}


//var input = [
//    ['red|name|kiko',
//    'red|win|Vladko',
//    'blue|age|12',
//    'green|age|13',
//    'green|win|gosho',
//    'red|age|12',
//    'green|name|Pesho',
//    'green|win|ico',
//    'green|win|Gosho',
//    'green|win|Gosho',
//    'green|win|stamat',
//    'green|win|petko',
//    'green|win|mariya']];
//
//for (var arr in input) {
//    sumNumbers(input[arr]);
//}