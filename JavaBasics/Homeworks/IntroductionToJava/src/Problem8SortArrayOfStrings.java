import java.util.Arrays;
import java.util.Scanner;

public class Problem8SortArrayOfStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String[] a = new String[n];
		input.nextLine();
		for(int i = 0; i < n; i++)
			a[i] = input.nextLine();
		Arrays.sort(a);
		for(int i = 0; i < n; i++)
			System.out.println(a[i]);
	}
}
