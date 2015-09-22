<?php

class BookingManager {
	public static function bookRoom($room, $reservation) {
		try {
			$room->addReservation($reservation);
			echo 'Room <strong>' . $room->getRoomNumber() . '</strong> succesfully booked for ' . $reservation;
		} catch(EReservationException $ex) {
			echo 'Room ' . $room->getRoomNumber . $ex->getMessage();
		}
	}
}
