function solve(input) {
	var numbers = [];
	numbers = input.match(/[0-9]+/g);
	var count = 0;
	var maxCount = 0;
	for(var i = 0; i < numbers.length; i++) {
		if(numbers[i] % 2 == 0 || numbers[i] == 0) {
			for(var j = i + 1; j < numbers.length; j += 2) {
				if((numbers[j] % 2 != 0 || numbers[j] == 0) && (numbers[j + 1] % 2 == 0 || numbers[j + 1] == 0))
					count++;
			}
		}
	}
	console.log(maxCount);
}

solve('(3) (22) (-18) (55) (44) (3) (21)');
solve('(1)(2)(3)(4)(5)(6)(7)(8)(9)(10)');
solve('  ( 2 )  ( 33 ) (1) (4)   (  -1  )');
solve('(102)(103)(0)(105)  (107)(1)');
solve('(2) (2) (2) (2) (2)');