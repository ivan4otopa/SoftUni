function logsAggregator(input) {
	var n = Number(input[0]);
	var aggregator = {};
	for(var i = 1; i <= n; i++) {
		var log = input[i].split(' ');
		var ip = log[0];
		var name = log[1];
		var duration = Number(log[2]);
		if(!aggregator[name])
			aggregator[name] = { 'minutes': 0, 'ips': [] };
		aggregator[name].minutes += duration;
		if(aggregator[name].ips.indexOf(ip) == -1)
			aggregator[name].ips.push(ip);
	}
	var sortedKeys = Object.keys(aggregator).sort();
	var sortedObject = {};
	for(var i = 0; i < sortedKeys.length; i++)
		sortedObject[sortedKeys[i]] = aggregator[sortedKeys[i]];
	for(var name in sortedObject) {
		sortedObject[name].ips.sort();
		console.log(name + ': ' + sortedObject[name].minutes + ' [' + sortedObject[name].ips.join(', ') + ']');
	}
}

logsAggregator(['7',
'192.168.0.11 peter 33',
'10.10.17.33 alex 12',
'10.10.17.35 peter 30',
'10.10.17.34 peter 120',
'10.10.17.34 peter 120',
'212.50.118.81 alex 46',
'212.50.118.81 alex 4'
]);

logsAggregator(['2',
'84.238.140.178 nakov 25',
'84.238.140.178 nakov 35'
]);