import java.util.Scanner;
public class Problem6FormattingNumbers {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println("Enter a number 0 <= a <= 500:");
		int a = input.nextInt();
		if(a < 0 && a > 500) {
			System.out.println("The number must be 0 <= a <= 500:");
			a = input.nextInt();
		}
		float b = input.nextFloat();
		float c = input.nextFloat();
		System.out.printf("|%-10s|%s|%10.2f|%-10.3f|", DecToHex(a), DecToBin(a), b, c);
	}
	public static String DecToHex(int n) {
		String hex = Integer.toHexString(n);
		return hex.toUpperCase();
	}
	public static String DecToBin(int n) {
		String bin = String.format("%10s", Integer.toBinaryString(n)).replace(' ', '0');
		return bin;
	}
}
