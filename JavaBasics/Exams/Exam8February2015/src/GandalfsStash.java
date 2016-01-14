import java.util.Scanner;

public class GandalfsStash {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		int moodPoints = Integer.parseInt(inputReader.nextLine());
		String text = inputReader.nextLine();
		String[] foods = text.split("\\P{Alpha}+");

		for (String food : foods) {
			switch (food.toLowerCase()) {
			case "cram":
				moodPoints += 2;
				break;
			case "lembas":
				moodPoints += 3;
				break;
			case "apple":
				moodPoints += 1;
				break;
			case "melon":
				moodPoints += 1;
				break;
			case "honeycake":
				moodPoints += 5;
				break;
			case "mushrooms":
				moodPoints -= 10;
				break;
			default:
				moodPoints -= 1;
				break;
			}
		}
		
		System.out.println(moodPoints);
		
		if (moodPoints < -5) {
			System.out.println("Angry");
		} else if (-5 <= moodPoints && moodPoints < 0) {
			System.out.println("Sad");
		} else if (0 <= moodPoints && moodPoints <= 15) {
			System.out.println("Happy");
		} else {
			System.out.println("Special JavaScript mood");
		}
	}
}
