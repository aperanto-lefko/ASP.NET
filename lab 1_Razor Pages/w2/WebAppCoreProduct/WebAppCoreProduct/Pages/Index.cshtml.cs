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
        public void OnGet(string name, decimal? price)
        {
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
            {
                IsCorrect = false;
                return;
            }
			Product.Price = price;
			Product.Name = name;
		}
    }
}
