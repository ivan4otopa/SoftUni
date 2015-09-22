import java.util.Scanner;
public class Problem7CountOfBitsOne {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		System.out.println(CountOfBitsOne(n));
	}
	public static int CountOfBitsOne(int n) {
		int mask = 1;
		int count = 0;
		for(int i = 0; i < 32; i++) {
			if((n & (mask << i)) > 0)
				count++;
		}
		return count;
	}
}
