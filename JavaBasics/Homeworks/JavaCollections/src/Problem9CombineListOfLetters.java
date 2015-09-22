import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;
public class Problem9CombineListOfLetters {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] firstRow = input.nextLine().split(" ");
		String[] secondRow = input.nextLine().split(" ");
		ArrayList<Character> firstRowCharacters = new ArrayList<>();
		ArrayList<Character> secondRowCharacters = new ArrayList<>();
		for(String character : firstRow)
			firstRowCharacters.add(character.charAt(0));
		for(String character : secondRow)
			secondRowCharacters.add(character.charAt(0));
		ArrayList<Character> result = new ArrayList<>();
		result.addAll(firstRowCharacters);
		for(char character : secondRowCharacters) {
			if(!firstRowCharacters.contains(character))
				result.add(character);
		}
		for(char character : result)
			System.out.print(character + " ");
	}
}
