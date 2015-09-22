import java.util.Date;
import java.util.Scanner;
import java.util.concurrent.TimeUnit;
import java.text.ParseException;
import java.text.SimpleDateFormat;
public class Problem7DaysBetweenTwoDates
{
	public static void main(String[] args) {
	    String expectedPattern = "d-MM-yyyy";
	    SimpleDateFormat formatter = new SimpleDateFormat(expectedPattern);
	    try {
       	    Scanner input = new Scanner(System.in);
		    String inputDate1 = input.nextLine();
		    String inputDate2 = input.nextLine();
		    Date date1 = formatter.parse(inputDate1);
		    Date date2 = formatter.parse(inputDate2);
		    long days = date2.getTime() - date1.getTime();
		    System.out.println(TimeUnit.DAYS.convert(days, TimeUnit.MILLISECONDS));
		}
	    catch (ParseException e) {
	    	e.printStackTrace();
		}
	}
}