import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
public class Problem12CardFrequences {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] cards = input.nextLine().split("[\\W]+");
		Map<String, Integer> cardFrequences = new HashMap<>();
		for(String card : cards) {
			Integer count = cardFrequences.get(card);
			if(count == null)
				count = 0;
			cardFrequences.put(card, count + 1);
		}
		for(Map.Entry<String, Integer> card : cardFrequences.entrySet()) {
			String key = card.getKey();
			Integer value = card.getValue();
			System.out.printf(key + " -> " + "%.2f", ((double)value / cards.length) * 100);
			System.out.println("%");
		}
	}
}
