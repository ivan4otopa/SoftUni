String.prototype.startsWith = function(substring) {
	var result = this.indexOf(substring) == 0;

	return result;
};

String.prototype.endsWith = function(substring) {
	var result = this.indexOf(substring, this.length - substring.length) !== -1;

	return result
};

String.prototype.left = function(count) {
	var result = this.substring(0, count);

	return result;
};

String.prototype.right = function(count) {
	var result = this.substring(this.length - count);

	return result;
};

String.prototype.padLeft = function(count, character) {
	if(!character) {
		character = ' ';
	}

	var repeatedCharacter = character.repeat(count);
	var result = repeatedCharacter + this;

	return result;
};

String.prototype.padRight = function(count, character) {
	if(!character) {
		character = ' ';
	}

	var repeatedCharacter = character.repeat(count);
	var result = this + repeatedCharacter;

	return result;
};

String.prototype.repeat = function(count) {
	var result = '';

	for(var i = 0; i < count; i++) {
		result += this;
	}

	return result;
};

var example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));

console.log('---------------');

var example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith ("example"));
console.log(example.startsWith("something else"));

console.log('---------------');

var example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));

console.log('---------------');

var example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));

console.log('---------------');

// Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));

console.log('---------------');

var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));

console.log('---------------');

var hello = "hello";
console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

console.log('---------------');

var character = "*";
console.log(character.repeat(5));
// Alternative syntax
console.log("~".repeat(3));

console.log('---------------');

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
