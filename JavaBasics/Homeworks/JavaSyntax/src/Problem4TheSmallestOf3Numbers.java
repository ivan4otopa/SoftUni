import java.util.Scanner;
public class Problem4TheSmallestOf3Numbers {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		double a = input.nextDouble();
		double b = input.nextDouble();
		double c = input.nextDouble();
		if(a <= b && a <= c) {
			if(a != 1 && a != -1) {
				if(a % 2 == 0)
					System.out.println((int)a);
				else
					System.out.println(a);
			}
			else
				System.out.println((int)a);
		}
		else if(b <= a && b <= c) {
			if(b != 1 && b != -1) {
				if(b % 2 == 0)
					System.out.println((int)b);
				else
					System.out.println(b);
			}
			else
				System.out.println((int)b);
		}
		else if(c <= a && c <= b) {
			if(c != 1 && c != -1) {
				if(c % 2 == 0)
					System.out.println((int)c);
				else
					System.out.println(c);
			}
			else
				System.out.println((int)c);
		}
	}
}
