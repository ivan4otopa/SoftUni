var APPLICATION_ID = 'nvizCE3nQ435c9wc1luKQDHtpOd6mjkmQVD3JQvK';
var REST_API_KEY = 'ir82qwjW42UrCU6d3WUN7Ee4OshzqOzF6d4zVQzB';

function getCountries () {
	$.ajax({
		method: 'GET',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		url: 'https://api.parse.com/1/classes/Country',
		success: listCountries
	});
};

function listCountries (data) {
	var countries = $('<ul></ul>');
	countries.appendTo('body');

	for(var country in data.results) {
		$('<li></li>').text(data.results[country].name).appendTo(countries);
	}
}

getCountries();