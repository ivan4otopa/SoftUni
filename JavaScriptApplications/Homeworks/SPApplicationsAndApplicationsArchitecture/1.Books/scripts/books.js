var app = app || {};

(function() {
    var appId = 'oQ8aDpqIgZlWv4i42BfByjQp0ABeKcm8LkDlcdbX';
    var restAPIKey = '6K0s7FdX5ZQz8alsxn0xa53PF1Wuurl53NEbeBor';

    var headers = app.headers.load(appId, restAPIKey);
    var requester = app.requester.load();
    var model = app.bookDataModel.load('https://api.parse.com/1/', requester, headers);
    var controller = app.booksController.load(model);

    app.router = Sammy(function () {
        var selector = '#app';

        this.get('#/books', function () {
            controller.loadBooks(selector);
        });
    });

    app.router.run('#/books');
}());