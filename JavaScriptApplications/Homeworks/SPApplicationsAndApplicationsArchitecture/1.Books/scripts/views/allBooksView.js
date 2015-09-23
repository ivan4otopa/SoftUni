var app = app || {};

app.allBooksView = (function() {
    function render(controller, selector, data) {
        $.get('templates/allBooks.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).html(output);
        }).then(function () {
        	$('li').click(function () {
				var liIndex = $('li').index(this);
					book = data.books[liIndex];
					bookTitle = book.title;
					bookAuthor = book.author;
					bookIsbn = book.isbn;
					bookObjectId = book.objectId;

				$('<div class="editBookWrapper">')
					.append($('<label>').text('Edit Book'))
					.append($('<label class="editBookLabel">').text('Title: ' + bookTitle))
					.append($('<label class="editBookLabel">').text('Author: ' + bookAuthor))
					.append($('<label class="editBookLabel">').text('Isbn: ' + bookIsbn))
					.append($('<button id="editBook">').text('Edit Book').click(function () {
						controller.editBook('#app', bookTitle, bookAuthor, bookIsbn, bookObjectId);
					}))
					.appendTo('body');
        	});
        }).then(function () {
        	$('.deleteBook').click(function () {
        		var buttonIndex = $('.deleteBook').index(this);
        			book = data.books[buttonIndex];
					bookObjectId = book.objectId;
				controller.deleteBook('#app', bookObjectId);
        	});
        }).then(function () {
                $('#addBook').click(function () {
                    var bookTitle = $('#title').val();
                    	bookAuthor = $('#author').val();
                    	bookIsbn = $('#isbn').val();

                    controller.addBook('#books', bookTitle, bookAuthor, bookIsbn);
                });
           });
    }

    return {
        render: function (controller, selector, data) {
            render(controller, selector, data);
        }
    };
}());