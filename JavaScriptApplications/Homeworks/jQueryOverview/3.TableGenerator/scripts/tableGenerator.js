var submitButton = $('button');

submitButton.on('click', function () {
	var input = $('input').val();
	var parsedInput = JSON.parse(input);
	generateTable(parsedInput);
});

function generateTable (objectsArray) {
	var manufacturers = [],
		models = [],
		years = [],
		prices = [],
		classes = [],
		numberOfObjects = objectsArray.length,
		numberOfCarElements;

	for(var i = 0; i < numberOfObjects; i++) {
		manufacturers[i] = objectsArray[i].manufacturer;
		models[i] = objectsArray[i].model;
		years[i] = objectsArray[i].year;
		prices[i] = objectsArray[i].price;
		classes[i] = objectsArray[i].class;
	}

	var carElements = [manufacturers, models, years, prices, classes];

    $('<table></table>').appendTo('body');
    $('<thead></thead>').appendTo('table');
    $('<tr></tr>').appendTo('thead');
    $('<th></th>').text('Manufacturer').appendTo('tr');
    $('<th></th>').text('Model').appendTo('tr');
    $('<th></th>').text('Year').appendTo('tr');
    $('<th></th>').text('Price').appendTo('tr');
    $('<th></th>').text('Class').appendTo('tr');
    $('<tbody></tbody>').appendTo('table');

    numberOfCarElements = carElements.length;

    for(var i = 0; i < numberOfObjects; i++) {
    	$('<tr></tr>').attr("id", 'tr' + i).appendTo('tbody');
	    $('<td></td>').text(manufacturers[i]).appendTo('#tr' + i);
	    $('<td></td>').text(models[i]).appendTo('#tr' + i);
	    $('<td></td>').text(years[i]).appendTo('#tr' + i);
	    $('<td></td>').text(prices[i]).appendTo('#tr' + i);
	    $('<td></td>').text(classes[i]).appendTo('#tr' + i)
    }
}