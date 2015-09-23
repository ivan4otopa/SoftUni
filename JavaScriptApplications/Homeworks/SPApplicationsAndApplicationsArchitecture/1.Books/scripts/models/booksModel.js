var app = app || {};

app.bookDataModel = (function() {
    function BookDataModel(baseUrl, requester, headers) {
        this._requester = requester;
        this._headers = headers;
        this._serviceUrl = baseUrl + 'classes/Book';
    }

    BookDataModel.prototype.getBooks = function () {
        var headers = this._headers.getHeaders();

        return this._requester.get(this._serviceUrl, headers);
    };

    BookDataModel.prototype.addBook = function (book) {
        var headers = this._headers.getHeaders();

        return this._requester.post(this._serviceUrl, headers, book);
    };

    BookDataModel.prototype.updateBook = function (objectId, book) {
        var headers = this._headers.getHeaders();

        return this._requester.put(this._serviceUrl + '/' + objectId, headers, book);
    };

    BookDataModel.prototype.removeBook = function(objectId) {
        var headers = this._headers.getHeaders();

        return this._requester.delete(this._serviceUrl + '/' + objectId, headers);
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new BookDataModel(baseUrl, requester, headers);
        }
    };
}());