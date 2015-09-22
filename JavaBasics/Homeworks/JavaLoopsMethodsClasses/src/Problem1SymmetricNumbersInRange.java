import java.util.Scanner;
public class Problem1SymmetricNumbersInRange {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter two numbers in range 0 <= start <= end <= 999:");
		int start = input.nextInt();
		int end = input.nextInt();
		if(start < end) {
			if(start < 0 || start > 999 || end < 0 || end > 999) {
				System.out.println("Enter two numbers in range 0 <= start <= end <= 999:");
				start = input.nextInt();
				end = input.nextInt();
			}
		}
		else if(start > end) {
			System.out.println("Enter two numbers in range 0 <= start <= end <= 999:");
			start = input.nextInt();
			end = input.nextInt();
		}
		for(int i = start; i <= end; i++) {
			if(i / 10 == 0)
				System.out.print(i + " ");
			else if(i / 10 != 0 && i / 100 == 0) {
				if(i / 10 == i % 10)
					System.out.print(i + " ");
			}
			else if(i / 100 != 0) {
				if(i / 100 == i % 10)
					System.out.print(i + " ");
			}
		}
	}
}
