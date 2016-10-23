/**
 * Created by toshiba on 1.4.2015 г..
 */
function solve(input) {
    var pos;
    var aha = false;

    for (var i in input){
        if(aha) {
            for(var c in input[i]) {
                if(input[i][c] == '>') {
                    pos++;
                } else if (input[i][c] == '<') {
                    pos--;
                }
            }
        }
        switch(input[i][pos]) {
            case '_': console.log('Landed on the ground like a boss!\n' + i + ' '+ pos); return; break;
            case '~': console.log('Drowned in the water like a cat!\n' + i + ' '+ pos); return; break;
            case '/':
            case '\\':
            case '|': console.log('Got smacked on the rock like a dog!\n' + i + ' '+ pos); return; break;
            default : break;
        }

        if(!aha) {
            pos = input[i].indexOf('o');
            if(pos > -1) {
                aha = true;;
            }
        }


    }
}

//var input = [
//    ['--o----------------------',
//        '>------------------------',
//        '>------------------------',
//        '>-----------------/\\-----',
//        '-----------------/--\\----',
//        '>---------/\\----/----\\---',
//        '---------/--\\--/------\\--',
//        '<-------/----\\/--------\\-',
//        '\\------/----------------\\',
//        '-\\____/------------------', ],
//
//    [
//        '>>>>>>>>>>>o<<<<<<<<<<<<<',
//        '----------~~~------------',
//        '--------~/~~~\\~----------',
//        '-------~/~---~\\~---------',
//        '------~/~-----~\\~--------',
//        '-----~/~-------~\\~-------',
//        '----~/~---------~\\~------',
//        '---~/~-----------~\\~-----',
//        '--~/~-------------~\\~----',
//        '-~/~---------------~\\~----',
//    ]
//];
//
//for (var str in input) {
//    sumNumbers(input[str]);
//}