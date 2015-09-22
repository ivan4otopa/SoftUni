import java.util.Scanner;
public class Problem5DecimalToHexadecimal {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int dec = input.nextInt();
		String hex = Integer.toHexString(dec);
		System.out.println(hex.toUpperCase());
	}
}
