import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

@SuppressWarnings("serial")
/**
 * Game applet for our game
 */
public class GameApplet extends Applet {
	/**
	 * Create new instance of Game object
	 */
	private Game game;
	/**
	 * Create new instance of Key object
	 */
	Key key;
	
	/**
	 * Method to set up our game field
	 */
	public void initialize() {
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		key = new Key(game);
	}
	
	/**
	 * Method to tell our game field to draw itself
	 */
	public void draw(Graphics g) {
		this.setSize(new Dimension(800, 650));
	}

}
