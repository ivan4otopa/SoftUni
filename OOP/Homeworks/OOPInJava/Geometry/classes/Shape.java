package classes;

import java.util.ArrayList;

public abstract class Shape {
	private ArrayList<Vertex> vertices = new ArrayList<Vertex>();
	
	public Shape(ArrayList<Vertex> vertices) {
		this.setVertices(vertices);
	}
	
	public ArrayList<Vertex> getVertices() {
		return this.vertices;
	}
	
	public void setVertices(ArrayList<Vertex> vertices) {
		this.vertices = vertices;
	}
	
	@Override
	public String toString() {
		StringBuilder shape = new StringBuilder();
		
		for(int i = 0; i < this.getVertices().size(); i++) {
			if(this.vertices.get(i).getZ() == 0) {
				String shapeVerticesCoordinates = "\nVertex " + (i + 1) + " coordinates: X = " + this.vertices.get(i).getX() + " Y = " + 
						this.vertices.get(i).getY();
				
				shape.append(shapeVerticesCoordinates);
			} else {
				String shapeVerticesCoordinates = "\nVertex " + (i + 1) + " coordinates: X = " + this.vertices.get(i).getX() + " Y = " + 
						this.vertices.get(i).getY() + " Z = " + this.vertices.get(i).getZ();
				
				shape.append(shapeVerticesCoordinates);
			}
		}
		
		shape.append("\n");
		return shape.toString();
	}
}
