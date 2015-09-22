import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import javax.sound.midi.Sequence;
public class Problem8ExtractEmails {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String sentence = input.nextLine();
		Pattern pattern = Pattern.compile("[a-zA-z0-9]+[\\.,-]*[a-zA-Z0-9]+[@]+[a-zA-Z0-9]+[\\.-]*[a-zA-Z0-9]+[\\.]+[a-zA-Z0-9]+");
		Matcher matcher = pattern.matcher(sentence);
		while(matcher.find())
			System.out.println(matcher.group());
	}
}
