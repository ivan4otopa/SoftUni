var input = document.getElementById('tag');
function numbersOnlyField() {
	if(input.value != 'body') {
		input.style.background = 'rgb(253, 254, 193)';
		setTimeout(function() { input.style.background = 'rgb(255, 255, 255)'; }, 1000);
	}
}
input.addEventListener('input', numbersOnlyField);