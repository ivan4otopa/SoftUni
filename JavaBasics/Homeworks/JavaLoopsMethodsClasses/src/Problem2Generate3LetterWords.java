import java.util.Scanner;
public class Problem2Generate3LetterWords {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter 3 - letter non - repeating characters string:");
		String characters = input.nextLine();
		if(characters.length() > 3) {
			System.out.println("Enter 3 - letter non - repeating characters string:");
			characters = input.nextLine();
		}
		if(characters.length() <= 3) {
			for(int i = 0; i < characters.length(); i++) {
				for(int j = 0; j < characters.length(); j++) {
					for(int k = 0; k < characters.length(); k++)
						System.out.println("" + characters.charAt(i) + characters.charAt(j) + characters.charAt(k));
				}	
			}
		}
	}
}
