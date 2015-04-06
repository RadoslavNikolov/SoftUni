/**
 * Created by isrmn on 21.3.2015 г..
 */
function solve(input) {
    var cloud = {};
    var sortedOutput  = {};
    //console.log(input);
    input.forEach(function(arg){
        var row = arg.split(/\s+/g);
        var programName = row[0];
        var fileExtension = row[1];
        var fileSize = parseFloat(row[2]);
        if(!cloud[fileExtension]) {
            cloud[fileExtension] = {'files': [programName],'memory': fileSize};
        } else {
            if(cloud[fileExtension]['files'].indexOf(programName) === -1) {
                cloud[fileExtension]['files'].push(programName);
            }
            cloud[fileExtension]['memory'] += fileSize;
        }
        //console.log(programName,fileExtension,fileSize);
    });

    var keys = Object.keys(cloud).sort();
    keys.forEach(function(fileExtension){
        sortedOutput[fileExtension] = cloud[fileExtension];
        sortedOutput[fileExtension]['files'] = sortedOutput[fileExtension]['files'].sort();
        sortedOutput[fileExtension]['memory'] = sortedOutput[fileExtension]['memory'].toFixed(2);
    });
    console.log(JSON.stringify(sortedOutput));
}

//var input = [
//    ['sentinel .exe 15MB',
//     'zoomIt .msi 3MB',
//     'skype .exe 45MB',
//     'trojanStopper .bat 23MB',
//     'kindleInstaller .exe 120MB',
//     'setup .msi 33.4MB',
//     'winBlock .bat 1MB']
//];
//
//for (var str in input) {
//    solve(input[str]);
//}