package classes.shapes;

import java.util.ArrayList;

import classes.Shape;
import interfaces.AreaMeasurable;
import interfaces.PerimeterMeasurable;
import classes.Vertex;

public abstract class PlaneShape extends Shape implements PerimeterMeasurable, AreaMeasurable {
	public PlaneShape(ArrayList<Vertex> vertices) {
		super(vertices);
	}
	
	public abstract double getArea();
	public abstract double getPerimeter();
	
	@Override
	public String toString() {
		StringBuilder planeShape = new StringBuilder();
		
		String planeShapeType = "Shape Type: " + this.getClass().getName() + "; ";
		planeShape.append(planeShapeType);
		
		planeShape.append(super.toString());
		
		String planeShapeArea = "Area: " + this.getArea() + "; ";
		planeShape.append(planeShapeArea);

		String planeShapeParameter = "Parameter: " + this.getPerimeter() + "; ";
		planeShape.append(planeShapeParameter);
		
		return planeShape.toString();
	}
}