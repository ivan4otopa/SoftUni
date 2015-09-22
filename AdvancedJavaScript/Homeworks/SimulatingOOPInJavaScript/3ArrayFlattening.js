Array.prototype.flatten = function() {
	var flattenedArray = [];

	function flattenArray (array) {
		for(var element = 0; element < array.length; element++) {
			if(array[element] instanceof Array) {
				flattenArray(array[element]);
			} else {
				flattenedArray.push(array[element]);
			}
		}
	}

	flattenArray(this);
	return flattenedArray;
};

var array = [1, 2, 3, 4];
console.log(array.flatten());

console.log('---------------------');

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array); // Not changed

console.log('---------------------');

var array = [0, ["string", "values"], 5.5, [[1, 2, true], [3, 4, false]], 10];
console.log(array.flatten());
