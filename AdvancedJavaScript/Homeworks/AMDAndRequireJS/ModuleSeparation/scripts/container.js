define('listElement', function (listElement) {
	var Container = (function (parent) {
		function Container (title, sections) {
			parent.call(this, title);
			this.setSections(sections);
		};

		Container.extends(parent);

		Container.prototype.getSections = function() {
			return this._sections;
		};

		Container.prototype.setSections = function(sections) {
			this._sections = sections;
		};

		Container.prototype.addSection = function(section) {
			this._sections.push(section);
		};

		Container.prototype.addToDOM = function() {
			var wrapperDiv = document.getElementById('wrapper');
			var elementToAdd = document.createElement('DIV');
			elementToAdd.innerHTML =
				'<div id="container">' +
				'<h1>' + this.getTitle() + '</h1>' +
				'<div id="sectionContainer">' +
				'</div>' +
				'<input type="text"	id="newSectionField" plceholder="Title..." />' +
				'<button class="newSection" onclick="addNewSection()">New Section</a>' +
				'</div>';
			wrapperDiv.appendChild(elementToAdd);
		};

		return Container;
	}(listElement));

	return Container;
});