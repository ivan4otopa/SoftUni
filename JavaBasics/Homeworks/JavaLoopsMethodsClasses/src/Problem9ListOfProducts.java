//Тази не успях да я доизмисля.






import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.LineNumberReader;
import java.util.Scanner;
import java.io.*;
public class Problem9ListOfProducts {
	public static void main(String[] args) throws IOException {
		Scanner textFile = new Scanner(new File("C:/Users/lenovo/Documents/EclipseProjects/JavaLoopsMethodsClasses/src/9input/input.txt"));
		FileReader(textFile);
	    
	}
	public static void FileReader(Scanner textFile) throws IOException {
		LineNumberReader lineNumberReader = new LineNumberReader(new FileReader(new File("C:/Users/lenovo/Documents/EclipseProjects/JavaLoopsMethodsClasses/src/9input/input.txt")));
		long lines = lineNumberReader.skip(Long.MAX_VALUE);
		Product[] product = new Product[(int)lines];
		while(textFile.hasNextLine()) {
			String[] linesArray = new String[(int)lines];
		}
	}
	public class Product {
		public String name;
		public double price;
		public Product(String name, double price) {
			this.name = name;
			this.price = price;
		}
		public void SetName(String newName) {
			name = newName;
		}
		public void SetPrice(double newPrice) {
			price = newPrice;
		}
		public String GetName() {
			return name;
		}
		public double GetPrice() {
			return price;
		}
	}
}
