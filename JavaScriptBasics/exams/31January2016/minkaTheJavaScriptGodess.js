function minkaTheJavaScriptGodess(input) {
	var tasks = {
			'Task 1': { 'tasks': [], 'average': 0, 'lines': 0 },
			'Task 2': { 'tasks': [], 'average': 0, 'lines': 0 },
			'Task 3': { 'tasks': [], 'average': 0, 'lines': 0 },
			'Task 4': { 'tasks': [], 'average': 0, 'lines': 0 },
			'Task 5': { 'tasks': [], 'average': 0, 'lines': 0 }
	};
	var taskParts = [];
	var name = '';
	var type = '';
	var taskNumber = 0;
	var score = 0;
	var linesOfCode = 0;

	for (var i = 0; i < input.length; i++) {
		taskParts = input[i].split('&');
		name = taskParts[0].trim();
		type = taskParts[1].trim();
		taskNumber = Number(taskParts[2].trim());
		score = Number(taskParts[3].trim());
		linesOfCode = Number(taskParts[4].trim());

		tasks['Task ' + taskNumber]['tasks'].push({ 'name': name, 'type': type });
		tasks['Task ' + taskNumber]['average'] += score;
		tasks['Task ' + taskNumber]['lines'] += linesOfCode;
	}

	for (var task in tasks) {
		tasks[task].tasks.sort(function (a, b) {
			return a.name.localeCompare(b.name);
		});

		tasks[task].average = parseFloat((tasks[task].average / tasks[task].tasks.length).toFixed(2));
	}

	var sortedObject = sortObjectProperties(tasks);

	console.log(JSON.stringify(sortedObject));

	function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort(function (a, b) {
        	if (obj[a].average == obj[b].average) {
        		return obj[a].lines - obj[b].lines;
        	}

        	return obj[b].average - obj[a].average;
        });

        var sortedObj = {};
        
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        
        return sortedObj;
    }
}

minkaTheJavaScriptGodess([
	'Array Matcher & strings & 4 & 100 & 38',
	'Magic Wand & draw & 3 & 100 & 15',
	'Dream Item & loops & 2 & 88 & 80',
	'Knight Path & bits & 5 & 100 & 65',
	'Basket Battle & conditionals & 2 & 100 & 120',
	'Torrent Pirate & calculations & 1 & 100 & 20',
	'Encrypted Matrix & nested loops & 4 & 90 & 52',
	'Game of bits & bits & 5 &  100 & 18',
	'Fit box in box & conditionals & 1 & 100 & 95',
	'Disk & draw & 3 & 90 & 15',
	'Poker Straight & nested loops & 4 & 40 & 57',
	'Friend Bits & bits & 5 & 100 & 81'
]);