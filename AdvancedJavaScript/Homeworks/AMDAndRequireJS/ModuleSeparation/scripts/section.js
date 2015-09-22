define('listElement', function (listElement) {
	var Section = (function (parent) {
		function Section (title, items) {
			parent.call(this, title);
			this.setItems(items);
			sectionsCount++;
		}

		Section.extends(parent);

		var sectionsCount = 0;

		Section.prototype.getItems = function() {
			return this._items;
		};

		Section.prototype.setItems = function(items) {
			this._items = items;
		};

		Section.prototype.addItem = function(item) {
			this.getItems().push(item);
		};

		Section.prototype.addToDOM = function() {
			var sectionContainer = document.getElementById('sectionContainer');
			var elementToAdd = document.createElement('DIV');
			elementToAdd.innerHTML =
				'<section class="clearfix" id="section' + sectionsCount + '">' +
				'<h2>' + this.getTitle() + '</h2>' +
				'</section>' +
				'<div class="additem clearfix">' +
				'<input type="text" id="newItemField' + sectionsCount +'" placeholder="Add item..." />' +
                '<button href="#" class="addNewItem" onclick="addNewItem(\'section' + sectionsCount +'\', \'newItemField' + sectionsCount +
                	'\')">+</button>' +
				'</div>';
			sectionContainer.appendChild(elementToAdd);
		};

		return Section;
	}(listElement));

	return Section;
});