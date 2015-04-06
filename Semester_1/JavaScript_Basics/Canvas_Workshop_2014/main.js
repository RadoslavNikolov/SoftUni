/**
 * Created by isrmn on 18.3.2015 г..
 */
var canvas;
var ctx;
var cWidth;
var cHeight;
var pic = new Image();
pic.src = "images/dots.png";
var carPic = new Image();
carPic.src = "images/cars.jpg";
var x = 0;
var y = 0;


function draw() {
    //draw random color square
    //randomColorSquare();

    //draw linear gradient
    //linearGradient();

    //draw radial gradient
    //radialGradient();

    //insert image as background
    //createPattern();

    //draw line
    //drawPath();

    //draw triangle
    //drawTriangle(300,300,300,480,500,480);

    //draw check element
    //drawCheck();

    //draw image    like some player1 in a game
    //drawImage();

    //draw text
    //drawText();

    //drawShadowSquare();

    //drawCircle();
    //compositing();




    //clear(); //invoke clear function witch clear canvas scene

}
function animate() {
    ctx.save();
    clear();
    ctx.fillStyle = "green";
    ctx.fillRect(x,y,100,100)
    ctx.restore();
    window.requestAnimationFrame(animate);

}
document.addEventListener("keydown",function(event){
    var keyCode = event.keyCode;
    if(keyCode == 37) { //left
        if(x-3 >= 0) {
            x -=3;
        }
    } else if(keyCode == 38) { //up
        if(y-3>=0) {
            y -=3;
        }
    } else if(keyCode == 39) { //right
        if(x+3+100<=cWidth) {
            x +=3;
        }
    } else if(keyCode == 40) { //down
        if(y+3+100<=cHeight) {
            y +=3;
        }

    }
});
function compositing() {
    ctx.fillStyle = "magenta";
    ctx.fillRect(0,0,100,100);
    ctx.globalCompositeOperation = "source-over" //source-atop,source-in,source-out,destination-over
    ctx.fillStyle = "yellow";
    ctx.fillRect(50,50,100,100);
    ctx.globalCompositeOperation = "destination-over"
    ctx.fillStyle = "blue";
    ctx.fillRect(100,100,100,100);
}
function drawCircle() {
    ctx.arc(100,100,50,0,Math.PI * 2,false); // startX,startY,radius...
    ctx.stroke();
}
function drawShadowSquare() {
    ctx.fillStyle = "yellow";
    ctx.shadowColor = "black";
    ctx.shadowOffsetX = 10;
    ctx.shadowOffsetY = -10;
    ctx.shadowBlur = 10;
    ctx.fillRect(20,20,150,150); //invoke last
}
function drawText() {
    ctx.font = "italic 85px Arial bold";
    ctx.fillStyle = "blue";
    ctx.textAlign = "start"; // start,center,end
    ctx.textBaseline = "middle"; // top,middle,bottom...
    ctx.fillText("Canvas text",200,80,250); //(string,x,y,size)
    ctx.strokeStyle = "red";
    ctx.strokeText("Canvas text", 200,80,250);
}
function drawImage() {
    ctx.drawImage(carPic,0,40);  // (image,x,y)
    ctx.drawImage(carPic,250,250,150,100) // image,x,y,size
    ctx.drawImage(carPic,0,0,238,72,400,400,238,72) //image,slice image(clipX,clipY,clipWidth,clipHeight),x,y,size
}
function drawCheck() {
    ctx.beginPath();
    ctx.lineWidth = 15;
    ctx.lineCap = "round"; // "butt", "round", "square"
    ctx.moveTo(50,50);
    ctx.lineTo(75,75);
    ctx.lineTo(100,20);
    ctx.stroke();
    ctx.closePath();
}
function drawPath() {
    ctx.beginPath();
    ctx.moveTo(20,20);
    ctx.lineTo(20,150);
    ctx.lineTo(150,150);
    ctx.lineTo(20,20);
    //stroke most be at the end to draw the path
    ctx.stroke();
    //close the path
    ctx.closePath();
}
function drawTriangle(x1,y1,x2,y2,x3,y3) {
    ctx.beginPath();
    ctx.moveTo(x1,y1);
    ctx.lineTo(x2,y2);
    ctx.lineTo(x3,y3);
    ctx.lineTo(x1,y1);
    //stroke most be at the end to draw the path
    ctx.strokeStyle = "blue";
    ctx.lineWidth = 10;
    ctx.stroke();
    ctx.fillStyle = "red";
    ctx.fill();
    //close the path
    ctx.closePath();
}
function createPattern() {
    var pattern = ctx.createPattern(pic,"repeat");
    ctx.fillStyle = pattern;
    ctx.fillRect(0,0,cWidth,cHeight);
}
function radialGradient() {
    var g2 = ctx.createRadialGradient(350,100,0,350,120,100);
    g2.addColorStop(0, "magenta");
    g2.addColorStop(1, "black");

    ctx.fillStyle = g2;
    ctx.fillRect(250,0,200,200);
}
function linearGradient() {
    var g1 = ctx.createLinearGradient(0,0,0,200);
    g1.addColorStop(0.3, "yellow");
    g1.addColorStop(0.6, "green");
    g1.addColorStop(1, "red");

    ctx.fillStyle = g1;
    ctx.fillRect(0,0,300,200);
}
function randomColorSquare() {
    for (var col = 0; col < 11; col++) {
        for (var row = 0; row < 8; row++) {
            ctx.fillStyle = randomColor();
            ctx.strokeStyle = randomColor();
            ctx.strokeRect(60*col + 10,60*row +10,50,50);
            ctx.fillRect(60*col + 10,60*row +10,50,50);
        }
    }
}
function randomColor() {
    var redRand = Math.floor(Math.random() * 255);
    var greenRand = Math.floor(Math.random() * 255);
    var blueRand = Math.floor(Math.random() * 255);
    return "rgb(" + redRand + "," + greenRand + "," + blueRand + ")";
}

function clear() {
    //clear canvas scene
    ctx.clearRect(0,0,cWidth,cHeight);
}

function init() {
    canvas = document.getElementById('canvas');
    ctx = canvas.getContext('2d');
    cWidth = canvas.width;
    cHeight = canvas.height;
    animate();

    draw();
}

window.addEventListener('load', init);