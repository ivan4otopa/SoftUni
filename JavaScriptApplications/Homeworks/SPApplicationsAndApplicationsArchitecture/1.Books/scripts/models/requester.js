var app = app || {};

app.requester = (function() {
    function Requester() {
    };

    Requester.prototype.get = function (url, headers) {
        return makeRequest('GET', headers, url);
    };

    Requester.prototype.post = function (url, headers, data) {
        return makeRequest('POST', headers, url, data);
    };

    Requester.prototype.put = function (url, headers, data) {
        return makeRequest('PUT', headers, url, data);
    };

    Requester.prototype.delete = function(url, headers) {
        return makeRequest('DELETE', headers, url);
    };

    function makeRequest(method, headers, url, data) {
        var deferred = Q.defer();

        $.ajax({
            method: method,
            headers: headers,
            url: url,
            data: JSON.stringify(data),
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (error) {
                deferred.reject(error);
            }
        });

        return deferred.promise;
    }

    return {
        load: function () {
            return new Requester();
        }
    };
}());