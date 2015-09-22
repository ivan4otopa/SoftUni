package classes.shapes;

import java.util.ArrayList;

import classes.Shape;
import interfaces.AreaMeasurable;
import interfaces.VolumeMeasurable;
import classes.Vertex;

public abstract class SpaceShape extends Shape implements VolumeMeasurable , AreaMeasurable {
	public SpaceShape(ArrayList<Vertex> vertices) {
		super(vertices);
	}
	
	public abstract double getArea();
	public abstract double getVolume();
	
	@Override
	public String toString() {
		StringBuilder planeShape = new StringBuilder();
		
		String planeShapeType = "Shape Type: " + this.getClass().getName() + "; ";
		planeShape.append(planeShapeType);
		
		planeShape.append(super.toString());
		
		String planeShapeArea = "Area: " + this.getArea() + "; ";
		planeShape.append(planeShapeArea);

		String planeShapeParameter = "Volume: " + this.getVolume() + "; ";
		planeShape.append(planeShapeParameter);
		
		return planeShape.toString();
	}
}
