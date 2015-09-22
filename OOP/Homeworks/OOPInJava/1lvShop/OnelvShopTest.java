import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;


public class OnelvShopTest {
	public static void main(String[] args) {
		FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.ADULT, "21.02.2015");
		Customer pecata = new Customer("Pecata", 17, 30.00);
		
		try {
			PurchaseManager.processPurchase(cigars, pecata);
		} catch(RuntimeException re) {
			System.out.println(re.getMessage());
		}
		
		Customer gopeto = new Customer("Gopeto", 18, 0.44);
		
		try {
			PurchaseManager.processPurchase(cigars, gopeto);
		} catch(RuntimeException re) {
			System.out.println(re.getMessage());
		}
		
		FoodProduct FoodProductOne = new FoodProduct("Bread", 2.99, 3, AgeRestriction.NONE, "22.02.2012");
		FoodProduct FoodProductTwo = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.ADULT, "21.02.2015");
		Computer computerOne = new Computer("Lenovo", 1399.00, 1100, AgeRestriction.ADULT);
		Computer computerTwo = new Computer("Toshiba", 1199.00, 35, AgeRestriction.NONE);
		Appliance applianceOne = new Appliance("Vacuum cleaner", 23.59, 14, AgeRestriction.NONE);
		Appliance applianceTwo = new Appliance("Ear cleaner", 1.59, 1, AgeRestriction.TEENAGER);
		
		List<Product> products = new ArrayList<Product>();
		products.add(FoodProductOne);
		products.add(FoodProductTwo);
		products.add(computerOne);
		products.add(computerTwo);
		products.add(applianceOne);
		products.add(applianceTwo);
		
		Product productSoonestExpireDate = 
				products.stream()
				.filter(p -> p instanceof Expirable)
				.map(p -> (Expirable)p)
				.sorted((p1, p2) -> -p1.getExpirationDate().compareTo(p2.getExpirationDate()))
				.map(p -> (Product) p)
				.findFirst()
				.get();
		
		System.out.println(productSoonestExpireDate.getName() + "\n");
				
		List<Product> adultProducts = 
				products.stream()
				.filter(p -> p.getAgeRestriction() == AgeRestriction.ADULT)
				.sorted((p1, p2) -> Double.compare(p1.getPrice(), p2.getPrice()))
				.collect(Collectors.toList());
		
		for (Product product : adultProducts) {
			System.out.println(product);
		}
	}
}
