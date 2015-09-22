<?php

class Guest {
	private $firstName;
	private $lastName;
	private $id;
	
	function __construct($firstName, $lastName, $id) {
		$this->setFirstName($firstName);
		$this->setLastName($lastName);
		$this->setId($id);
	}
	
	public function getFirstName() {
		return $this->firstName;
	}
	
	public function setFirstName($value)
	{
		if(is_null($value)) {
			trigger_error('First Name cannot be null');
		}
		
		$this->firstName = $value;
	}
	
	public function getLastName() {
		return $this->lastName;
	}
	
	public function setLastName($value)
	{
		if(is_null($value)) {
			trigger_error('Last Name cannot be null');
		}
		
		$this->lastName = $value;
	}
	
	public function getId() {
		return $this->id;
	}
	
	public function setId($value)
	{
		if(!is_numeric($value) || $value <= 0 || strlen($value) != 10) {
			trigger_error('Id must be a positive number consisting of 10 digits.');
		}
		
		$this->id = $value;
	}
	
	public function __toString() {
		return '<strong>' . $this->getFirstName() . ' ' . $this->getLastName() . '</strong>';
	}
}
