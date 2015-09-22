import java.util.ArrayList;
import java.util.Scanner;
public class Problem4LongestIncreasingSequence {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] numbers = input.nextLine().split(" ");
		int[] digits = new int[numbers.length];
		for(int i = 0; i < numbers.length; i++)
			digits[i] = Integer.parseInt(numbers[i]);
	}
}
