using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Context;

namespace MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _usermanager;

        public UserController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }

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
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserVM userVM)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					FirstName = userVM.FirstName,
					LastName = userVM.LastName,
					Email = userVM.Email,
					UserName = userVM.UserName,
				};
				IdentityResult result =await 
					_usermanager.CreateAsync(appUser,userVM.Password);
				if (result.Succeeded)
				{
                    TempData["result"] = "Your registration has been successfully created.";
                    return RedirectToAction("Login");
				}
				else
				{
					foreach(IdentityError error in result.Errors)
					{
						ModelState.AddModelError("UserCreateError", error.Description);
					}
				}
			}
			return View(userVM);
		}
		public IActionResult Reset()
		{
			return View();
		}
	}
}
