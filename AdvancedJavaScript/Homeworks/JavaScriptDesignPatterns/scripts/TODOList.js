'use strict';

var TODOList = (function () {
	Function.prototype.extends = function(parent) {
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

	var Container = (function () {
		function Container (title, sections) {
			ListElement.call(this, title);
			this.setSections(sections);
		};

		Container.extends(ListElement);

		Container.prototype.getSections = function() {
			return this._sections;
		};

		Container.prototype.setSections = function(sections) {
			this._sections = sections;
		};

		Container.prototype.addSection = function(section) {
			this.getSections().push(section);
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
	}());

	var Section = (function () {
		function Section (title, items) {
			ListElement.call(this, title);
			this.setItems(items);
			sectionsCount++;
		}

		Section.extends(ListElement);

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
	}());

	var Item = (function () {
		function Item (title) {
			ListElement.call(this, title);
			itemsCount++;
		}

		Item.extends(ListElement);

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
	}());

	return {
		Container: Container,
		Section: Section,
		Item: Item
	}
}());