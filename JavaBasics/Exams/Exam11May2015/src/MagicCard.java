import java.util.Scanner;

public class MagicCard {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		String[] hand = inputReader.nextLine().split(" ");
		String position = inputReader.nextLine();
		String magicCard = inputReader.nextLine();
		
		String magicCardFace = "";
		String magicCardSuit = "";
		
		if (magicCard.length() == 3) {
			magicCardFace = magicCard.substring(0, 2);
			magicCardSuit = magicCard.substring(2);
		} else {
			magicCardFace = magicCard.substring(0, 1);
			magicCardSuit = magicCard.substring(1);
		}

		int handValue = 0;
		
		for (int i = 0; i < hand.length; i++) {
			String face = "";
			String suit = "";
			
			if (hand[i].length() == 3) {
				face = hand[i].substring(0, 2);
				suit = hand[i].substring(2);
			} else {
				face = hand[i].substring(0, 1);
				suit = hand[i].substring(1);
			}						
			
			if (position.equals("odd")) {
				if (i % 2 != 0) {
					handValue += calcCardValue(face, suit, magicCardFace, magicCardSuit);
				}				
			} else {
				if (i % 2 == 0) {
					handValue += calcCardValue(face, suit, magicCardFace, magicCardSuit);
				}
			}
		}
		
		System.out.println(handValue);
	}
	
	static int calcCardValue(String face, String suit, String magicCardFace, String magicCardSuit) {
		int multiplier = 0;
		
		switch (face) {
			case "2":
				multiplier = 20;
				break;
			case "3":
				multiplier = 30;
				break;
			case "4":
				multiplier = 40;
				break;
			case "5":
				multiplier = 50;
				break;
			case "6":
				multiplier = 60;
				break;
			case "7":
				multiplier = 70;
				break;
			case "8":
				multiplier = 80;
				break;
			case "9":
				multiplier = 90;
				break;
			case "10":
				multiplier = 100;
				break;
			case "J":
				multiplier = 120;
				break;
			case "Q":
				multiplier = 130;
				break;
			case "K":
				multiplier = 140;
				break;
			case "A":
				multiplier = 150;
				break;
		}
		
		if (magicCardFace.equals(face)) {
			return 3 * multiplier;
		} else if (magicCardSuit.equals(suit)) {
			return 2 * multiplier;
		} else {
			return multiplier;
		}
	}
}
