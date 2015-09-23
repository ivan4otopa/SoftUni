var app = app || {};

(function () {
	app.router = Sammy(function () {
		this.get('#/Sam', function () {
			$('h2').text('Hello, Sam');
		});

		this.get('#/Bob', function () {
			$('h2').text('Hello, Bob');
		});
	});

	app.router.run('#/');
}());