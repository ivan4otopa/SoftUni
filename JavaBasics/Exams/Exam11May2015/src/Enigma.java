import java.util.Scanner;

public class Enigma {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		
		int numberOfLines = Integer.parseInt(inputReader.nextLine());
		
		for (int i = 0; i < numberOfLines; i++) {
			String line = inputReader.nextLine();
			
			int lineLength = line.replaceAll("\\d+", "").replaceAll("\\s+", "").length();
			int halfLineLength = lineLength / 2;
			
			String output = "";
			
			for (int j = 0; j < line.length(); j++) {
				if (!Character.isWhitespace(line.charAt(j)) && !Character.isDigit(line.charAt(j))) {
					int asciiNumber = line.charAt(j);
					
					output += (char)(halfLineLength + asciiNumber);
				} else {
					output += line.charAt(j);
				}				
			}
			
			System.out.println(output);
		}
	}
}
