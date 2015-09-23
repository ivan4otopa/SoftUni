var button = $('button');

button.on('click', function () {
	var color = $('#color').val();
	var chosenClass = '.' + $('#class').val();
	$(chosenClass).css('background', color);
});