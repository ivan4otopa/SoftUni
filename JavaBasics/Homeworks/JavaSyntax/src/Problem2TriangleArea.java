import java.util.Scanner;
public class Problem2TriangleArea {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int ax = input.nextInt();
		int ay = input.nextInt();
		int bx = input.nextInt();
		int by = input.nextInt();
		int cx = input.nextInt();
		int cy = input.nextInt();
		double a = Math.sqrt((cx - bx) * (cx - bx) + (cy - by) * (cy - by));
		double b = Math.sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
		double c = Math.sqrt((cx - ax) * (cx - ax) + (cy - ay) * (cy - ay));
		int triangleArea = (int)(ax * (by - cy) + bx * (cy - ay) + cx * (ay - by));
		if(a + b == c && a + c == b && b + c == a)
			System.out.println(0);
		else
			System.out.println(Math.abs(triangleArea / 2));
	}
}
