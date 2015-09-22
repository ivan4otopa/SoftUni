package classes.shapes.spaceShapes;

import java.util.ArrayList;

import classes.Vertex;
import classes.shapes.SpaceShape;

public class SquarePyramid extends SpaceShape {
	private double baseWidth;
	private double pyramidHeight;
	
	public SquarePyramid(ArrayList<Vertex> vertices, double baseWidth, double pyramidHeight) {
		super(vertices);
		this.setBaseWidth(baseWidth);
		this.setPyramidHeight(pyramidHeight);
	}
	
	public double getBaseWidth() {
		return this.baseWidth;
	}
	
	public void setBaseWidth(double baseWidth) {
		this.baseWidth = baseWidth;
	}
	
	public double getPyramidHeight() {
		return this.pyramidHeight;
	}
	
	public void setPyramidHeight(double pyramidHeight) {
		this.pyramidHeight = pyramidHeight;
	}
	
	public double getArea() {
		double area = Math.pow(this.baseWidth, 2) + (this.baseWidth * Math.sqrt(Math.pow(this.baseWidth, 2)) + 
			(Math.pow((2 * this.pyramidHeight), 2)));
		
		return area;
	}
	
	public double getVolume() {
		double volume = (Math.pow(this.baseWidth, 2) * this.pyramidHeight) / 3;
		
		return volume;
	}
}
