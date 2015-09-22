import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

@SuppressWarnings("serial")
/**
 * A Class for our Game which is being displayed via Canvas
 */
public class Game extends Canvas implements Runnable {
	/**
	 * Create new instance of Snake object
	 */
	public static Snake snake;
	/**
	 * Create new instance of Apple object
	 */
	public static Apple apple;
	/**
	 * Create a variable which holds how many points we have
	 */
	static int points;
	
	/**
	 * Create new instance of Graphics
	 */
	private Graphics globalGraphics;
	/**
	 * Create new instance of Thread
	 */
	private Thread runThread;
	/**
	 * Constant to hold our canvs(window) width
	 */
	public static final int WIDTH = 600;
	/**
	 * Constant to hold our canvas(window) height
	 */
	public static final int HEIGHT = 600;
	/**
	 * Create new instance of Dimension
	 */
	private final Dimension gameSize = new Dimension(WIDTH, HEIGHT);
	
	/**
	 * Boolean to track wether our game is running or not
	 */
	static boolean gameRunning = false;
	
	/**
	 * Method to tell the canvas to draw itself
	 */
	public void draw(Graphics g) {
		this.setPreferredSize(gameSize);
		globalGraphics = g.create();
		points = 0;
		
		if(runThread == null) {
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	/**
	 * Method to tell our game to start
	 */
	public void run() {
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: fani ma za eksep6ana
			}
		}
	}
	
	/**
	 * Constructor
	 */
	public Game() {	
		snake = new Snake();
		apple = new Apple(snake);
	}
		
	
	/**
	 * Method to tell our game to render itself
	 */
	public void render(Graphics g) {
		g.clearRect(0, 0, WIDTH, HEIGHT + 25);
		
		g.drawRect(0, 0, WIDTH, HEIGHT);			
		snake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + points, 10, HEIGHT + 25);		
	}
}

