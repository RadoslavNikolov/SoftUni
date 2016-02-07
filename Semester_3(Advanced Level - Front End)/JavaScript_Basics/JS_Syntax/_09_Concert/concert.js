/**
 * Created by isrmn on 12.3.2015 г..
 */
function solve(input) {
    //console.log(input);
    var concert = {};
    var output = {};

    for (var i = 0; i < input.length; i++) {
        var inputToArr = input[i].split(' | ');
        var band = inputToArr[0];
        //console.log(band);
        var town = inputToArr[1];
        //console.log(town);
        var venue = inputToArr[3];
        //console.log(venue);

        if(concert.hasOwnProperty(town)) {
            if(concert[town][venue]) {
                if(concert[town][venue].indexOf(band) === -1){
                    concert[town][venue].push(band);
                    concert[town][venue].sort();
                }
            } else {
                concert[town][venue] = [band];
            }

        } else {
            concert[town] = {};
            concert[town][venue] = [band];
        }
    }
    var towns = Object.keys(concert).sort();
    for (var i = 0; i < towns.length; i++) {
        town = towns[i];
        output[town] = {};
        var venues = Object.keys(concert[town]).sort();
        for (var j = 0; j < venues.length; j++) {
            output[town][venues[j]] = concert[town][venues[j]];
        }

    }
    console.log(JSON.stringify(output));
}


var input = [
	['ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
	 'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
	 'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
	 'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
	 'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
	 'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
	 'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
	 'Helloween | London | 28-Jul-2014 | Wembley Stadium',
     'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
     'Metallica | London | 03-Oct-2014 | Olympic Stadium',
     'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
     'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium']
];
for(var obj in input) {
    console.log(solve(input[obj]));
}
