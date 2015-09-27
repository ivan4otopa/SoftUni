<?php
namespace Core;

class BuildingsRepository
{
	private $db;
	private $user;
	
	public function __construct(Database $db, User $user) {
		$this->db = $db;
		$this->user = $user;
	}
	
	public function getUser(){
        return $this->user;
    }
	
	public function getBuildings() {
		$result = $this->db->prepare('SELECT
		  id,
		  building_id,
		  (level_id + 1) as level,
		  (SELECT gold FROM buildings_levels_cost WHERE level = users_buildings.level_id + 1 AND building_id = users_buildings.building_id) as gold,
		  (SELECT food FROM buildings_levels_cost WHERE level = users_buildings.level_id + 1 AND building_id = users_buildings.building_id) as food,
		  (SELECT name FROM buildings WHERE id = users_buildings.building_id) as name
		FROM users_buildings
		WHERE user_id = ?');
		$result->execute([$this->user->getId()]);
		
		return $result->fetchAll();
	}	
	
	public function evolve($buildingId) {
		$result = $this->db->prepare('SELECT
		  id,
		  building_id,
		  (level_id + 1) as level,
		  (SELECT gold FROM buildings_levels_cost WHERE level = users_buildings.level_id + 1 AND building_id = users_buildings.building_id) as gold,
		  (SELECT food FROM buildings_levels_cost WHERE level = users_buildings.level_id + 1 AND building_id = users_buildings.building_id) as food,
		  (SELECT name FROM buildings WHERE id = users_buildings.building_id) as name
		FROM users_buildings
		WHERE user_id = ? AND building_id = ?');
		
		$result->execute([$this->user->getId(), $buildingId]);
		$buildingData = $result->fetch();
		
		if ($this->user->getGold() < $buildingData['gold'] || $this->user->getFood() < $buildingData['food']) {
			throw new \Exception('Not enough resources');
		}

		if ($buildingData['gold'] == null) {
			throw new \Exception('Max level reached');
		}
		
		$resourceUpdate = $this->db->prepare('UPDATE users SET gold = ?, food = ? WHERE id = ?');
		$resourceUpdate->execute([$this->user->getGold() - $buildingData['gold'], $this->user->getFood() - $buildingData['food'], $this->user->getId()]);
		
		if ($resourceUpdate->rowCount() > 0) {
			$levelUpdate = $this->db->prepare('UPDATE users_buildings SET level_id = ? WHERE user_id = ? AND building_id = ?');
			$levelUpdate->execute([$buildingData['level'], $this->user->getId(), $buildingId]);
			
			if ($levelUpdate->rowCount() > 0) {
				return true;
			}
			
			throw new \Exception('Failed to update');
		}

		throw new \Exception('Failed to update');
	}
}
?>