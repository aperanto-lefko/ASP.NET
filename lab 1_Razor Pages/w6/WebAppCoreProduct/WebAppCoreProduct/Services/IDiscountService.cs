namespace WebAppCoreProduct.Services
{
	public interface IDiscountService
	{
		decimal CalculateDiscount(decimal price, double discount);
	}
}
