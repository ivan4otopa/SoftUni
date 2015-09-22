function add (x) {
	var sum = x;
	function f(y) {
		sum += y;

		return f;
	}

	f.toString = function() {
		return sum;
	}

	return f;
}

console.log(add(1));

console.log('------------------------------');

console.log(add(2)(3));

console.log('------------------------------');

console.log(add(1)(1)(1)(1)(1));

console.log('------------------------------');

console.log(add(1)(0)(-1)(-1));

console.log('------------------------------');

var addTwo = add(2);
console.log(addTwo);

console.log('------------------------------');

console.log(addTwo(3));

console.log('------------------------------');

addTwo = add(2);
console.log(addTwo(3)(5));