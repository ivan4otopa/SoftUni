package TerroristsWin;

import java.util.Scanner;

public class TerroristsWin {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		String text = inputReader.nextLine();			
		
		int bombStartIndex;
		int bombEndIndex;
		int bombRange;
		
		while (text.indexOf('|') > -1) {
			bombStartIndex = text.indexOf('|');
			bombEndIndex = nthIndexOf(text, '|', 2);
			bombRange = getLastAsciiDigit(text.substring(bombStartIndex + 1, bombEndIndex));
			
			StringBuilder newText = new StringBuilder(text);
			
			if (bombStartIndex - bombRange < 0){
				for (int i = 0; i < bombEndIndex + bombRange + 1; i++) {
					newText.setCharAt(i, '.');
				}
			} else if (bombStartIndex + bombRange > text.length()) {
				for (int i = bombStartIndex - bombRange; i < text.length(); i++) {
					newText.setCharAt(i, '.');
				}
			} else {
				for (int i = bombStartIndex - bombRange; i < bombEndIndex + bombRange + 1; i++) {
					newText.setCharAt(i, '.');
				}
			}
			
			text = newText.toString();
		}
		
		System.out.println(text);
	}
	
	public static int nthIndexOf(String text, char needle, int n)
	{
	    for (int i = 0; i < text.length(); i++)
	    {
	        if (text.charAt(i) == needle)
	        {
	            n--;
	            
	            if (n == 0)
	            {
	                return i;
	            }
	        }
	    }
	    
	    return -1;
	}
	
	public static int getLastAsciiDigit(String text) {
		int sum = 0;
		
		for (int i = 0; i < text.length(); i++) {
			sum += (int)text.charAt(i);
		}
		
		return sum % 10;
	}
}
