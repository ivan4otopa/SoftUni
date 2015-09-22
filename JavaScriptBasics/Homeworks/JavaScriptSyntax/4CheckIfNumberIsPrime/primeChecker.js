function isPrime(number) {
	var count = 0;
	for(var i = 1; i <= number; i++) {
		if(number % i == 0)
			count++
	}
	if(count == 2)
		console.log(true);
	else
		console.log(false);
}

isPrime(7);
isPrime(254);
isPrime(587);