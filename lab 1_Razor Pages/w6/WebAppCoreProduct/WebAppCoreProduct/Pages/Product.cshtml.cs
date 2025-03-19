using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;
using WebAppCoreProduct.Services;

namespace WebAppCoreProduct.Pages
{
	public class ProductModel : PageModel
	{
		private readonly IDiscountService _ds;
		private readonly IVATService _vs;
		public Product Product { get; set; }
		public string? MessageRezult { get; private set; }
		

		public ProductModel(IDiscountService ds, IVATService vs)
		{
			_ds = ds;
			_vs = vs;
		}
		public void OnGet()
		{
			MessageRezult = "��� ������ ����� ���������� ������";
		}
		public void OnPost(string name, decimal? price)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageRezult = "�������� ������������ ������. ��������� ����";
				return;
			}
			var result = _ds.CalculateDiscount(price.Value, 18);
			MessageRezult = $"��� ������ {name} � ����� {price} ������ ��������� {result}";
			Product.Price = price;
			Product.Name = name;
		}
		public void OnPostDiscont(string name, decimal? price, double discount)
		{
			Product = new Product();
			var result = _ds.CalculateDiscount(price.Value, discount);
			MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discount} ��������� {result}";
			Product.Price = price;
			Product.Name = name;
		}

		public void OnPostVAT(string name, decimal? price, double vatRate)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageRezult = "�������� ������������ ������. ��������� ����";
				return;
			}
			var totalPrice = _vs.CalculateTotalPriceWithVAT(price.Value, vatRate);
			MessageRezult = $"��� ������ {name} � ����� {price} � ��� {vatRate}% �������� ��������� �������� {totalPrice}";
			Product.Price = price;
			Product.Name = name;
		}
	}
}
