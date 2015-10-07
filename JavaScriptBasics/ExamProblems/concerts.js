function concerts(input) {
	var concerts = input;
	var show = {};
	for(var i = 0; i < concerts.length; i++) {
		var concert = concerts[i].split('|');
		var band = concert[0].trim();
		var town = concert[1].trim();
		var venue = concert[3].trim();
		if(!show[town])
			show[town] = {};
		if(!show[town][venue])
			show[town][venue] = [];
		if(show[town][venue].indexOf(band) == -1)
			show[town][venue].push(band)
	}
	show = sortObjectProperties(show);
	for(var town in show) {
		show[town] = sortObjectProperties(show[town]);
		for(var venue in show[town])
			show[town][venue].sort();
	}
	console.log(JSON.stringify(show));
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

concerts(['ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
'Helloween | London | 28-Jul-2014 | Wembley Stadium',
'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
'Metallica | London | 03-Oct-2014 | Olympic Stadium',
'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium'
]);