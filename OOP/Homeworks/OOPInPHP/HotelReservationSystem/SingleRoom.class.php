<?php

class SingleRoom extends Room {
	const BED_COUNT = 1;
	const EXTRAS = 'TV, air-conditioner';
	
	function __construct($roomNumber, $price) {
		parent::__construct(RoomType::Standart, TRUE, FALSE, SingleRoom::BED_COUNT, $roomNumber, $extras = SingleRoom::EXTRAS, $price);
	}
}
