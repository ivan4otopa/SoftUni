import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;
public class Problem10ExtractAllUniqueWords {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words =input.nextLine().toLowerCase().split("[\\W]+");
		Arrays.sort(words);
		HashSet<String> uniqueWords = new HashSet<>();
		for(String word : words)
			uniqueWords.add(word);
		for(String word : uniqueWords)
			System.out.print(word + " ");
	}
}
