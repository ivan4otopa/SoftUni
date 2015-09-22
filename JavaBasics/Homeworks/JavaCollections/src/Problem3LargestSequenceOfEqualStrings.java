import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
public class Problem3LargestSequenceOfEqualStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] strings = input.nextLine().split(" ");
		Map<String, Integer> map = new HashMap<>();
		for(String word : strings) {
			Integer count = map.get(word);
			if(count == null)
				count = 0;
			map.put(word, count + 1);
		}
		String largestSequence = "";
		Integer highestValue = 0;
		for(Map.Entry<String, Integer> entry : map.entrySet()) {
			String key = entry.getKey();
			Integer value = entry.getValue();
			if(value > highestValue) {
				largestSequence = key;
				highestValue = value;
			}
		}
		for(int i = 0; i < highestValue; i++) 
			System.out.print(largestSequence + " ");
	}
}
