using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Context;

namespace MVC.Controllers
{
	public class AdminController : Controller
	{
		private UserManager<AppUser> userManager;
		public AdminController(UserManager<AppUser> _userManager)
		{
			userManager=_userManager;

		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetUser()
		{
			return View(userManager.Users);
		}
	}
}
