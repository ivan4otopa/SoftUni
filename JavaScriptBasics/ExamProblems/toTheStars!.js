function toTheStars(input) {
	var star1 = input[0].split(' ');
	var star1Name = star1[0];
	var star1X = Number(star1[1]);
	var star1Y = Number(star1[2]);
	var star2 = input[1].split(' ');
	var star2Name = star2[0];
	var star2X = Number(star2[1]);
	var star2Y = Number(star2[2]);
	var star3 = input[2].split(' ');
	var star3Name = star3[0];
	var star3X = Number(star3[1]);
	var star3Y = Number(star3[2]);
	var normandy = input[3].split(' ');
	var normandyX = Number(normandy[0]);
	var normandyY = Number(normandy[1]);
	var moves = Number(input[4]);
	for(var i = normandyY; i <= moves + normandyY; i++) {
		if(isInStarArea(star1X, star1Y, normandyX, i))
			console.log(star1Name.toLowerCase());
		else if(isInStarArea(star2X, star2Y, normandyX, i))
			console.log(star2Name.toLowerCase());
		else if(isInStarArea(star3X, star3Y, normandyX, i))
			console.log(star3Name.toLowerCase());
		else
			console.log('space');
	}
	function isInStarArea(x, y, normandyX, normandyY) {
		if(normandyX >= x - 1 && normandyX <= x + 1 && normandyY >= y - 1 && normandyY <= y + 1)
			return true;
		return false;
	}
}

toTheStars(['Sirius 3 7',
'Alpha-Centauri 7 5',
'Gamma-Cygni 10 10',
'8 1',
'6'
]);

toTheStars(['Terra-Nova 16 2',
'Perseus 2.6 4.8',
'Virgo 1.6 7',
'2 5',
'4'
]);