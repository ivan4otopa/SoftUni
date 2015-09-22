function countSubstringOccur(arr) {
	var count = 0;
	arr[1] = arr[1].toLowerCase();
	for(var i = 0; i < arr[1].length - arr[0].length; i++) {
		if(arr[1].substr(i, arr[0].length) == arr[0])
			count++;
	}
	console.log(count);
}

countSubstringOccur(['in', 'We are living in a yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.']);
countSubstringOccur(['your', 'No one heard a single word you said. They should have seen it in your eyes. What was going around your head.']);
countSubstringOccur(['but', 'But you were living in another world tryin\' to get your message through.']);