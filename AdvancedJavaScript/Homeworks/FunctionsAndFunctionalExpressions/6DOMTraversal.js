function traverse (selector) {
	var element = document.querySelector(selector);
	traverseSelector(element, '');
	function traverseSelector (element, spacing) {
		spacing = spacing || ' ';
		var currentSelector = spacing + element.nodeName.toLowerCase() + ':';

		if(element.hasAttribute('id')) {
			currentSelector += ' id="' + element.id + '"';
		}

		if(element.hasAttribute('class')) {
			currentSelector += ' class="' + element.className + '"';
		}

		console.log(currentSelector);

		for(var i = 0; i < element.childNodes.length; i++) {
			var child = element.childNodes[i];
			if(child.nodeType === document.ELEMENT_NODE) {
				traverseSelector(child, spacing + '    ');
			}
		}
	}
}

var selector = ".birds";
traverse(selector);