import java.util.Scanner;

public class LegoBlocks {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		
		int numberOfRows = Integer.parseInt(inputReader.nextLine());
		
		String[][] firstJaggedArray = new String[numberOfRows][];
		String[][] secondJaggedArray = new String[numberOfRows][];
		
		fillJaggedArray(firstJaggedArray, inputReader);
		fillJaggedArray(secondJaggedArray, inputReader);
		
		int firstRowLength = firstJaggedArray[0].length + secondJaggedArray[0].length;
		boolean arraysFit = true;
		
		for (int i = 1; i < numberOfRows; i++) {
			if (firstJaggedArray[i].length + secondJaggedArray[i].length != firstRowLength) {
				arraysFit = false;
			}
		}
		
		if (arraysFit) {
			for (int i = 0; i < numberOfRows; i++) {
				String output = "[";
				
				for (int j = 0; j < firstJaggedArray[i].length; j++) {
					output += firstJaggedArray[i][j] + ", ";
				}
				
				for (int j = secondJaggedArray[i].length - 1; j >= 0; j--) {
					output += secondJaggedArray[i][j] + ", ";
				}
				
				output = output.substring(0, output.length() - 2) + "]";
				System.out.println(output);
			}				
		} else {
			int cellSum = 0;
			
			for (int i = 0; i < numberOfRows; i++) {
				for (int j = 0; j < firstJaggedArray[i].length; j++) {
					cellSum++;
				}
				
				for (int j = 0; j < secondJaggedArray[i].length; j++) {
					cellSum++;
				}
			}
			
			System.out.println(String.format("The total number of cells is: %d", cellSum));
		}
	}
	
	static void fillJaggedArray(String[][] array, Scanner inputReader) {
		for (int i = 0; i < array.length; i++) {
			String[] line = inputReader.nextLine().trim().split("\\s+");
			
			array[i] = line; 
		}
	}
}
