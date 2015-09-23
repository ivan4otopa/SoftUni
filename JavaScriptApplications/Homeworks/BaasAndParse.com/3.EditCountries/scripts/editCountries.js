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
	var countries = $('<ul></ul>'),
		addCountryInput = $('<input type="text" placeholder="Add Country..." />'),
		addCountryButton = $('<button></button>').text('AddCountry'),
		editCountryButton,
		deleteCountryButton;

	$('body').empty();
	countries.appendTo('body');

	for(var country in data.results) {
		editCountryButton = $('<button></button>').text('Edit Country');
		deleteCountryButton = $('<button></button>').text('Delete Country');
		$('<li></li>').text(data.results[country].name)
			.append(' ')
			.append(editCountryButton.data('country', data.results[country]).click(editCountry))
			.append(' ')
			.append(deleteCountryButton.data('country', data.results[country]).click(deleteCountry))
			.appendTo(countries);
	}

	addCountryInput.appendTo('body');
	addCountryButton.appendTo('body').click(addCountry);
};

function addCountry () {
	var countryName = $('input').val();

	$.ajax({
		method: 'POST',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		data: JSON.stringify({
			'name': countryName
		}),
		url: 'https://api.parse.com/1/classes/Country',
		success: getCountries
	});
};

function editCountry () {
	var country = $(this).data('country');
		countryNewName = prompt('New country name:');

	$.ajax({
		method: 'PUT',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		data: JSON.stringify({
			'name': countryNewName
		}),
		url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
		success: getCountries
	});
};

function deleteCountry () {
	var country = $(this).data('country');

	$.ajax({
		method: 'DELETE',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		url: 'https://api.parse.com/1/classes/Country/' + country.objectId,
		success: getCountries
	})
}

getCountries();