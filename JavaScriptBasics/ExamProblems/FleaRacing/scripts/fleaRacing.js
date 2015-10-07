function fleaRacing (input) {
	var allowedNumberOfJumps = Number(input[0]),
		trackLength = Number(input[1]),
		numberOfParticipants = input.length - 2,
		racingTrack = [],
		name = '',
		jumpDistance = 0,
		letter = '';

	console.log(Array(trackLength + 1).join('#'));
	console.log(Array(trackLength + 1).join('#'));

	for(var i = 0; i < numberOfParticipants; i++) {
		racingTrack[i] = [];

		for(var j = 0; j < trackLength; j++) {
			racingTrack[i][j] = '.';
		}

		racingTrack[i][0] = input[i + 2].charAt(0).toUpperCase();
	}

	for(var i = 0; i < numberOfParticipants; i++) {
		jumpDistance = Number(input[i + 2].split(', ')[1]);
		letter = racingTrack[i][0];

		for(var j = 0; j < 2; j++) {
			racingTrack[i][j] = '.';
			racingTrack[i][j + jumpDistance] = letter;
		}
	}

	for(var i = 0; i < numberOfParticipants; i++) {
		console.log(racingTrack[i].join(''));
	}

	console.log(Array(trackLength + 1).join('#'));
	console.log(Array(trackLength + 1).join('#'));
}

fleaRacing([10, 19, 'angel, 9', 'Boris, 10', 'Georgi, 3', 'Dimitar, 7']);

fleaRacing([3, 5, 'cura, 1', 'Pepi, 1', 'UlTraFlea, 1', 'BOIKO, 1']);