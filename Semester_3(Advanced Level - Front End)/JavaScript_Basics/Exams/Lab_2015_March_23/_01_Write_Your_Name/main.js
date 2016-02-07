/**
 * Created by toshiba on 23.3.2015 г..
 */
var canvas;
var ctx;
var cWidth;
var cHeight;


function draw() {
    drawText();
}

function drawText() {
    ctx.font = "85px Arial bold";
    ctx.fillStyle = "rgb(255,193,206)";
    ctx.textAlign = "start";
    ctx.textBaseline = "middle";
    ctx.fillText("Radoslav",200,80,250);
    ctx.strokeStyle = "green";
    ctx.lineWidth = 3;
    ctx.strokeText("Radoslav", 200,80,250);
}




function init() {
    canvas = document.getElementById('canvas');
    ctx = canvas.getContext('2d');
    cWidth = canvas.width;
    cHeight = canvas.height;
    draw();
}

window.addEventListener('load', init);