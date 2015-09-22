var painted;
var content;
var winningCombinations;
var turn = 0;
var theCanvas;
var c;
var cxt;
var squaresFilled = 0;
var w;
var y;
var chicken;

window.onload=function() {
    painted = new Array();
    content = new Array();
    winningCombinations = [[0,1,2],[3,4,5],[6,7,8],[0,3,6],[1,4,7],[2,5,8],[0,4,8],[2,4,6]];

    for(var l = 0; l <= 8; l++) {
        painted[l] = false;
        content[l] = '';
    }
}

function canvasClicked (canvasNumber) {
    theCanvas = "canvas" + canvasNumber;
    c = document.getElementById(theCanvas);
    cxt = c.getContext("2d");

    if(painted[canvasNumber - 1] == false) {

        if(turn % 2 == 0) {
            cxt.beginPath();
            cxt.moveTo(30, 30);
            cxt.lineTo(250, 120);
            cxt.lineWidth = 20;
            cxt.moveTo(250, 30);
            cxt.lineTo(30, 120);
            cxt.lineWidth = 20;
            cxt.stroke();
            cxt.closePath();
            content[canvasNumber - 1] = 'X';
        }

        else {
            cxt.beginPath();
            cxt.arc(150, 75, 60, 0, Math.PI * 2, true);
            cxt.lineWidth = 20;
            cxt.stroke();
            cxt.closePath();
            content[canvasNumber - 1] = 'O';
        }

        turn++;
        painted[canvasNumber - 1] = true;
        squaresFilled++;
        checkForWinners(content[canvasNumber - 1]);

        if(squaresFilled == 9) {
            alert("THE GAME IS OVER!");
            location.reload(true);
        }
    }

    else {
        alert("Occupied!");
    }
}

function checkForWinners(symbol) {
    for(var a = 0; a < winningCombinations.length; a++) {

        if(content[winningCombinations[a][0]] == symbol && content[winningCombinations[a][1]] == symbol && content[winningCombinations[a][2]] == symbol) {
            repaintBox(winningCombinations[a][0], symbol);
            repaintBox(winningCombinations[a][1], symbol);
            repaintBox(winningCombinations[a][2], symbol);
            alert(symbol + " Won!");
            playAgain();
        }
    }
}

function repaintBox(boxNumber, symbol) {
    theCanvas = "canvas" + (boxNumber + 1);
    c = document.getElementById(theCanvas);
    cxt = c.getContext("2d");

    if (symbol == 'X') {
        cxt.beginPath();
        cxt.moveTo(30, 30);
        cxt.lineTo(250, 120);
        cxt.lineWidth = 20;
        cxt.moveTo(250, 30);
        cxt.lineTo(30, 120);
        cxt.lineWidth = 20;
        cxt.strokeStyle = "rgb(12, 205,0)";
        cxt.stroke();
        cxt.closePath();
    }

    else {
        cxt.beginPath();
        cxt.arc(150, 75, 60, 0, Math.PI * 2, true);
        cxt.lineWidth = 20;
        cxt.strokeStyle = "rgb(12, 205, 0";
        cxt.stroke();
        cxt.closePath();
    }
}

function playAgain() {
    y = confirm("Play again?");

    if(y == true) {
        location.reload(true);
    }

    else {
        chicken = confirm("Chicken?");

        if(chicken == true)
        alert("Bye!");

        else {
            location.reload(true);
        }
    }
}
