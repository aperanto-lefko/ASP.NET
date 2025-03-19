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
			MessageRezult = "Для товара можно определить скидку";
		}
		public void OnPost(string name, decimal? price)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageRezult = "Переданы некорректные данные. Повторите ввод";
				return;
			}
			var result = _ds.CalculateDiscount(price.Value, 18);
			MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
			Product.Price = price;
			Product.Name = name;
		}
		public void OnPostDiscont(string name, decimal? price, double discount)
		{
			Product = new Product();
			var result = _ds.CalculateDiscount(price.Value, discount);
			MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discount} получится {result}";
			Product.Price = price;
			Product.Name = name;
		}

		public void OnPostVAT(string name, decimal? price, double vatRate)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageRezult = "Переданы некорректные данные. Повторите ввод";
				return;
			}
			var totalPrice = _vs.CalculateTotalPriceWithVAT(price.Value, vatRate);
			MessageRezult = $"Для товара {name} с ценой {price} и НДС {vatRate}% итоговая стоимость составит {totalPrice}";
			Product.Price = price;
			Product.Name = name;
		}
	}
}
