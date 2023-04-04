using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetAbout()
		{
			return View();
		}
	}
}
