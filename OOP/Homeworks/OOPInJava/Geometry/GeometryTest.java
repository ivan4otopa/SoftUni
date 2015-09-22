import interfaces.VolumeMeasurable;

import java.util.ArrayList;
import java.util.stream.Collectors;
import java.util.Comparator;
import java.util.List;

import classes.Shape;
import classes.Vertex;
import classes.shapes.PlaneShape;
import classes.shapes.SpaceShape;
import classes.shapes.planeShapes.Circle;
import classes.shapes.planeShapes.Rectangle;
import classes.shapes.planeShapes.Triangle;
import classes.shapes.spaceShapes.Cuboid;
import classes.shapes.spaceShapes.Sphere;
import classes.shapes.spaceShapes.SquarePyramid;

public class GeometryTest {
	public static void main(String[] args) {
		ArrayList<Vertex> verticesForTriangle = new ArrayList<Vertex>();
		ArrayList<Vertex> verticesForRectangle = new ArrayList<Vertex>();
		ArrayList<Vertex> verticesForCircle = new ArrayList<Vertex>();
		ArrayList<Vertex> verticesForSquarePyramid = new ArrayList<Vertex>();
		ArrayList<Vertex> verticesForCuboid = new ArrayList<Vertex>();
		ArrayList<Vertex> verticesForSphere = new ArrayList<Vertex>();
		
		Vertex vertexForTriangleOne = new Vertex(1, 2);
		Vertex vertexForTriangleTwo = new Vertex(5.2, 4);
		Vertex vertexForTriangleThree = new Vertex(2.1, 2.7);
		Vertex vertexForRectangle = new Vertex(3.3, 6);
		Vertex vertexForCircle = new Vertex(5.4, 3);
		Vertex vertexForSquarePyramid = new Vertex(3.3, 6, 8.2);
		Vertex vertexForCuboid = new Vertex(3.3, 2, 3.7);
		Vertex vertexForSphere = new Vertex(3.3, 7.5, 9.9);
		
		verticesForTriangle.add(vertexForTriangleOne);
		verticesForTriangle.add(vertexForTriangleTwo);
		verticesForTriangle.add(vertexForTriangleThree);
		verticesForRectangle.add(vertexForRectangle);
		verticesForCircle.add(vertexForCircle);
		verticesForSquarePyramid.add(vertexForSquarePyramid);
		verticesForCuboid.add(vertexForCuboid);
		verticesForSphere.add(vertexForSphere);
		
		Triangle triangle = new Triangle(verticesForTriangle);
		Rectangle rectangle = new Rectangle(verticesForRectangle, 4.6, 2.3);
		Circle circle = new Circle(verticesForCircle, 5);
		SquarePyramid squarePyramid = new SquarePyramid(verticesForSquarePyramid, 2.4, 7.2);
		Cuboid cuboid = new Cuboid(verticesForCuboid, 3, 5.5, 7.2);
		Sphere sphere = new Sphere(verticesForSphere, 4);
		
		ArrayList<Shape> shapes = new ArrayList<Shape>();
		shapes.add(triangle);
		shapes.add(rectangle);
		shapes.add(circle);
		shapes.add(squarePyramid);
		shapes.add(cuboid);
		shapes.add(sphere);
		
		for (Shape shape : shapes) {
			System.out.println(shape + "\n");
		}

        List<Shape> shapesByVolume =
        				shapes.stream()
                        .filter(s -> s instanceof VolumeMeasurable)
                        .filter(s -> ((SpaceShape)s).getVolume() > 40)
                        .collect(Collectors.toList());	
        
        for (Shape shape : shapesByVolume) {
			System.out.println(shape + "\n");
		}
        
        Comparator<Shape> perimeterComparator = 
				(Shape s1, Shape s2) -> Double.compare(
						((PlaneShape) s1).getPerimeter(), ((PlaneShape) s1).getPerimeter()
						);
        
        List<Shape> planeShapes =
        		shapes.stream()
        		.filter(s -> s instanceof PlaneShape)
        		.sorted(perimeterComparator)
        		.collect(Collectors.toList());
        
        for (Shape shape : planeShapes) {
			System.out.println(shape + "\n");
		}
	}
}