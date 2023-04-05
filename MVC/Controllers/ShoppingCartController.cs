using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class ShoppingCartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetShoppingCart()
		{
			return View();
		}
	}
}
