using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;
using WebAppCoreProduct.Models;

namespace WebAppCoreProduct.Pages
{
    public class IndexModel : PageModel
    {
		public Product Product { get; set; }
		public bool IsCorrect { get; set; } = true;
		public string? MessageRezult { get; private set; }
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
			var result = price * (decimal?)0.18;
			MessageRezult = $"��� ������ {name} � ����� {price} ������ ��������� {result}";
			Product.Price = price;
			Product.Name = name;
		}
	}
}
