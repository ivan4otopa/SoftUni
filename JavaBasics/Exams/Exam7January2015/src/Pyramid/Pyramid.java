package Pyramid;

import java.util.Arrays;
import java.util.Scanner;

public class Pyramid {
	public static void main(String[] args) {
		Scanner s = new Scanner(System.in);
		
		int numberOfRows = Integer.parseInt(s.nextLine());
		int currentNumber = s.nextInt();	
		
		s.nextLine();
		
		String numbersRow;	
		
		System.out.print(currentNumber);
		
		int rowCount = 0;
		
		for (int i = 0; i < numberOfRows - 1; i++) {
			numbersRow = s.nextLine().trim();
			
			if (currentNumber + rowCount < getNextNumber(currentNumber + rowCount, numbersRow)) {
				currentNumber = getNextNumber(currentNumber + rowCount, numbersRow);			

				System.out.print(", " + currentNumber);
				
				rowCount = 0;
			} else {			
				rowCount++;
			}
		}
	}
	
	static int getNextNumber(int currentNumber, String numbersRow) {
		String[] stringArray = numbersRow.split("\\s+");
		
		int[] numbers = getIntArray(stringArray);
		
		Arrays.sort(numbers);
		
		for (int i = 0; i < numbers.length; i++) {
			if (numbers[i] > currentNumber) {
				currentNumber = numbers[i];
				
				break;
			}
		}
		
		return currentNumber;
	}
	
	static int[] getIntArray(String[] stringArray) {
		int[] numbers = new int[stringArray.length];
		
		for (int i = 0; i < stringArray.length; i++) {
			numbers[i] = Integer.parseInt(stringArray[i]);
		}
		
		return numbers;
	}
}
