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
	var booksList = $('<ul></ul>'),
		book = {};

	$('body').empty();
	booksList.appendTo('body');

	for(book in data.results) {
		$('<li></li>')
			.text('Title: ' + data.results[book].title + ', author: ' + data.results[book].author +', isbn: ' +
				data.results[book].isbn)
			.append(' ')
			.append($('<button></button>').text('Delete book').data('book', data.results[book]).click(deleteBook))
			.appendTo(booksList);
	}
};

function deleteBook () {
	var book = $(this).data('book');

	$.ajax({
		method: 'DELETE',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		url: 'https://api.parse.com/1/classes/Book/' + book.objectId,
		success: getBooks,
		error: error
	})
}

function error () {
	throw new Error('AJAX request failure.');
};

getBooks();