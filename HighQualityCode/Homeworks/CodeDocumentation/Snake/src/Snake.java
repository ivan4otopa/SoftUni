import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.util.LinkedList;

/**
 * Class for our game object - Snake
 */
public class Snake {
	/**
	 * Crete a linked list so we can add or remove Points to or off our snake body
	 */
	LinkedList<Point> snakeBody = new LinkedList<Point>();
	/**
	 * Color of snake
	 */
	private Color snakeColor;
	/**
	 * Variables to track the speed of the snake
	 */
	private int velocityX, velocityY;
	
	/**
	 * Constructor
	 */
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new Point(300, 100)); 
		snakeBody.add(new Point(280, 100)); 
		snakeBody.add(new Point(260, 100)); 
		snakeBody.add(new Point(240, 100)); 
		snakeBody.add(new Point(220, 100)); 
		snakeBody.add(new Point(200, 100)); 
		snakeBody.add(new Point(180, 100));
		snakeBody.add(new Point(160, 100));
		snakeBody.add(new Point(140, 100));
		snakeBody.add(new Point(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	/**
	 * Method to tell our snake to draw itself
	 */
	public void drawSnake(Graphics g) {		
		for (Point point : this.snakeBody) {
			point.drawObject(g, snakeColor);
		}
	}
	
	/**
	 * Method which tracks the movement of our snake
	 */
	public void tick() {
		Point newPointPosition = new Point((snakeBody.get(0).getX() + velocityX), (snakeBody.get(0).getY() + velocityY));
		
		//Next 4 if statements check whether our snake has run into walls
		if (newPointPosition.getX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (newPointPosition.getX() < 0) {
			Game.gameRunning = false;
		} else if (newPointPosition.getY() < 0) {
			Game.gameRunning = false;
		} else if (newPointPosition.getY() > Game.HEIGHT - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.getApple().equals(newPointPosition)) {
			snakeBody.add(Game.apple.getApple());
			Game.apple = new Apple(this);
			Game.points += 50;
		} else if (snakeBody.contains(newPointPosition)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size() - 1; i > 0; i--) {
			snakeBody.set(i, new Point(snakeBody.get(i - 1)));
		}	
		snakeBody.set(0, newPointPosition);
	}

	/**
	 * Gets the velocity on the x coordinate
	 */
	public int getVelocityX() {
		return velocityX;
	}

	/**
	 * Sets the velocity on the x coordinate
	 */
	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	/**
	 * Gets the velocity on the y coordinate
	 */
	public int getVelocityY() {
		return velocityY;
	}

	/**
	 * Sets the velocity on the y coordinate
	 */
	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
