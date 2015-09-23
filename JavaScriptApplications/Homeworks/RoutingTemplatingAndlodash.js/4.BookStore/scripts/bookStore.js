var books = [{"book":"The Grapes of Wrath","author":"John Steinbeck","price":"34.24","language":"French"},
{"book":"The Great Gatsby","author":"F. Scott Fitzgerald","price":"39,26","language":"English"},
{"book":"Nineteen Eighty-Four","author":"George Orwell","price":"15,39","language":"English"},
{"book":"Ulysses","author":"James Joyce","price":"23,26","language":"German"},
{"book":"Lolita","author":"Vladimir Nabokov","price":"14,19","language":"German"},
{"book":"Catch-22","author":"Joseph Heller","price":"47,89","language":"German"},
{"book":"The Catcher in the Rye","author":"J. D. Salinger","price":"25,16","language":"English"},
{"book":"Beloved","author":"Toni Morrison","price":"48,61","language":"French"},
{"book":"Of Mice and Men","author":"John Steinbeck","price":"29,81","language":"Bulgarian"},
{"book":"Animal Farm","author":"George Orwell","price":"38,42","language":"English"},
{"book":"Finnegans Wake","author":"James Joyce","price":"29,59","language":"English"},
{"book":"The Grapes of Wrath","author":"John Steinbeck","price":"42,94","language":"English"}],
	booksSortedByAuthorThenByPrice,
	groupedByLanguageSortedBooks,
	groupedByLanguageSortedBooksKeys,
	groupedByAuthorBooks,
	groupedByAuthorBooksKeys,
	englishBooks,
	groupedByAuthorEnglishBooks,
	groupedByAuthorEnglishBooksKeys;

booksSortedByAuthorThenByPrice = _(books).chain().sortBy(function (book) {
	return book.price;
}).sortBy(function (book) {
	return book.author;
}).value();
groupedByLanguageSortedBooks = _.groupBy(booksSortedByAuthorThenByPrice, 'language');
groupedByLanguageSortedBooksKeys = _.keys(groupedByLanguageSortedBooks);
console.log('Books sorted by author and then by price grouped by language:');

for(var i = 0; i < groupedByLanguageSortedBooksKeys.length; i++) {
	var language = groupedByLanguageSortedBooksKeys[i]
	console.log('Language: ' + language);

	for(var j = 0; j < groupedByLanguageSortedBooks[language].length; j++) {
		console.log('Book: ' + groupedByLanguageSortedBooks[language][j].book + ', author: ' +
			groupedByLanguageSortedBooks[language][j].author + ', price: ' + groupedByLanguageSortedBooks[language][j].price);
	}
}

groupedByAuthorBooks = _.groupBy(books, 'author');
groupedByAuthorBooksKeys = _.keys(groupedByAuthorBooks);
console.log('\nAverage books price for each author:');

for(var i = 0; i < groupedByAuthorBooksKeys.length; i++) {
	var author = groupedByAuthorBooksKeys[i];
	console.log('Author: ' + author);
	console.log('Average books price: ' + averageBookPriceByAuthor(groupedByAuthorBooks[author]));
}

englishBooks = _.filter(books, function (book) {
	return book.language === 'English' && Number(book.price.replace(',', '.')) < 30.00;
});

groupedByAuthorEnglishBooks = _.groupBy(englishBooks, 'author');
groupedByAuthorEnglishBooksKeys = _.keys(groupedByAuthorEnglishBooks);
console.log('\nEnglish books grouped by author:');

for(var i = 0; i < groupedByAuthorEnglishBooksKeys.length; i++) {
	var author = groupedByAuthorEnglishBooksKeys[i];
	console.log('Author: ' + author);

	for(var j = 0; j < groupedByAuthorEnglishBooks[author].length; j++) {
		console.log('Book: ' + groupedByAuthorEnglishBooks[author][j].book + ', price: ' + groupedByAuthorEnglishBooks[author][j].price);
	}
}

function averageBookPriceByAuthor (author) {
	var totalBooksPrice = 0;

	for(var i = 0; i < author.length; i++) {
		totalBooksPrice += Number(author[i].price.replace(',', '.'))
	}

	return totalBooksPrice;
}