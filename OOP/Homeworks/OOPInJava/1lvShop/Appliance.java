
public class Appliance extends ElectronicsProduct {
	private static final int GUARANTEE_PERIOD = 6;
	public Appliance(String name, double price, int quantity, AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, GUARANTEE_PERIOD);
	}
	
	@Override
	public double getPrice() {
		double newPrice = 0;
		if(this.getQuantity() < 50) {
			newPrice = this.getRealPrice() * 1.05;
		} else {
			newPrice = this.getRealPrice();
		}
		
		return newPrice;
	}
}
