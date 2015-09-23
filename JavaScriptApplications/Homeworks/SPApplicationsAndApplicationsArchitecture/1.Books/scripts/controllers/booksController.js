var app = app || {};

app.booksController = (function() {
    function BooksController(model) {
        this._model = model;
    }

    BooksController.prototype.loadBooks = function (selector) {
    	$(selector).empty();
        var _this = this;
        this._model.getBooks()
            .then(function (booksData) {
                var outputData = {
                    books: booksData.results
                };
                app.allBooksView.render(_this, selector, outputData);
            }, function (error) {
                console.log(error.responseText);
            });
    };

    BooksController.prototype.addBook = function (selector, title, author, isbn) {
        var book = {
            title: title,
            author: author,
            isbn: isbn
        };

        this._model.addBook(book)
            .then(function () {
                app.addBookView.render(selector, book);
            }, function (error) {
                console.log(error.responseText);
            });
    };

	BooksController.prototype.editBook = function (selector, title, author, isbn, objectId) {
		var _this = this;
		var newBookTitle = prompt('New book title:') || title;
		var newBookAuthor = prompt('New book author:') || author;
		var newBookIsbn = prompt('New book isbn:') || isbn;

	    var newBook = {
	    	title: newBookTitle,
	    	author: newBookAuthor,
	    	isbn: newBookIsbn
	    };

	    this._model.updateBook(objectId, newBook)
	    	.then(function () {
				_this.loadBooks(selector);
				$('.editBookWrapper').hide();
	    	});
	};

	BooksController.prototype.deleteBook = function(selector, objectId) {
	    var _this = this;

	    this._model.removeBook(objectId)
	    	.then(function () {
	    		_this.loadBooks(selector);
	    	});
	};

    return {
        load: function (model) {
            return new BooksController(model);
        }
    };
}());