using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetOrders()
		{ 
			return View(); 
		}
		public IActionResult Login() 
		{
			return View();
		}
		
	}
}
