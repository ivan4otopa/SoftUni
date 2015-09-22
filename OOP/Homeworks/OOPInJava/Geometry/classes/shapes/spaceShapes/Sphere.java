package classes.shapes.spaceShapes;

import java.util.ArrayList;

import classes.Vertex;
import classes.shapes.SpaceShape;

public class Sphere extends SpaceShape{
	private double radius;
	
	public Sphere(ArrayList<Vertex> vertices, double radius) {
		super(vertices);
		this.setRadius(radius);
	}
	
	public double getRadius() {
		return this.radius;
	}
	
	public void setRadius(double radius) {
		this.radius = radius;
	}
	
	public double getArea() {
		double area = 4 * Math.PI * Math.pow(this.radius, 2);
		
		return area;
	}
	
	public double getVolume() {
		double volume = (4 * Math.PI * Math.pow(this.radius, 3)) / 3;
		
		return volume;
	}
}
