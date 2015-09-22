function treeHouseCompare(arr) {
	var a = arr[0];
	var b = arr[1];
	var houseArea = a * a + a * a * 2 / 6;
	var radius = (b / 3) * 2;
	var treeArea = b * (b / 3) + Math.PI * radius * radius;
	if(houseArea > treeArea)
		console.log('house/' + houseArea.toFixed(2));
	else
		console.log('tree/' + treeArea.toFixed(2));
}

treeHouseCompare([3, 2]);
treeHouseCompare([3, 3]);
treeHouseCompare([4, 5]);