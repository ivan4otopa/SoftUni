import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
public class Problem11MostFrequentWord {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().toLowerCase().split("[\\W]+");
		Map<String, Integer> wordFrequency = new HashMap<>();
		for(String word : words) {
			Integer count = wordFrequency.get(word);
			if(count == null)
				count = 0;
			wordFrequency.put(word, count + 1);
		}
		Integer highestValue = 0;
		for(Map.Entry<String, Integer> entry : wordFrequency.entrySet()) {
			Integer value = entry.getValue();
			if(value > highestValue)
				highestValue = value;
		}
		for(Map.Entry<String, Integer> entry : wordFrequency.entrySet()) {
			String key = entry.getKey();
			Integer value = entry.getValue();
			if(value == highestValue)
				System.out.println(key + " -> " + value + " times");
		}
	}
}
