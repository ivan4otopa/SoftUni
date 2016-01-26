import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class LegendaryFarming {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		HashMap<String, Integer> keyMaterials = new HashMap<>();
		
		keyMaterials.put("shards", 0);
		keyMaterials.put("fragments", 0);
		keyMaterials.put("motes", 0);
		
		Map<String, Integer> junk = new TreeMap<>();
		String line = inputReader.nextLine();
		String legendaryItem = "";
		
		boolean legendaryItemObtained = false;
		
		while (!line.isEmpty()) {
			String[] parts = line.split(" ");
			
			for (int i = 0; i < parts.length; i += 2) {
				String material = parts[i + 1].toLowerCase();
				
				int quantity = Integer.parseInt(parts[i]);
				
				if (material.equals("shards") || material.equals("fragments") || material.equals("motes")) {
					if (keyMaterials.get(material) + quantity >= 250) {
						keyMaterials.put(material, keyMaterials.get(material) + quantity);
						
						if (material.equals("shards")) {
							legendaryItem = "Shadowmourne";
						} else if (material.equals("fragments")) {
							legendaryItem = "Valanyr";
						} else {
							legendaryItem = "Dragonwrath";
						}
						
						legendaryItemObtained = true;					
						keyMaterials.put(material, keyMaterials.get(material) - 250);
						
						break;
					} else {
						keyMaterials.put(material, keyMaterials.get(material) + quantity);
					}									
				} else {
					if (!junk.containsKey(material)) {
						junk.put(material, 0);
					}
					
					junk.put(material, junk.get(material) + quantity);
				}
			}
			
			if (legendaryItemObtained) {
				break;
			}
			
			line = inputReader.nextLine();
		}			
		
		System.out.printf("%s obtained!\n", legendaryItem);
		
		TreeMap<String, Integer> sortedKeyMaterials = sortByValue(keyMaterials);
		
		for (java.util.Map.Entry<String, Integer> keyMaterial : sortedKeyMaterials.entrySet()) {
			String material = keyMaterial.getKey();
			
			int quantity = keyMaterial.getValue();
			
			System.out.printf("%s: %d\n", material, quantity);
		}
		
		for (java.util.Map.Entry<String, Integer> junkMaterial : junk.entrySet()) {
			String material = junkMaterial.getKey();
			
			int quantity = junkMaterial.getValue();
			
			System.out.printf("%s: %d\n", material, quantity);
		}
	}
	
	public static TreeMap<String, Integer> sortByValue 
		(HashMap<String, Integer> map) {
		ValueComparator vc =  new ValueComparator(map);
		TreeMap<String,Integer> sortedMap = new TreeMap<String,Integer>(vc);
		sortedMap.putAll(map);
		return sortedMap;
	}
}

class ValueComparator implements Comparator<String> {
	 
    Map<String, Integer> map;
 
    public ValueComparator(Map<String, Integer> base) {
        this.map = base;
    }
 
    public int compare(String a, String b) {
        if (map.get(a) >= map.get(b)) {
            return -1;
        } else {
            return 1;
        } 
    }
}