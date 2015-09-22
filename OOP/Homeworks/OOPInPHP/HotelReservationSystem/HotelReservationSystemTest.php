<?php

function __autoload($className) {
	require_once('./' . $className . '.class.php');
}

date_default_timezone_set("Europe/Sofia");

$room = new SingleRoom(1408, 99);
$guest = new Guest("Svetlin", "Nakov", 8003224277);
$startDate = strtotime("17.02.2015");
$endDate = strtotime("19.02.2015");
$reservation = new Reservation($startDate, $endDate, $guest);
BookingManager::bookRoom($room, $reservation);

$rooms = array(new SingleRoom(1205, 22.22), new SingleRoom(1312, 99.99), new Bedroom(1402, 159.39), new Bedroom(2503, 251.01),
	new Apartment(2602, 234.35), new Apartment(2604, 262.66));
	
$bedroomsAndApartments = array_filter($rooms, function ($room) {
	if(get_class($room) == 'Bedroom' || get_class($room) == 'Apartment') {
		return $room->getPrice() <= 250.00;
	}
});

foreach ($bedroomsAndApartments as $room) {
	echo room . "\n";
}

echo "\n";

$withBalcony = array_filter($rooms, function ($room) {
	return $room->getHasBalcony() == 'Yes';
});

foreach ($withBalcony as $room) {
	echo $room . "\n";
}

echo "\n";

$withBathtub = array_filter($rooms, function ($room) {
	return strpos($room->getExtras(), 'bathtub') !== false;
});

foreach ($withBathtub as $room) {
	echo $room->getRoomNumber() . "\n";
}
