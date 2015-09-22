import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.util.Random;

/**
 * Class for the Apple object
 */
public class Apple {
	/**
	 * Create an instance of Random to give us a random number when we need it
	 */
	public static Random randomNumberGenerator;
	/**
	 * Create an object apple of type point
	 */
	private Point apple;
	/**
	 * Create an object color of type Color
	 */
	private Color appleColor;
	
	/**
	 * Constructor
	 */
	public Apple(Snake s) {
		apple = createApple(s);
		appleColor = Color.RED;		
	}
	
	/**
	 * Add an apple to our game field
	 */
	private Point createApple(Snake s) {
		randomNumberGenerator = new Random();
		int x = randomNumberGenerator.nextInt(30) * 20; 
		int y = randomNumberGenerator.nextInt(30) * 20;
		for (Point snakePoint : s.snakeBody) {
			if (x == snakePoint.getX() || y == snakePoint.getY()) {
				return createApple(s);				
			}
		}
		return new Point(x, y);
	}
	
	/**
	 * Draws apple in our game field
	 */
	public void drawApple(Graphics g){
		apple.drawObject(g, appleColor);
	}	
	
	/**
	 * Get a new apple
	 */
	public Point getApple() {
		return apple;
	}
}
