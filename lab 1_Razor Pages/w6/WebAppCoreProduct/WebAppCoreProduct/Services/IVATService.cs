namespace WebAppCoreProduct.Services
{
	public interface IVATService
	{
		decimal CalculateTotalPriceWithVAT(decimal price, double vatRate);
	}
}
