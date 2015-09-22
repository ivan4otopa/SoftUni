function printArgsInfo () {
	for(var i = 0; i < arguments.length; i++) {
		if(arguments[i] instanceof Array) {
			console.log(arguments[i] + ' (array)');
		} else {
			console.log(arguments[i] + ' (' + typeof(arguments[i]) + ')');
		}
	}
}

printArgsInfo.call();

console.log('------------------------------');

printArgsInfo.call(this, 2, 3, 2.5, -110.5564, false);

console.log('------------------------------');

printArgsInfo.apply();

console.log('------------------------------');

printArgsInfo.apply(this, [null, undefined, "", 0, [], {}]);