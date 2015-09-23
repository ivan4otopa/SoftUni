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
		book = {},
		addBookForm = $('<form></form>')
			.append($('<label></label></br>').text('Add Book'))
			.append($('<label></label>').text('Title:'))
			.append($('<input type="text" id="bookTitle" placeholder="Book title..." />'))
			.append($('<label></label>').text('Author:'))
			.append($('<input type="text" id="bookAuthor" placeholder="Book author..." />'))
			.append($('<label></label>').text('Isbn:'))
			.append($('<input type="text" id="bookIsbn" placeholder="Book isdn..." />'))
			.append($('<button></button>').text('Add Book').click(addBook))

	$('body').empty();
	booksList.appendTo('body');

	for(book in data.results) {
		$('<li></li>')
			.text('Title: ' + data.results[book].title + ', author: ' + data.results[book].author +', isbn: ' +
				data.results[book].isbn)
			.appendTo(booksList);
	}

	addBookForm.appendTo('body');
};

function addBook () {
	var bookTitle = $('#bookTitle').val(),
		bookAuthor = $('#bookAuthor').val(),
		bookIsbn = $('#bookIsbn').val();

	$.ajax({
		method: 'POST',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		data: JSON.stringify({
			'title': bookTitle,
			'author': bookAuthor,
			'isbn': bookIsbn
		}),
		url: 'https://api.parse.com/1/classes/Book',
		success: getBooks,
		error: error
	});
};

function error () {
	throw new Error('AJAX request failure.');
};

getBooks();