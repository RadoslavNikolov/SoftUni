/**
 * Created by radko on 30.3.2015 г..
 */
function solve(input) {
    //console.log(input);
    var checkedDate = new Date('05.25.1973');
    var minDate = new Date('01.01.1900');
    var maxDate = new Date('01.01.2015');
    var fan;
    var hater;
    //console.log(!!fan);
    input.forEach(function(dates){
        var tempArr = dates.split('.');
        var dateString = tempArr[1] + '.' +  tempArr[0] + '.' + tempArr[2];
        var date = new Date(dateString);

        //console.log(date);
        if(date > minDate && date <= checkedDate) {
            if(!hater) {
                hater = date;
            } else if(date < hater) {
                hater = date;
            }
        }

        if(date <= maxDate && date > checkedDate) {
            if(!fan) {
                fan = date;
            } else if(date > fan) {
                fan = date;
            }
        }
    });

    if(!!fan || !!hater) {
        if(!!fan) {
            console.log('The biggest fan of ewoks was born on ' + fan.toDateString());
        }
        if(!!hater) {
            console.log('The biggest hater of ewoks was born on ' + hater.toDateString());
        }
    } else {
        console.log('No result');
    }
}



//var input = [
//    ['22.03.2014', '17.05.1933', '10.10.1954'],
//    ['22.03.2000'],
//    ['22.03.1700', '01.07.2020']
//    ];
//
//for (var arr in input) {
//    solve(input[arr]);
//
//}