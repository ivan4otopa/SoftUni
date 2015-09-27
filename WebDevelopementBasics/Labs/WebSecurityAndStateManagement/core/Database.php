<?php
namespace Core;
use Core\Drivers\DriverFactory; 

class Database
{
	private static $inst = array();
	private $db = null;
	
	private function __construct($dbInstance) {
		$this->db = $dbInstance;
	}
	
	public static function getInstance($instanceName = 'default') {
		if (!isset(self::$inst[$instanceName])) {
			throw new \Exception('Instance with that name was not set');
		}
		
		return self::$inst[$instanceName];
	}
	
	public static function setInstance($instanceName, $driver, $user, $pass, $dbName, $host = null) {
		$driver = DriverFactory::create($driver, $user, $pass, $dbName, $host);
		
		$pdo = new \PDO($driver->getDsn(), $user, $pass); 
		
		self::$inst[$instanceName] = new self($pdo);
	}	
	
	public function prepare($statement, array $driverOptions = []) {
		$statement = $this->db->prepare($statement, $driverOptions);
		
		return new Statement($statement);
	}
	
	public function query($query) {
		$this->db->query($query);
	}
	
	public function lastId($name = null) {
		return $this->db->lastInsertId($name);
	}
}
?>
