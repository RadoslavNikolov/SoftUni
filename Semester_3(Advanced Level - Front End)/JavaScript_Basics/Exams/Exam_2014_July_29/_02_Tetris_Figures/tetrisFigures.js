/**
 * Created by radko on 19.3.2015 г..
 */
function solve(input) {
    //console.log(input);
    var result = { "I": 0, "L": 0, "J": 0, "O": 0, "Z": 0, "S": 0, "T": 0};
    var symbol = 'o';
    var rows = input.length;
    var cols = input[0].length;

    for (var row = 0; row < rows; row++) {
        for (var col = 0; col < cols; col++) {
            // -I-
            if(row + 3 < rows &&
                input[row][col] === symbol &&
                input[row+1][col] === symbol &&
                input[row+2][col] === symbol &&
                input[row+3][col] === symbol) {
                result.I++;
            }
            // -L-
            if(row + 2 < rows &&
                input[row][col] === symbol &&
                input[row+1][col] === symbol &&
                input[row+2][col] === symbol &&
                input[row+2][col+1] === symbol) {
                result.L++;
            }
            // -J-
            if(row + 2 < rows && col-1>=0 &&
                input[row][col] === symbol &&
                input[row+1][col] === symbol &&
                input[row+2][col] === symbol &&
                input[row+2][col-1] === symbol) {
                result.J++;
            }
            // -O-
            if(row + 1 < rows && col+1 < cols &&
                input[row][col] === symbol &&
                input[row][col+1] === symbol &&
                input[row+1][col] === symbol &&
                input[row+1][col+1] === symbol) {
                result.O++;
            }
            // -Z-
            if(row + 1 < rows && col+2 < cols &&
                input[row][col] === symbol &&
                input[row][col+1] === symbol &&
                input[row+1][col+1] === symbol &&
                input[row+1][col+2] === symbol) {
                result.Z++;
            }
            // -S-
            if(row + 1 < rows && col-2 >= 0 &&
                input[row][col] === symbol &&
                input[row][col-1] === symbol &&
                input[row+1][col-1] === symbol &&
                input[row+1][col-2] === symbol) {
                result.S++;
            }
            // -T-
            if(row + 1 < rows && col+2 < cols &&
                input[row][col] === symbol &&
                input[row][col+1] === symbol &&
                input[row][col+2] === symbol &&
                input[row+1][col+1] === symbol) {
                result.T++;
            }
        }
    }
    console.log(JSON.stringify(result));
}

//var input = [
//    ['--o--o-',
//     '--oo-oo',
//     'ooo-oo-',
//     '-ooooo-',
//     '---oo--'],
//    ['-oo','ooo','ooo']
//];
//
//for (var str in input) {
//    sumNumbers(input[str]);
//}