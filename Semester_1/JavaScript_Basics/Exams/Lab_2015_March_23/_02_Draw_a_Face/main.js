/**
 * Created by toshiba on 23.3.2015 г..
 */
var canvas;
var ctx;
var cWidth;
var cHeight;


function draw() {
    drawHead();
    drawEyes();
    drawNose();
    drawMouth();
    drawHat();

}
function drawHead() {
    ctx.arc(300,300,80,0,Math.PI * 2,false);
    ctx.fillStyle = "rgb(144,202,215)";
    ctx.fill();
    ctx.strokeStyle = "rgb(49,89,100)";
    ctx.lineWidth = 2;
    ctx.stroke();
}
function drawEyes() {
    //left eye
    ctx.beginPath();
    ctx.moveTo(270, 270); // A1
    var width = 30;
    var height = 20;
    var centerX = 270 - width/2;
    var centerY =  270;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C3
        centerX + width/2, centerY - height/2, // C4
        centerX + width/2, centerY); // A1
    ctx.stroke();
    ctx.closePath();

    //right eye
    ctx.beginPath();
    ctx.moveTo(335, 270); // A1
    var width = 30;
    var height = 20;
    var centerX = 335 - width/2;
    var centerY =  270;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C3
        centerX + width/2, centerY - height/2, // C4
        centerX + width/2, centerY); // A1
    ctx.stroke();
    ctx.closePath();

    //left pupil
    ctx.beginPath();
    ctx.moveTo(255, 260); // A1
    var width = 10;
    var height = 18;
    var centerX = 255 - width/2;
    var centerY =  270;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C3
        centerX + width/2, centerY - height/2, // C4
        centerX + width/2, centerY); // A1
    ctx.fillStyle = "rgb(49,89,100)";
    ctx.fill();
    ctx.closePath();

//right pupil
    ctx.beginPath();
    ctx.moveTo(320, 260); // A1
    var width = 10;
    var height = 18;
    var centerX = 320 - width/2;
    var centerY =  270;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C3
        centerX + width/2, centerY - height/2, // C4
        centerX + width/2, centerY); // A1
    ctx.fillStyle = "rgb(49,89,100)";
    ctx.fill();
    ctx.closePath();



}
function drawNose() {
    //ctx.strokeStyle = "rgb(49,89,100)";
    ctx.beginPath();
    ctx.moveTo(290, 270); // A1
    ctx.lineTo(270,305);
    ctx.lineTo(288,305);
    ctx.stroke();
    ctx.closePath();
}
function drawMouth(){
    ctx.beginPath();
    ctx.moveTo(320, 345); // A1
    var width = 60;
    var height = 20;
    var centerX = 320 - width/2;
    var centerY =  345;
    ctx.bezierCurveTo(
        centerX + width/2-10, centerY + height/2, // C1
        centerX - width/2, centerY + height/2-5, // C2
        centerX - width/2, centerY-10); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2-10, // C3
        centerX + width/2, centerY - height/2-5, // C4
        centerX + width/2, centerY); // A1
    ctx.stroke();
    ctx.closePath();
}
function drawHat() {
    ctx.strokeStyle = "black";
    ctx.fillStyle = "rgb(57,102,147)";
    ctx.lineWidth = 4;
    ctx.beginPath();
    ctx.moveTo(375,230 ); // A1
    var width = 170;
    var height = 60;
    var centerX = 375 - width/2;
    var centerY =  230;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C3
        centerX + width/2, centerY - height/2, // C4
        centerX + width/2, centerY); // A1
    ctx.stroke();
    ctx.fill();
    ctx.closePath();

    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(346, 140);
    ctx.lineTo(346,213);
    ctx.lineTo(254,211);
    ctx.lineTo(254,140);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.lineWidth = 4;
    ctx.moveTo(345,211); // A1
    var width = 90;
    var height = 45;
    var centerX = 345 - width/2;
    var centerY =  211;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY-2); // A2
    ctx.stroke();
    ctx.fill();
    ctx.closePath();


    ctx.beginPath();
    ctx.lineWidth = 4;
    ctx.moveTo(345,140 ); // A1
    var width = 90;
    var height = 45;
    var centerX = 345 - width/2;
    var centerY =  140;
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C1
        centerX - width/2, centerY + height/2, // C2
        centerX - width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C3
        centerX + width/2, centerY - height/2, // C4
        centerX + width/2, centerY); // A1
    ctx.stroke();
    ctx.fill();
    ctx.closePath();
}
function init() {
    canvas = document.getElementById('canvas');
    ctx = canvas.getContext('2d');
    cWidth = canvas.width;
    cHeight = canvas.height;
    draw();
}

window.addEventListener('load', init);ctx.strokeText("Radoslav", 200,80,250);