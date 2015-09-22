
public abstract class Product implements Buyable {
	private String name;
	private double price;
	private int quantity;
	private AgeRestriction ageRestriction;
	
	public Product(String name, double price, int quantity, AgeRestriction ageRestriction) {
		this.setName(name);
		this.setPrice(price);
		this.setQuantity(quantity);
		this.setAgeRestriction(ageRestriction);
	}
	
	public String getName() {
		return this.name;
	}
	
	public void setName(String name) {
		if(name == "") {
			throw new IllegalArgumentException("Product name cannot be empty.");
		}
		
		this.name = name;
	}
	
	public double getRealPrice() {
		return this.price;
	}
	
	public void setPrice(double price) {
		if(price <= 0) {
			throw new IllegalArgumentException("Product price must be a positive number.");
		}
		
		this.price = price;
	}
	
	public int getQuantity() {
		return this.quantity;
	}
	
	public void setQuantity(int quantity) {
		if(quantity <= 0) {
			throw new IllegalArgumentException("Product quantity must be a positive number.");
		}
		this.quantity = quantity;
	}
	
	public AgeRestriction getAgeRestriction() {
		return this.ageRestriction;
	}
	
	public void setAgeRestriction(AgeRestriction ageRestriction) {
		this.ageRestriction = ageRestriction;
	}
	
	@Override
	public String toString() {
		StringBuilder product = new StringBuilder();
		
		String productType = "Product type: " + this.getClass().getName() + "; ";
		product.append(productType);
		
		String productName = "Name: " + this.getName() + "; ";
		product.append(productName);
		
		String productPrice = "Price: " + this.getPrice() + "; ";
		product.append(productPrice);
		
		String productQuantity = "Quantity: " + this.getQuantity() + "; ";
		product.append(productQuantity);
		
		String productAgeRestriction = "Age restriction: " + this.getAgeRestriction();
		product.append(productAgeRestriction);
		
		return product.toString();
	}
}
