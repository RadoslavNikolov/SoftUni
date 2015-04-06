/**
 * Created by isrmn on 12.3.2015 г..
 */
function extract(input) {
    var html = input.join('\n');
    var pattern = /<a\s+([^>]?)*href\s*=\s*("[^"]*|'[^']*|[^>\s]*)/g;
    var match;
    while(match = pattern.exec(html)) {
        var link = match[2];
        if(link[0] === '"') {
            link = link.replace('"','');
        }
        if(link[0] === '\'') {
            link = link.replace('\'','');
        }
        console.log(link);
    }

}
//var input = [
//    '<a href="http://softuni.bg" class="new"></a>',
//    '<p>This text has no links</p>',
//'<!DOCTYPE html>',
//'<html>',
//'<head>',
//'  <title>Hyperlinks</title>',
//'  <link href="theme.css" rel="stylesheet" />',
//'</head>',
//'<body>',
//'<ul><li><a   href="/"  id="home">Home</a></li><li><a',
//' class="selected" href=/courses>Courses</a>',
//'</li><li><a href = ',
//'\'/forum\' >Forum</a></li><li><a class="href"',
//'onclick="go()" href= "#">Forum</a></li>',
//'<li><a id="js" href =',
//'"javascript:alert(\'hi yo\')" class="new">click</a></li>',
//'<li><a id=\'nakov\' href =',
//'    http:\/\/www.nakov.com class=\'new\'>nak</a></li></ul>',
//'<a href="#empty"></a>',
//'<a id="href">href=\'fake\'<img src=\'http:\/\/abv.bg\/i.gif\' ',
//    'alt=\'abv\'/></a><a href="#">&lt;a href=\'hello\'&gt;</a>',
//'<!-- This code is commented:',
//'    <a href="#commented">commentex hyperlink</a> -->',
//'  </body>'];
//
//extract(input);
