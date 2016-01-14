import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;

public class UserLogs {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);		
		Map<String, LinkedHashMap<String, Integer>> users = new TreeMap<>();
		
		while (true) {			
			String log = inputReader.nextLine();

			if (log.equals("end")) {
				break;
			}
			
			String[] parts = log.split(" ");
			String iP = parts[0].split("=")[1];
			String username = parts[2].split("=")[1];
			
			if (!users.containsKey(username)) {
				users.put(username, new LinkedHashMap<>());
				users.get(username).put(iP, 0);
				users.get(username).put(iP, users.get(username).get(iP) + 1);					
			} else {
				if (!users.get(username).containsKey(iP)) {
					users.get(username).put(iP, 0);
				}
				
				users.get(username).put(iP, users.get(username).get(iP) + 1);
			}
		}
		
		for (Entry<String, LinkedHashMap<String, Integer>> usernames : users.entrySet()) {
			String username = usernames.getKey();
			LinkedHashMap<String, Integer> iPs = usernames.getValue();
			String output = String.format("%s:\n", username);
			
			for (Entry<String, Integer> iP : iPs.entrySet()) {
				String iPAddress = iP.getKey();
				
				int numberOfMessages = iP.getValue();
				
				output += String.format("%s => %d, ", iPAddress, numberOfMessages);
			}
			
			output = output.substring(0, output.length() - 2) + '.';
			
			System.out.println(output);
		}
	}
}
