import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
public class Problem7CountSubStringOccuerences {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String words = input.nextLine().toLowerCase();
		String targetWord = input.next();
		int count = 0;
		Pattern pattern = Pattern.compile(targetWord);
		Matcher matcher = pattern.matcher(words);
		while(matcher.find()) {
			count++;
			matcher.region(matcher.start() + 1, words.length());
		}
		System.out.println(count);
	}
}
