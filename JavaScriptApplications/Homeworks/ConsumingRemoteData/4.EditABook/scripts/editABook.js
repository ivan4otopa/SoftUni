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
			.data('book', data.results[book])
			.click(showDataInHTMLForm)
			.appendTo(booksList);
	}
};

function showDataInHTMLForm () {
	var book = $(this).data('book');

	$('<form></form>')
		.append($('<label></label>').text('Title: ' + book.title))
		.append($('<label></label>').text('Author: ' + book.author))
		.append($('<label></label>').text('Isbn: ' + book.isbn))
		.append($('<button></button>').text('Edit book').click(function () {
			editBook(book);
			return false;
		}))
		.appendTo('body');
};

function editBook (book) {
	var oldBookTitle = book.title;
		newBookTitle = prompt('New book title:') || oldBookTitle,
		oldBookAuthor = book.author;
		newBookAuthor = prompt('New book author:') || oldBookAuthor,
		oldBookIsbn = book.isbn;
		newBookIsbn = prompt('New book isbn:') || oldBookIsbn;

	$.ajax({
		method: 'PUT',
		headers: {
			'X-Parse-Application-Id': APPLICATION_ID,
			'X-Parse-REST-API-Key': REST_API_KEY
		},
		data: JSON.stringify({
			'title': newBookTitle,
			'author': newBookAuthor,
			'isbn': newBookIsbn
		}),
		url: 'https://api.parse.com/1/classes/Book/' + book.objectId,
		success: getBooks,
		error: error
	});
};

function error () {
	throw new Error('AJAX request failure.');
};

getBooks();