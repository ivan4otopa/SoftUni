var domModule = (function () {
	function appendChild (element, child) {
		var elements = retrieveElements(child);

		for(var i = 0; i < elements.length; i++) {
			element.appendChild(elements[i]);
		}
	}

	function removeChild (element, child) {
		var elements = retrieveElements(element);
		var children = retrieveElements(child);

		for(var i = 0; i < elements.length; i++) {
			elements[i].removeChild(children[0]);
		}
	}

	function addHandler (element, eventType, eventHandler) {
		var elements = retrieveElements(element);

		for(var i = 0; i < elements.length; i++) {
			elements[i].addEventListener(eventType, eventHandler);
		}
	}

	function retrieveElements (selector) {
		var elements = [];
		var selectors = document.querySelectorAll(selector);

		for(var i = 0; i < selectors.length; i++) {
			elements[i] = selectors[i];
		}

		return elements;
	}

	var newModule = {
		appendChild: appendChild,
		removeChild: removeChild,
		addHandler: addHandler,
		retrieveElements: retrieveElements
	}

	return newModule;
}());

var liElement = document.createElement("li");
// Appends a list item to ul.birds-list
domModule.appendChild(liElement,".birds-list"); 
// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list","li:first-child"); 
// Adds a click event to all bird list items
domModule.addHandler("li.birds", 'click', function(){ alert("I'm a bird!") });
// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
