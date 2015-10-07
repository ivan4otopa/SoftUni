function ewoksFans(input) {
	var ceil = new Date(1899, 12, 31);
	var floor = new Date(2015, 01, 01);
	var ewok = new Date(1973, 05, 25);
	var dates = [];
	for(var i = 0; i < input.length; i++) {
		var day = input[i].substr(0, 2);
		var month = input[i].substr(3, 2) - 1;
		var year = input[i].substr(6, 4);
		var date = new Date(year, month, day);
		if(date > ceil && date < floor)
			dates.push(date);
	}
	dates.sort(function (a, b) {
		return a - b;
	});
	if(dates.length > 0) {
		if(dates[dates.length - 1] > ewok)
			console.log('The biggest fan of ewoks was born on ' + dates[dates.length - 1].toDateString());
		if(dates[0] < ewok)
			console.log('The biggest hater of ewoks was born on ' + dates[0].toDateString());
	}
	else
		console.log('No result');
}

// ewoksFans(["22.03.2014",
// '17.05.1933',
// '10.10.1954'
// ]);

// ewoksFans(['22.03.2000']);

// ewoksFans(['22.03.1700',
// '01.07.2020'
// ]);

ewoksFans(['10.10.1566',
'10.10.1966',
'10.10.1967',
'10.10.1968',
'10.10.1969',
'10.10.1970',
'10.10.1971',
'11.11.2006',
'11.11.2007',
'11.11.2008',
'11.11.2009',
'11.11.2010',
'11.11.2011',
'11.11.2012'
])