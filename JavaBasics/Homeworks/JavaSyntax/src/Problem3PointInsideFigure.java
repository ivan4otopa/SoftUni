import java.util.Scanner;
public class Problem3PointInsideFigure {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		float x = input.nextFloat();
		float y = input.nextFloat();
		if(InsideRectangle1(x, y) || InsideRectangle2(x, y) || InsideRectangle3(x, y))
			System.out.println("Inside");
		else
			System.out.println("Outside");
	}
	public static boolean InsideRectangle1(float a, float b) {
		if(a >= 12.5 && a <= 22.5 && b >= 6 && b <= 8.5)
			return true;
		else
			return false;
	}
	public static boolean InsideRectangle2(float a, float b) {
		if(a >= 12.5 && a <= 17.5 && b >= 8.5 && b <= 13.5)
			return true;
		else
			return false;
	}
	public static boolean InsideRectangle3(float a, float b) {
		if(a >= 20 && a <= 22.5 && b >= 8.5 && b <= 13.5)
			return true;
		else
			return false;
	}
}
