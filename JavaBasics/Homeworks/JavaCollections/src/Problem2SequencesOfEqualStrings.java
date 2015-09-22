import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
public class Problem2SequencesOfEqualStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] sequence = input.nextLine().split(" ");
		Map<String, Integer> occurrences = new HashMap<>();
		for(String word : sequence) {
			Integer count = occurrences.get(word);
			if(count == null)
				count = 0;
			occurrences.put(word, count + 1);
		}
		for(Map.Entry<String, Integer> entry : occurrences.entrySet()) {
			String key = entry.getKey();
			Integer value = entry.getValue();
			for(int i = 0; i < value; i++)
				System.out.print(key + " ");
			System.out.println();
		}
	}
}
