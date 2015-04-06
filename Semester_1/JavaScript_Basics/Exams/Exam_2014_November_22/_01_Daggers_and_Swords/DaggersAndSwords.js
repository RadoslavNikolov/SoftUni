/**
 * Created by isrmn on 21.3.2015 г..
 */
function solve(input) {
    console.log('<table border="1">\n<thead>\n<tr><th colspan="3">Blades</th></tr>\n<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n</thead>\n\<tbody>');
    for(var index in input) {
        var bladeLenght = parseInt(input[index]);
        if(bladeLenght > 10) {
            var bladeType = bladeLenght > 40 ? 'sword' : 'dagger';
            var bladeApplication = checkBladeApplication(bladeLenght);
            console.log('<tr><td>' + bladeLenght + '</td><td>' + bladeType + '</td><td>' + bladeApplication + '</td></tr>');
        }
    }

    console.log('</tbody>\n</table>');

    function checkBladeApplication(bladeLenght) {
        switch(bladeLenght % 10) {
            case 1:case 6: return 'blade';
            case 2:case 7: return 'quite a blade';
            case 3:case 8: return 'pants-scraper';
            case 4:case 9: return 'frog-butcher';
            case 5:case 0: return '*rap-poker';
        }
    }
}

//var input = [
//    ['17.8',
//     '19.4',
//     '13',
//     '55.8',
//     '126.96541651',
//     '3']
//];
//
//for (var str in input) {
//    solve(input[str]);
//}