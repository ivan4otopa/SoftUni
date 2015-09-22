import java.util.Scanner;
public class Problem5AngleUnitConverter {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = input.nextInt();
		String[] measures = new String[n];
		String deg = "deg";
		String rad = "rad";
		input.nextLine();
		for(int i = 0; i < n; i++)
			measures[i] = input.nextLine();
		for(int i = 0; i < n; i++) {
			if(measures[i].contains(deg)) {
				String numbersOnly = measures[i].replaceAll("[^0-9]", "");
				int a = Integer.parseInt(numbersOnly);
				System.out.printf("%.6f rad", DegToRad(a));
				System.out.println();
			}
			else if(measures[i].contains(rad)) {
				String numbersOnly = measures[i].replaceAll("[^0-9\\.]", "");
				double a = Double.parseDouble(numbersOnly);
				System.out.printf("%.6f deg", RadToDeg(a));
				System.out.println();
			}
		}
	}
	public static double DegToRad(int deg) {
		double rad = deg * (Math.PI / 180);
		return rad;
	}
	public static double RadToDeg(double rad) {
		double deg = rad * (180 / Math.PI);
		return deg;
	}
}
