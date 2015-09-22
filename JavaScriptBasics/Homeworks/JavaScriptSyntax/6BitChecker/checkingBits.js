function bitChecker(number) {
	var bit = number >> 3;
	if(bit & 1 == 1)
		console.log(true);
	else
		console.log(false);
}

bitChecker(333);
bitChecker(425);
bitChecker(2567564754);