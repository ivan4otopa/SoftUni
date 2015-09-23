var APPLICATION_ID = 'oQ8aDpqIgZlWv4i42BfByjQp0ABeKcm8LkDlcdbX';
var REST_API_KEY = '6K0s7FdX5ZQz8alsxn0xa53PF1Wuurl53NEbeBor';

function getBooks () {
	$.ajax({
		method: 'GET',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		url: 'https://api.parse.com/1/classes/Book',
		success: listBooks,
		error: error
	});
};

function listBooks (data) {
	var booksList = $('<ul></ul>');
		book = {};

	booksList.appendTo('body');

	for(book in data.results) {
		$('<li></li>')
			.text('Title: ' + data.results[book].title + ', author: ' + data.results[book].author +', isbn: ' +
				data.results[book].isbn)
			.appendTo(booksList);
	}
};

function error () {
	throw new Error('AJAX request failure.');
};

getBooks();