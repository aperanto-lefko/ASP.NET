using Microsoft.AspNetCore.Mvc;
using MvcCreditApp.Models;
using System.Diagnostics;
using MvcCreditApp.Models;
using MvcCreditApp.Data;

namespace MvcCreditApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly CreditContext db;

		public HomeController(ILogger<HomeController> logger, CreditContext context)
		{
			_logger = logger;
			db = context;
		}

		public IActionResult Index()
		{
			GiveCredits();
			return View();
		}
		private void GiveCredits()
		{
			var allCredits = db.Credits.ToList<Credit>();
			ViewBag.Credits = allCredits;
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		[HttpGet]
		public ActionResult CreateBid()
		{
			GiveCredits();

			var allBids = db.Bids.ToList<Bid>(); ViewBag.Bids = allBids; return View();
		}
		[HttpPost]
		public ActionResult CreateBid(Bid newBid)
		{
			newBid.bidDate = DateTime.Now;
			// ��������� ����� ������ � ��
			db.Bids.Add(newBid);
			// ��������� � �� ��� ���������
			db.SaveChanges();
			//return "�������, " + newBid.Name + ", �� ����� ������ �����. ���� ������ ����� ����������� � ������� 10 ����."; }
			return RedirectToAction("CreateBid");
		}
        public ActionResult BidSearch(string name)
        {
            var allBids = db.Bids.Where(a => a.CreditHead.Contains(name)).ToList();
            if (allBids.Count == 0)
            {
                return Content("��������� ������ " + name + " �� ������");
                //return HttpNotFound();
            }
            return PartialView(allBids);
        }
    }
}
