var number = prompt("Enter a number");

if(number < 0) {
	number = prompt("Enter a positive number");
}

var hex = parseInt(number).toString(16);

alert(hex.toUpperCase());