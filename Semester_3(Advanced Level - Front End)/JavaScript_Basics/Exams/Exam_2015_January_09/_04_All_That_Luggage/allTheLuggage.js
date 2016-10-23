/**
 * Created by toshiba on 1.4.2015 г..
 */
function solve(input) {
    var luggage = {};
    var luggageSorted = {};
    var sortBy = input[input.length - 1];

    for(var i=0; i < input.length - 1; i++){
        var row = input[i].split(/\.*\*\.*/g);
        var name = row[0];
        var type = 'other';

        if(row[2] === 'true') {
            type = 'food';
        }
        if(row[3] === 'true') {
            type = 'drink';
        }
        if(!luggage.hasOwnProperty(name)) {
            luggage[name] = [];
        }
        luggage[name].push({
            'luggageName' : row[1],
            'kg' : Number(row[5]),
            'fragile' : row[4] === 'true' ? true : false,
            'type' : type,
            'transferredWith' : row[6]
        });
    }
    //console.log(luggage);
    var names = Object.keys(luggage);

    for (var i = 0; i < names.length; i++) {
        var name = names[i];
        sortLuggage(name);
        luggageSorted[name]  =  {};

        for (var j = 0; j < luggage[name].length; j++) {
            var luggageName = luggage[name][j].luggageName;
            luggageSorted[name][luggageName] = luggage[name][j];
            delete  luggageSorted[name][luggageName].luggageName;
        }
    }
    console.log(JSON.stringify(luggageSorted));

    function sortLuggage(name) {
        luggage[name].sort(function (a, b) {
            if (sortBy === 'luggage name') {
                return a.luggageName.localeCompare(b.luggageName);
            } else if (sortBy === 'weight') {
                return a.kg - b.kg;
            }
        });
    }


}



//var input = [
//    ['Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
//     'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
//     'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
//     'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
//     'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
//     'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
//     'strict']
//];
//
//for (var str in input) {
//    sumNumbers(input[str]);
//}