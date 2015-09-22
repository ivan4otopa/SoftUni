package classes.shapes.planeShapes;

import java.util.ArrayList;

import classes.Vertex;
import classes.shapes.PlaneShape;

public class Triangle extends PlaneShape {
	ArrayList<Vertex> vertices = new ArrayList<Vertex>();
	
	public Triangle(ArrayList<Vertex> vertices) {
		super(vertices);
		this.setTriangle(vertices);
	}

    public void setTriangle(ArrayList<Vertex> vertices) {
        this.vertices = vertices;
    }
    
	public double getArea() {
		double sideOne = getTringleSides()[0];
		double sideTwo = getTringleSides()[1];
		double sideThree = getTringleSides()[2];
		
		double halfPerimeter = getPerimeter() / 2;
		
		double area = Math.sqrt(halfPerimeter * (halfPerimeter - sideOne) * (halfPerimeter - sideTwo) * (halfPerimeter - sideThree));
		
		return area;
	}
	
	public double getPerimeter() {
		double sideOne = getTringleSides()[0];
		double sideTwo = getTringleSides()[1];
		double sideThree = getTringleSides()[2];
		
		double perimeter = sideOne + sideTwo + sideThree;
		
		return perimeter;
	}
	
	public double[] getTringleSides() {
		Vertex vertexOne = vertices.get(0);
		Vertex vertexTwo = vertices.get(1);
		Vertex vertexThree = vertices.get(2);
		double sideOne = Math.sqrt(Math.pow((vertexOne.getX() - vertexTwo.getX()), 2) + Math.pow((vertexOne.getY() - vertexTwo.getY()), 2));
		double sideTwo = Math.sqrt(Math.pow((vertexOne.getX() - vertexThree.getX()), 2) + Math.pow((vertexOne.getY() - vertexThree.getY()), 2));
		double sideThree = Math.sqrt(Math.pow((vertexTwo.getX() - vertexThree.getX()), 2) + Math.pow((vertexTwo.getY() - vertexThree.getY()), 2));
		
		double[] triangleSides = new double[3];
		triangleSides[0] = sideOne;
		triangleSides[1] = sideTwo;
		triangleSides[2] = sideThree;
		
		return triangleSides;
	}
}
