
public class Computer extends ElectronicsProduct {
	private static final int GUARANTEE_PERIOD = 24;
	public Computer(String name, double price, int quantity, AgeRestriction ageRestriction) {
		super(name, price, quantity, ageRestriction, GUARANTEE_PERIOD);
	}
	
	@Override
	public double getPrice() {
		double newPrice = 0;
		if(this.getQuantity() > 1000) {
			newPrice = this.getRealPrice() * 0.95;
		} else {
			newPrice = this.getRealPrice();
		}
		
		return newPrice;
	}
}
