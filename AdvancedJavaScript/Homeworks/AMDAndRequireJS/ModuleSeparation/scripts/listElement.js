define(function () {
	Function.prototype.extends = function (parent) {
		this.prototype = Object.create(parent.prototype);
		this.prototype.constructor = this;
	};

	var ListElement = (function () {
		function ListElement (title) {
			this.setTitle(title);
		};

		ListElement.prototype.getTitle = function() {
			return this._title;
		};

		ListElement.prototype.setTitle = function(title) {
			this._title = title;
		};

		return ListElement;
	}());

	return listElement;
});