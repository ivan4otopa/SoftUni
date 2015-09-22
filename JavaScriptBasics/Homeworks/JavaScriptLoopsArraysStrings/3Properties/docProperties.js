function displayProperties() {
	var arr = Object.getOwnPropertyNames(document);
	arr.sort();
	console.log(arr.join('\n'));
	var result = arr.join('<br>');
	document.getElementById('result').innerHTML = result;
}

displayProperties();