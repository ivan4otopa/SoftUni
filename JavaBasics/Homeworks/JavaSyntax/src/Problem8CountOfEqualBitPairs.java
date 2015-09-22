import java.util.Scanner;
public class Problem8CountOfEqualBitPairs {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String bin = Integer.toBinaryString(n);
		int count = 0;
		for(int i = 0; i < bin.length() - 1; i++) {
			if(bin.charAt(i) == bin.charAt(i + 1))
				count++;
		}
		System.out.println(count);
	}
}
