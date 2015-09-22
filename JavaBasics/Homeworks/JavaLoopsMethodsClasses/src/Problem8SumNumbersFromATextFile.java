import java.util.Scanner;
import java.io.File;
import java.io.FileNotFoundException;
public class Problem8SumNumbersFromATextFile {
	public static void main(String[] args) throws FileNotFoundException {
		try {
			Scanner textFile = new Scanner(new File("C:/Users/lenovo/Documents/EclipseProjects/JavaLoopsMethodsClasses/src/8input/input.txt"));
			FileReader(textFile);
		}
		catch(FileNotFoundException ex) {
			System.out.println("Error");
		}
	}
	public static void FileReader(Scanner textFile) {
		int sum = 0;
		while(textFile.hasNextInt()) {
			sum += textFile.nextInt();
		}
		System.out.println(sum);
	}
}
