package schoolsystem;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.security.auth.Subject;

import org.omg.CORBA.portable.ValueBase;

public class SchoolSystem {
	public static void main(String[] args) {
		Scanner inputReader = new Scanner(System.in);
		Map<String, TreeMap<String, ArrayList<Integer>>> students = new TreeMap<String, TreeMap<String, ArrayList<Integer>>>();
		
		int numberOfRows = Integer.parseInt(inputReader.nextLine());
		
		for (int i = 0; i < numberOfRows; i++) {
			String[] parts = inputReader.nextLine().split(" ");
			
			String name = parts[0] + " " + parts[1];
			String subject = parts[2];
			int grade = Integer.parseInt(parts[3]);
			
			TreeMap<String, ArrayList<Integer>> subjects = new TreeMap<String, ArrayList<Integer>>();
			
			if (students.containsKey(name)) {
				subjects = students.get(name);
				
				if (!subjects.containsKey(subject)) {
					subjects.put(subject, new ArrayList<Integer>());
				}
				
				subjects.get(subject).add(grade);
			} else {
				ArrayList<Integer> grades = new ArrayList<>();
				grades.add(grade);
				subjects.put(subject, grades);
				students.put(name, subjects);
			}
		}
		
		for (Entry<String, TreeMap<String, ArrayList<Integer>>> entry : students.entrySet()) {
			String studentName = entry.getKey();
			
			TreeMap<String, ArrayList<Integer>> subjects = entry.getValue();
			
			String output = studentName + ": [";

			for (Entry<String, ArrayList<Integer>> subject : subjects.entrySet()) {
				String subjectName = subject.getKey();
				ArrayList<Integer> grades = subject.getValue();
				output += subjectName + " - " + String.format("%.2f", average(grades)) + ", ";
			}
			
			output = output.substring(0, output.length() - 2) + ']';
			
			System.out.println(output);
		}
	}
	
	static double average(ArrayList<Integer> numbers) {
		int sum = 0;
		
		for (Integer number : numbers) {
			sum += number;
		}
		
		return (double)sum / numbers.size();
	}
}
