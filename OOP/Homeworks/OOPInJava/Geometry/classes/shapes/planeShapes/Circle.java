package classes.shapes.planeShapes;

import java.util.ArrayList;

import classes.Vertex;
import classes.shapes.PlaneShape;

public class Circle extends PlaneShape {
	private double radius;
	
	public Circle(ArrayList<Vertex> vertices, double radius) {
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
		double area = Math.PI * this.radius * this.radius;
		
		return area;
	}
	
	public double getPerimeter() {
		double perimeter = 2 * Math.PI * this.radius;
		
		return perimeter;
	}
}
