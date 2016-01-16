import java.util.Scanner;

public class LabyrinthDash {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		
		int numberOfRows = Integer.parseInt(inputReader.nextLine());
		
		String[][] labyrinth = new String[numberOfRows][];
		
		for (int i = 0; i < numberOfRows; i++) {
			labyrinth[i] = inputReader.nextLine().split("");
		}
		
		String[] moves = inputReader.nextLine().split("");
		
		int lives = 3;
		int positionX = 0;
		int positionY = 0;
		int numberOfMoves = 0;
		
		for (int i = 0; i < moves.length; i++) {
			if (moves[i].equals("v")) {
				if (positionY == labyrinth.length - 1 || labyrinth[positionY + 1][positionX].equals(" ")) {
					numberOfMoves++;
					
					System.out.println("Fell off a cliff! Game Over!");
					
					break;
				} else if (labyrinth[positionY + 1][positionX].equals("_") || labyrinth[positionY + 1][positionX].equals("|")) {
					System.out.println("Bumped a wall.");
					
					continue;
				} else {
					positionY++;
				}
			} else if (moves[i].equals("^")) {
				if (positionY == 0 || labyrinth[positionY - 1][positionX].equals(" ")) {
					numberOfMoves++;
					
					System.out.println("Fell off a cliff! Game Over!");
					
					break;
				} else if (labyrinth[positionY - 1][positionX].equals("_") || labyrinth[positionY - 1][positionX].equals("|")) {
					System.out.println("Bumped a wall.");
					
					continue;
				} else {				
					positionY--;
				}
			} else if (moves[i].equals("<")) {
				if (positionX == 0 || labyrinth[positionY][positionX - 1].equals(" ")) {
					numberOfMoves++;
					
					System.out.println("Fell off a cliff! Game Over!");
					
					break;
				} else if (labyrinth[positionY][positionX - 1].equals("_") || labyrinth[positionY][positionX - 1].equals("|")) {
					System.out.println("Bumped a wall.");
					
					continue;
				} else {
					positionX--;
				}
			} else {
				if (positionX == labyrinth[positionY].length - 1 || labyrinth[positionY][positionX + 1].equals(" ")) {
					numberOfMoves++;
					
					System.out.println("Fell off a cliff! Game Over!");
					
					break;
				} else if (labyrinth[positionY][positionX + 1].equals("_") || labyrinth[positionY][positionX + 1].equals("|")) {
					System.out.println("Bumped a wall.");
					
					continue;
				} else {
					positionX++;
				}
			}
						
			if (labyrinth[positionY][positionX].equals("@") || 
						labyrinth[positionY][positionX].equals("#") ||
						labyrinth[positionY][positionX].equals("*")) {
				lives--;
				numberOfMoves++;
				
				System.out.println(String.format("Ouch! That hurt! Lives left: %d", lives));
				
				if (lives == 0) {
					System.out.println("No lives left! Game Over!");
					
					break;					
				}
			} else if (labyrinth[positionY][positionX].equals("$")) {
				numberOfMoves++;
				lives++;
				
				System.out.println(String.format("Awesome! Lives left: %d", lives));
				
				labyrinth[positionY][positionX] = ".";
			} else {
				numberOfMoves++;
				
				System.out.println("Made a move!");
			}
		}
		
		System.out.println(String.format("Total moves made: %d", numberOfMoves));
	}
}
