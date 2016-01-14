import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LettersChangeNumbers {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		String text = inputReader.nextLine();
		String[] strings = text.split("\\s+");
		String regex = "(\\w)(\\d+)(\\w)";
		Pattern pattern = Pattern.compile(regex);
		
		double result = 0;
		double endResult = 0;
		
		for (String string : strings) {
			Matcher matcher = pattern.matcher(string);
			
			matcher.matches();
			
			char firstLetter = matcher.group(1).charAt(0);			
			double number = Double.parseDouble(matcher.group(2));
			char secondLetter = matcher.group(3).charAt(0);

			if (isUpperCase(firstLetter)) {
				result = number / getAlphabetPosition(firstLetter);
			} else {
				result = number * getAlphabetPosition(firstLetter);
			}
			
			if (isUpperCase(secondLetter)) {
				result -= getAlphabetPosition(secondLetter);
			} else {
				result += getAlphabetPosition(secondLetter);
			}
			
			endResult += result;
			result = 0;
		}
		
		System.out.println(String.format("%.2f", endResult));
	}
	
	static boolean isUpperCase(char letter) {
		if (65 <= (int)letter && (int)letter <= 90 ) {
			return true;
		}
		
		return false;
	}
	
	static int getAlphabetPosition(char letter) {
		return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".indexOf(Character.toUpperCase(letter)) + 1;
	}
}
