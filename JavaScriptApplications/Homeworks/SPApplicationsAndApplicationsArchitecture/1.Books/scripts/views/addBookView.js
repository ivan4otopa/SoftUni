var app = app || {};

app.addBookView = (function() {
    function render(selector, data) {
        $.get('templates/addBook.html', function (template) {
            var output = Mustache.render(template, data);
            $(selector).append(output);
        }).then(function () {
            $('#title').val('');
            $('#author').val('');
            $('#isbn').val('');
        });
    }

    return {
        render: function (selector, data) {
            render(selector, data);
        }
    };
}());