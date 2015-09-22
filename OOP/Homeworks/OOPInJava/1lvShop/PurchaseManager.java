import java.util.Date;


public final class PurchaseManager {
	public static void processPurchase(Product product, Customer customer) {
		if(product.getQuantity() <= 0) {
			throw new RuntimeException("Insufficient product amount.");
		}
		
		if(product instanceof FoodProduct) {
			Date dateNow = new Date();
			if(((FoodProduct)product).getExpirationDate().before(dateNow)) {
				throw new RuntimeException("Product has expired.");
			}
		}
		
		if(customer.getBalance() < product.getPrice()) {
			throw new RuntimeException("You do not have enough money to buy this product!");
		}
		
		if(product.getAgeRestriction() == AgeRestriction.TEENAGER && customer.getAge() < 13) {
			throw new RuntimeException("You are too young to buy this product!");
		} else if(product.getAgeRestriction() == AgeRestriction.ADULT && customer.getAge() < 18) {
			throw new RuntimeException("You are too young to buy this product!");
		}
		
		customer.setBalance(customer.getBalance() - product.getPrice());
		product.setQuantity(product.getQuantity() - 1);
	}
}
