using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class MenusController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetMenus()
		{
			return View();
		}
	}
}
