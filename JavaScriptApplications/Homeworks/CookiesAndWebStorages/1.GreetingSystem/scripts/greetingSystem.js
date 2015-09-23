function greeting () {
	var user = JSON.parse(localStorage.getItem('user')) || {},
		greeting;

	if(!user.name) {
		user.name = prompt('Name:');
		localStorage.setItem('user', JSON.stringify(user));
	} else {
		greeting = document.getElementById('greetingMessage');
		greeting.innerHTML = 'Hi ' + user.name;
	}
}

function incrementSessionLoads() {
	var currentCount;

	if (!sessionStorage.counter) {
		sessionStorage.setItem('counter', 0);
	}

	currentCount = parseInt(sessionStorage.getItem('counter'));
	currentCount++;
	sessionStorage.setItem('counter', currentCount);
	document.getElementById('sessionCountDiv').innerHTML = currentCount;
}

function incrementLocalLoads () {
	var currentCount;

	if(!localStorage.counter) {
		localStorage.setItem('counter', 0);
	}

	currentCount = parseInt(localStorage.getItem('counter'));
	currentCount++;
	localStorage.setItem('counter', currentCount);
	document.getElementById('localCountDiv').innerHTML = currentCount;
}


incrementSessionLoads();
incrementLocalLoads();
greeting();