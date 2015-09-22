// Defined function in the global scope can be called anywhere
function testContext () {
	console.log(this);
}

testContext();

console.log('------------------------------');

// Defined function in another function scope can be called only there
function anotherFunction () {
	testContext();
}

anotherFunction();

console.log('------------------------------');

// Creating a new instance of the function creates new object, because functions are objects
var t = new testContext();
console.log(t);