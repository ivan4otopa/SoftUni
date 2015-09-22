package classes.shapes.planeShapes;

import java.util.ArrayList;

import classes.Vertex;
import classes.shapes.PlaneShape;

public class Rectangle extends PlaneShape {
	private double width;
	private double height;
	
	public Rectangle(ArrayList<Vertex> vertices, double width, double height) {
		super(vertices);
		this.setWidth(width);
		this.setHeight(height);
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
	
	public double getArea() {
		double area = this.width * this.height;
		
		return area;
	}
	
	public double getPerimeter() {
		double perimeter = (this.width * 2) + (this.height * 2);
		
		return perimeter;
	}
}
