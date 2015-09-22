function calcExpression(expression) {
	var result = eval(expression);
	document.getElementById('result').innerHTML = result;
}