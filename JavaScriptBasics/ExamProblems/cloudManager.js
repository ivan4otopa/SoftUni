function cloudManager(input) {
	var results = {};
	for(var i = 0; i < input.length; i++) {
		var matches = input[i].split(' ');
		var file = matches[0];
		var extension = matches[1];
		var memory = Number(matches[2].replace('MB', ''));
		if(!results[extension])
			results[extension] = { 'files': [], 'memory': 0};
		if(results[extension].files.indexOf(file) == -1)
			results[extension].files.push(file);
		results[extension].memory += memory;
	}
	var sortedObject = {};
	var sortedKeys = Object.keys(results).sort();
	for(var i = 0; i < sortedKeys.length; i++)
		sortedObject[sortedKeys[i]] = results[sortedKeys[i]];
	for(extension in sortedObject) {
		sortedObject[extension].files.sort();
		sortedObject[extension].memory = sortedObject[extension].memory.toFixed(2);
	}
	console.log(JSON.stringify(sortedObject));
}

cloudManager(['sentinel .exe 15MB',
'zoomIt .msi 3MB',
'skype .exe 45MB',
'trojanStopper .bat 23MB',
'kindleInstaller .exe 120MB',
'setup .msi 33.4MB',
'winBlock .bat 1MB'
]);

cloudManager(['eclipse .tar.gz 198.00MB',
'uTorrent .gyp 33.02MB',
'nodeJS .gyp 14MB',
'nakov-naked .jpeg 3MB',
'gnuGPL .pdf 5.6MB',
'skype .tar.gz 66MB',
'selfie .jpeg 7.24MB',
'myFiles .tar.gz 783MB'
]);