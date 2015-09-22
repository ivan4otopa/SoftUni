function findMostFreqWord(str) {
    var words = str.toLowerCase().replace(/[,\.]/g, '').split(' ');
    var freq = {};
    var maxCount = 1;
    for(var i = 0; i < words.length; i++) {
    	words[i] = words[i].toLowerCase();
        if(!freq[words[i]])
            freq[words[i]] = 1;
        else
  			freq[words[i]] += 1;
    }
    for(key in freq) {
        if(freq[key] >= maxCount)
            maxCount = freq[key];
    }
    var sort = Object.keys(freq).sort();
    for(var sorted in sort) {
        if(freq[sort[sorted]] == maxCount)
            console.log(sort[sorted] + ' -> ' + freq[sort[sorted]] + ' times');
    }
}

findMostFreqWord('in the middle of the night');
findMostFreqWord('Welcome to SoftUni. Welcome to Java. Welcome everyone.');
findMostFreqWord('Hello my friend, hello my darling. Come on, come here. Welcome, welcome darling.');