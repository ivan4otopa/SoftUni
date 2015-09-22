<?php

abstract class Room {
	private	$roomType;
	private $hasRestroom;
	private	$hasBalcony;
	private $bedCount;
	private	$roomNumber;
	private $extras;
	private	$price;
	private $reservations = array();
	
	function __construct($roomType, $hasRestroom, $hasBalcony, $bedCount, $roomNumber, $extras, $price) {
		$this->roomType = $roomType;
		$this->hasRestroom = $hasRestroom;
		$this->hasBalcony = $hasBalcony;
		$this->bedCount = $bedCount;
		$this->setRoomNumber($roomNumber);
		$this->extras = $extras;
		$this->setPrice($price);
	}
	
	public function getRoomType() {
		if ($this->roomType == 1) {
			return 'Standart';
		}
		
		if ($this->roomType == 2) {
			return 'Gold';
		}
		
		if ($this->roomType == 3) {
			return 'Diamond';
		}
	}
	
	public function getHasRestroom() {
		if ($this->hasRestroom) {
			return 'Yes';
		} else {
			return 'No';
		}
	}
	
	public function getHasBalcony() {
		if($this->hasBalcony) {
			return 'Yes';
		} else {
			return 'No';
		}
	}
	
	public function getBedCount() {
		return $this->bedCount;
	}
	
	public function getRoomNumber() {
		return $this->roomNumber;
	}
	
	public function setRoomNumber($value) {
		if ($value <= 0 || !is_numeric($value)) {
			trigger_error('Room Number must be a positive number.');
		}
		
		$this->roomNumber = $value;
	}
	
	public function getExtras() {
		return $this->extras;
	}
	
	public function getPrice() {
		return $this->price;
	}
	
	public function setPrice($value) {
		if ($value <= 0 || !is_numeric($value)) {
			trigger_error('Price must be a positive number.');
		}
		
		$this->price = $value;
	}

	public function getReservations() {
		return $this->reservations;
	}
	
	public function setReservations($value) {
		$this->reservations = $value;
	}
	
	public function addReservation(Reservation $reservation) {
		$startDate = $reservation->getStartDate();
		$endDate = $reservation->getEndDate();
		
		foreach ($this->reservations as $reserv) {
			if ($startDate >= $reserv->getStartDate && $startDate < $reserv->getEndDate && $endDate <= $reserv->getEndDate) {
				throw new EReservationExcepion;
			}
			
			$this->reservations[] = $reservation;
		}
	}
	
	public function removeReservation(Reservation $reservation)
	{
		foreach ($this->reservations as $key => $reserv) {
			if($reserv === $reservation) {
				unset($this->reservations[$key]);
			}
		}
	}
	
	public function __toString() {
		$result = 'Room Type: ' . $this->getRoomType() . '; Has Restroom: ' . $this->getHasRestroom() . '; Has Balcony: ' .
			$this->getHasBalcony() . '; Bed Count: ' . $this->getBedCount() . '; Room Number: ' .
			$this->getRoomNumber() . '; Extras: ' . $this->getExtras() . '; Price: ' . $this->getPrice() . '; Reservations:\n';
		foreach ($this->reservations as $reservation) {
			$result .= $reservation . "\n";
		}
		
		return $result;
	}
}
