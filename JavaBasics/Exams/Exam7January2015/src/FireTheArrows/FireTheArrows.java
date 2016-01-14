package FireTheArrows;

import java.util.Scanner;

public class FireTheArrows {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		
		int numberOfRows = Integer.parseInt(inputReader.nextLine());

		String[] matrix = new String[numberOfRows];
		
		for (int i = 0; i < numberOfRows; i++) {
			matrix[i] = inputReader.nextLine();
		}
		
		for (int i = 0; i < matrix.length; i++) {
			for (int j = 0; j < matrix.length; j++) {
				for (int k = 0; k < matrix[i].length(); k++) {
					if (matrix[j].charAt(k) == '<' && k != 0) {
						if (matrix[j].charAt(k - 1) == 'o') {
							matrix[j] = replaceCharAt(matrix[j], k - 1, '<');
							matrix[j] = replaceCharAt(matrix[j], k, 'o');
						}
					} else if (matrix[j].charAt(k) == '>' && k != matrix[i].length() - 1) {
						if (matrix[j].charAt(k + 1) == 'o') {
							matrix[j] = replaceCharAt(matrix[j], k + 1, '>');
							matrix[j] = replaceCharAt(matrix[j], k, 'o');
						}
					} else if (matrix[j].charAt(k) == '^' && j != 0) {
						if (matrix[j - 1].charAt(k) == 'o') {
							matrix[j - 1] = replaceCharAt(matrix[j - 1], k, '^');
							matrix[j] = replaceCharAt(matrix[j], k, 'o');
						}
					} else if (matrix[j].charAt(k) == 'v' && j != matrix.length - 1) {
						if (matrix[j + 1].charAt(k) == 'o') {
							matrix[j + 1] = replaceCharAt(matrix[j + 1], k, 'v');
							matrix[j] = replaceCharAt(matrix[j], k, 'o');
						}
					}
				}
			}
		}
		
		for (String row : matrix) {
			System.out.println(row);
		}
	}
	
	public static String replaceCharAt(String s, int pos, char c) {
	   return s.substring(0,pos) + c + s.substring(pos+1);
	}
}
