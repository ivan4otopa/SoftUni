import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

/**
 * Class Point to help us determine different fields pin our game window
 */
public class Point {
	/**
	 * x and y to set our coorinates in the game field
	 */
	private int x, y;
	/**
	 * Constant to hold our mini - field width
	 */
	private final int WIDTH = 20;
	/**
	 * Constant to hold our mini - field height
	 */
	private final int HEIGHT = 20;
	
	/**
	 * Constructor
	 */
	public Point(Point p){
		this(p.x, p.y);
	}
	
	/**
	 * Constructor
	 */
	public Point(int x, int y){
		this.x = x;
		this.y = y;
	}	
	
	/**
	 * Gets the coordinates of x
	 */
	public int getX() {
		return x;
	}
	
	/**
	 * Sets the coordinates of x
	 */
	public void setX(int x) {
		this.x = x;
	}

	/**
	 * Gets the coordinates of y
	 */
	public int getY() {
		return y;
	}
	
	/**
	 * Sets the coordinates of y
	 */
	public void setY(int y) {
		this.y = y;
	}
	
	/**
	 * Draws a new Point object
	 */
	public void drawObject(Graphics g, Color c) {
		g.setColor(Color.BLACK);
		g.fillRect(x, y, WIDTH, HEIGHT);
		g.setColor(c);
		g.fillRect(x + 1, y + 1, WIDTH - 2, HEIGHT - 2);		
	}
	
	/**
	 * Stringifies our Point
	 */
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	/**
	 * Checks if the position of one Point is equal to another
	 */
	public boolean equals(Object o) {
        if (o instanceof Point) {
            Point point = (Point)o;
            return (x == point.x) && (y == point.y);
        }
        return false;
    }
}
