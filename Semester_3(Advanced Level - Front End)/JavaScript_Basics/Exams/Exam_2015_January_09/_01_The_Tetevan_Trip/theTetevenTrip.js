/**
 * Created by toshiba on 1.4.2015 г..
 */
function solve(input) {
    //console.log(input);
    input.forEach(function(strLine){
        var row = strLine.split(' ');
        //console.log(row);
        var carModel = row[0];
        var fuel = row[1];
        var road  = row[2];
        var weight = Number(row[3]);
        var totalSonsumption = 0;

        //per km.
        var fuelCounsumption = 10;

        switch(fuel) {
            case 'petrol': fuelCounsumption *=1; break;
            case 'gas': fuelCounsumption *= 1.2; break;
            case 'diesel': fuelCounsumption *= 0.8; break;
            default : break;
        }
        fuelCounsumption += (weight*0.01);
        if(road === '1') {
            totalSonsumption += (100*fuelCounsumption/100 + 10*fuelCounsumption*1.3/100);
        } else {
            totalSonsumption += (65*fuelCounsumption/100 + 30*fuelCounsumption*1.3/100);
        }
        console.log(carModel + ' ' + fuel + ' ' + road + ' ' + Math.round(totalSonsumption));
    });
}


//solve(['BMW petrol 1 320.5',
//        'Golf petrol 2 150.75',
//        'Lada gas 1 202',
//        'Mercedes diesel 2 312.54']
//);