<?php

class Bedroom extends Room {
	const BED_COUNT = 2;
	const EXTRAS = 'Tv, air-conditioner, refridgerator, mini-bar, bathtub';
	
	function __construct($roomNumber, $price) {
		parent::__construct(RoomType::Gold, TRUE, TRUE, Bedroom::BED_COUNT, $roomNumber, Bedroom::EXTRAS, $price);
	}
}
