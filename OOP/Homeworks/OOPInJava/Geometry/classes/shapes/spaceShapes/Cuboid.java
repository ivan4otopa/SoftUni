package classes.shapes.spaceShapes;

import java.util.ArrayList;

import classes.Vertex;
import classes.shapes.SpaceShape;

public class Cuboid extends SpaceShape {
	private double width;
	private double height;
	private double depth;
	
	public Cuboid(ArrayList<Vertex> vertices, double width, double height, double depth) {
		super(vertices);
		this.setWidth(width);
		this.setHeight(height);
		this.setDepth(depth);
	}
	
	public double getWidth() {
		return this.width;
	}
	
	public void setWidth(double width) {
		this.width = width;
	}
	
	public double getHeight() {
		return this.height;
	}
	
	public void setHeight(double height) {
		this.height = height;
	}
	
	public double getDepth() {
		return this.depth;
	}
	
	public void setDepth(double depth) {
		this.depth = depth;
	}
	
	public double getArea() {
		double area = (2 * this.width * this.height) + (2 * this.width * this.depth) + (2 * this.height * this.depth);
		
		return area;
	}
	
	public double getVolume() {
		double volume = this.width * this.height * this.depth;
		
		return volume;
	}
}
