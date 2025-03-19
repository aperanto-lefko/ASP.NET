namespace WebAppCoreProduct.Services
{
	public class VATService:IVATService
	{
		public decimal CalculateTotalPriceWithVAT(decimal price, double vatRate)
		{
			var vatAmount = price * (decimal)(vatRate / 100);
			return price + vatAmount;
		}
	}
}
