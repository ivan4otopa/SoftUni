define('listElement', function (listElement) {
	var Item = (function (parent) {
		function Item (title) {
			parent.call(this, title);
			itemsCount++;
		}

		Item.extends(parent);

		var itemsCount = 0;

		Item.prototype.addToDOM = function(target) {
			var targ = document.getElementById(target);
			var elementToAdd = document.createElement('DIV');
			elementToAdd.innerHTML =
				'<div class="contentBox">' +
				'<input onclick="changeStatus(content' + itemsCount + ')" type="checkbox" />' +
				'<div class="content" id="content' + itemsCount + '">' + this.getTitle() + '</div>' +
				'</div>';
			targ.appendChild(elementToAdd);
		};

		return Item;
	}(listElement));

	return Item;
});