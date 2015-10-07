function vladkosNotebook(input) {
	var notebook = {};
	for(var i = 0; i < input.length; i++) {
		var notes = input[i].split('|');
		var color = notes[0];
		if(!notebook[color])
			notebook[color] = { 'opponents': [], 'wins': 0, 'losses': 0 };
		if(notes[1] == 'name' || notes[1] == 'age')
			notebook[color][notes[1]] = notes[2];
		else {
			if(notes[1] == 'win')
				notebook[color].wins++;
			else
				notebook[color].losses++;
			notebook[color].opponents.push(notes[2]);
		}
	}
	notebook = sortObjectProperties(notebook);
	for(var color in notebook) {
		notebook[color].opponents.sort();
		notebook[color].rank = ((notebook[color].wins + 1) / (notebook[color].losses + 1)).toFixed(2);
		delete notebook[color].wins;
		delete notebook[color].losses;
		notebook[color] = sortObjectProperties(notebook[color]);
		if(!notebook[color].name || !notebook[color].age)
			delete notebook[color];
	}
	console.log(JSON.stringify(notebook));
	function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
    }
}

vladkosNotebook(['purple|age|99',
'red|age|44',
'blue|win|pesho',
'blue|win|mariya',
'purple|loss|Kiko',
'purple|loss|Kiko',
'purple|loss|Kiko',
'purple|loss|Yana',
'purple|loss|Yana',
'purple|loss|Manov',
'purple|loss|Manov',
'red|name|gosho',
'blue|win|Vladko',
'purple|loss|Yana',
'purple|name|VladoKaramfilov',
'blue|age|21',
'blue|loss|Pesho'
]);