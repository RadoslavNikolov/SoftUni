/**
 * Created by toshiba on 23.3.2015 г..
 */
var canvas;
var ctx;
var cWidth;
var cHeight;


function draw() {
    ctx.strokeStyle = "black";
    ctx.fillStyle = "rgb(151,91,91)";
    ctx.lineWidth = 2;
    ctx.beginPath();
    ctx.moveTo(250, 50);
    ctx.lineTo(400,200);
    ctx.lineTo(400,400);
    ctx.lineTo(100,400);
    ctx.lineTo(100,200);
    ctx.lineTo(250,50);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(100,200);
    ctx.lineTo(400,200);
    ctx.stroke();
    ctx.closePath();

    drawWindows();
    drawDoor();
    drawChimney();

}
function drawDoor() {
    var width = 90;
    var height = 70;

    ctx.strokeStyle = "black";
    ctx.lineWidth = 2;

    ctx.beginPath();
    ctx.moveTo(130, 400);
    ctx.lineTo(130,400 - height);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(130 + width, 400);
    ctx.lineTo(130 + width,400 - height);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(130,400 - height); // A1
    var arcHeight = 65;
    var centerX = 130 + width/2;
    var centerY =  400 - height;
    ctx.bezierCurveTo(
        centerX - width/2, centerY - arcHeight/2, // C1
        centerX + width/2, centerY - arcHeight/2, // C2
        centerX + width/2, centerY); // A2
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(130 + width/2, 400);
    ctx.lineTo(130 + width/2,400 - height - arcHeight/2 +9);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.arc(130 + width/2 - 10,370,5,0,Math.PI * 2,false); // startX,startY,radius...
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.arc(130 + width/2 + 10,370,5,0,Math.PI * 2,false); // startX,startY,radius...
    ctx.stroke();
    ctx.closePath();

}
function drawChimney(){
    ctx.strokeStyle = "black";
    ctx.fillStyle = "rgb(151,91,91)";
    ctx.lineWidth = 2;

    ctx.beginPath();
    ctx.moveTo(305, 150);
    ctx.lineTo(305,80);
    ctx.lineTo(335,80);
    ctx.lineTo(335,150);
    ctx.fill();
    ctx.stroke();
    ctx.closePath();


    ctx.beginPath();
    ctx.moveTo(305,80); // A1
    var width = 30;
    var height = 15;
    var centerX = 305 + width/2;
    var centerY =  80;
    ctx.bezierCurveTo(
        centerX - width/2, centerY - height/2, // C1
        centerX + width/2, centerY - height/2, // C2
        centerX + width/2, centerY); // A2
    ctx.bezierCurveTo(
        centerX + width/2, centerY + height/2, // C3
        centerX - width/2, centerY + height/2, // C4
        centerX - width/2, centerY); // A1
    ctx.fill();
    ctx.stroke();
    ctx.closePath();


}
function drawWindows() {
    ctx.fillStyle = "black";
    ctx.strokeStyle = "rgb(151,91,91)";
    ctx.lineWidth = 3;
    var width = 110;
    var height = 65;

    //left window
    ctx.beginPath();
    ctx.moveTo(120, 220);
    ctx.lineTo(120+width,220);
    ctx.lineTo(120 + width,220 + height);
    ctx.lineTo(120,220 + height);
    ctx.lineTo(120,220);
    ctx.fill();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(120 + width/2, 220);
    ctx.lineTo(120 + width/2,220 + height);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(120, 220 + height/2);
    ctx.lineTo(120 + width,220 + height/2);
    ctx.stroke();
    ctx.closePath();


    //right window
    ctx.beginPath();
    ctx.moveTo(265, 220);
    ctx.lineTo(265 + width,220);
    ctx.lineTo(265 + width,220 + height);
    ctx.lineTo(265,220 + height);
    ctx.lineTo(265,220);
    ctx.fill();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(265 + width/2, 220);
    ctx.lineTo(265 + width/2,220 + height);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(265, 220 + height/2);
    ctx.lineTo(265 + width,220 + height/2);
    ctx.stroke();
    ctx.closePath();

    //down window
    ctx.beginPath();
    ctx.moveTo(265, 310);
    ctx.lineTo(265 + width,310);
    ctx.lineTo(265 + width,310 + height);
    ctx.lineTo(265,310 + height);
    ctx.lineTo(265,310);
    ctx.fill();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(265 + width/2, 310);
    ctx.lineTo(265 + width/2,310 + height);
    ctx.stroke();
    ctx.closePath();

    ctx.beginPath();
    ctx.moveTo(265, 310 + height/2);
    ctx.lineTo(265 + width,310 + height/2);
    ctx.stroke();
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