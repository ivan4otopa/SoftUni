import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class Weightlifting {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		Map<String, TreeMap<String, Long>> players = new TreeMap<>();
		
		int numberOfLines = Integer.parseInt(inputReader.nextLine());
		
		for (int i = 0; i < numberOfLines; i++) {
			String[] parts = inputReader.nextLine().split(" ");
			String player = parts[0];
			String exercise = parts[1];
			
			long weight = Integer.parseInt(parts[2]);
			
			if (!players.containsKey(player)) {
				players.put(player, new TreeMap<>());
				players.get(player).put(exercise, weight);
			} else {
				if (!players.get(player).containsKey(exercise)) {									
					players.get(player).put(exercise, weight);
				} else {
					players.get(player).put(exercise, players.get(player).get(exercise) + weight);
				}
			}
		}
		
		for (Entry<String, TreeMap<String, Long>> player : players.entrySet()) {
			String playerName = player.getKey();
			TreeMap<String, Long> exercises = player.getValue();
			String output = String.format("%s : ", playerName);
			
			for (Entry<String, Long> exercise : exercises.entrySet()) {
				String exerciseName = exercise.getKey();
				
				long weight = exercise.getValue();
				
				output += String.format("%s - %d kg, ", exerciseName, weight);
			}
			
			output = output.substring(0, output.length() - 2);
			
			System.out.println(output);
		}
	}
}
