import java.util.Scanner;
public class Problem6CountSpecifiedWord {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] words = input.nextLine().toLowerCase().split("[\\W]+");
		String targetWord = input.next();
		int count = 0;
		for(String word : words) {
			if(word.equals(targetWord))
				count++;
		}
		System.out.println(count);
	}
}
