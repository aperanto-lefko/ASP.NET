namespace WebAppCoreProduct.Services
{
	public class DiscountService:IDiscountService
	{
		public decimal CalculateDiscount(decimal price, double discount)
		{
			return price * (decimal)(discount / 100);
		}
	}
}
