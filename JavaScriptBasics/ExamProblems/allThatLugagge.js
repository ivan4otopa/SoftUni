function allThatLuggage(input) {
	var result = {};
	var criterion = input[input.length - 1];
	for(var i = 0; i < input.length - 1; i++) {
		var matches = input[i].split(/\.+*\.+/g);
		console.log(matches);
	}
}

allThatLuggage(['Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
'strict'
]);