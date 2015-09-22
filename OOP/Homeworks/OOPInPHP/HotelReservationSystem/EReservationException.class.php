<?php

class EEeservationException extends Exception {
	function __construct() {
		parent::__construct("Room already reserved.");
	}
}
