import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdScript {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		
		int keyValue = Integer.parseInt(inputReader.nextLine());
		
		if (keyValue > 52) {
			keyValue = mapKeyValue(keyValue);
		}
		
		String key = getKey(keyValue);
		String regex = key + "(.*?)" + key;
		Pattern pattern = Pattern.compile(regex);
		String allLines = "";
		
		while (true) {
			String line = inputReader.nextLine();
			
			if (line.equals("End")) {
				break;
			}
			
			allLines += line;
		}

		Matcher matcher = pattern.matcher(allLines);

		while (matcher.find()) {
			if (matcher.group(1).length() > 0) {
				System.out.println(matcher.group(1));
			}
		}
	}
	
	static int mapKeyValue(int keyValue) {
		while (keyValue > 52) {
			keyValue -= 52;
		}
		
		return keyValue;
	}
	
	static String getKey(int keyValue) {
		String key = "";
		
		if (1 <= keyValue && keyValue <= 26) {
			for (int i = 0; i < 2; i++) {
				key += "abcdefghijklmnopqrstuvwxyz".charAt(keyValue - 1);
			}
		} else {
			for (int i = 0; i < 2; i++) {
				key += "ABCDEFGHIJKLMNOPQRSTUVWXYZ".charAt(keyValue - 27);
			}
		}
		
		return key;
	}
}
