import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class FoodProduct extends Product implements Expirable {
	private Date expirationDate;
	
	public FoodProduct(String name, double price, int quantity, AgeRestriction ageRestriction, String expirationDate) {
		super(name, price, quantity, ageRestriction);
		this.setExpirationDate(expirationDate);
	}
	
	public Date getExpirationDate() {
		return this.expirationDate;
	}
	
	public void setExpirationDate(String expirationDate) {
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
		try {
			this.expirationDate = dateFormat.parse(expirationDate);
		} catch(ParseException pe) {
			System.err.println("Invalid date format.");
		}
	}
	
	@Override
	public double getPrice() {
		long days = getDaysBetweenTwoDates();
		double newPrice = 0;
		if(days <= 15) {
			newPrice = this.getRealPrice() * 0.7;
		} else {
			newPrice = this.getRealPrice();
		}
		
		return newPrice;
	}
	
	public long getDaysBetweenTwoDates() {
		Date dateNow = new Date();
		long differenceBetweenTwoDates = getExpirationDate().getTime() - dateNow.getTime();
		long days = TimeUnit.DAYS.convert(differenceBetweenTwoDates, TimeUnit.MILLISECONDS);
		
		return days;
	}
	
	@Override
	public String toString() {
		StringBuilder foodProduct = new StringBuilder();
		
		foodProduct.append(super.toString());
		

		SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
		
		String foodProductExpirationDate = "; Expiration Date: " + dateFormat.format(this.getExpirationDate());
		foodProduct.append(foodProductExpirationDate);
		
		return foodProduct.toString();
	}
}
