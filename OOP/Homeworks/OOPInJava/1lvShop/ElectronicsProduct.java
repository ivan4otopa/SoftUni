
public abstract class ElectronicsProduct extends Product {
	private int guaranteePeriod;
	
	public ElectronicsProduct(String name, double price, int quantity, AgeRestriction ageRestriction, int guaranteePeriod) {
		super(name, price, quantity, ageRestriction);
		this.setGuaranteePeriod(guaranteePeriod);
	}
	
	public int getGuaranteePeriod() {
		return this.guaranteePeriod;
	}
	
	public void setGuaranteePeriod(int guaranteePeriod) {
		if(guaranteePeriod <= 0) {
			throw new IllegalArgumentException("Electronics product guarantee period must be a positive number.");
		}
		
		this.guaranteePeriod = guaranteePeriod;
	}
	
	@Override
	public String toString() {
		StringBuilder electronicsProduct = new StringBuilder();
		
		electronicsProduct.append(super.toString());
		
		String electronicsProductGuaranteePeriod = "; Guarantee period: " + this.getGuaranteePeriod() + " months";
		electronicsProduct.append(electronicsProductGuaranteePeriod);
		
		return electronicsProduct.toString();
	}
}
