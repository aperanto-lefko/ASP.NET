using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
		public Product Product { get; set; }
		public string? MessageRezult { get; private set; }
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
			var result = price * (decimal?)0.18;
			MessageRezult = $"Для товара {name} с ценой {price} скидка получится {result}";
			Product.Price = price;
			Product.Name = name;
		}
		public void OnPostDiscont(string name, decimal? price, double discont)
		{
			Product = new Product();
			var result = price * (decimal?)discont / 100;
			MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont} получится {result}";
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
            var vatAmount = price * (decimal?)vatRate / 100;
            var totalPrice = price + vatAmount;
            MessageRezult = $"Для товара {name} с ценой {price} и НДС {vatRate}% итоговая стоимость составит {totalPrice}";
            Product.Price = price;
            Product.Name = name;
        }
    }
}
