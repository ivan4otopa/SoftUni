import java.util.Scanner;
public class Problem9PointsInsideTheHouse {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		float x = input.nextFloat();
		float y = input.nextFloat();
		if(InsideRectangle1(x, y) || InsideRectangle2(x, y) || InsideTriangle(x, y))
			System.out.println("Inside");
		else
			System.out.println("Outside");
	}
	public static boolean InsideTriangle(float a, float b) {
		double x1 = 12.5;
		double x2 = 17.5;
		double x3 = 22.5;
		double y1 = 8.5;
		double y2 = 3.5;
		double y3 = 8.5;
		double abc = Math.abs(x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2));
		double abp = Math.abs(x1 * (y2 - b) + x2 * (b - y1) + a * (y1 - y2));
		double apc = Math.abs(x1 * (b - y3) + a * (y3 - y1) + x3 * (y1 - b));
		double pbc = Math.abs(a * (y2 - y3) + x2 * (y3 - b) + x3 * (b - y2));
		boolean isTriangle = abp + apc + pbc == abc;
		return isTriangle;
	}
	public static boolean InsideRectangle1(float a, float b) {
		if(a >= 12.5 && a <= 17.5 && b >= 8.5 && b <= 13.5)
			return true;
		else
			return false;
	}
	public static boolean InsideRectangle2(float a, float b) {
		if(a >= 20 && a <= 22.5 && b >= 8.5 && b <= 13.5)
			return true;
		else
			return false;
	}
}