using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Context;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _usermanager;
		private readonly SignInManager<AppUser> _signInManager;
		HttpCookie
		

        public UserController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetOrders()
		{ 
			return View(); 
		}
		public IActionResult Login(string returnUrl)
		{
			returnUrl = returnUrl is null ? "/Home/GetHome" : returnUrl;
			return View(new LoginVM() { ReturnUrl=returnUrl});
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginVM loginVM)
		{
			if(ModelState.IsValid)
			{
				AppUser appUser = await _usermanager.FindByEmailAsync(loginVM.Email);
				if(appUser != null)
				{
					await _signInManager.SignOutAsync();
                    SignInResult result =await _signInManager.PasswordSignInAsync(appUser, loginVM.Password,false,false);
					if(result.Succeeded)
					{
						
						CookieOptions option = new CookieOptions();
						option.Expires=DateTime.Now.AddMinutes(30);
						Response.Cookies.Append((Cookie_Key, loginVM, option);
						return Redirect(loginVM.ReturnUrl ?? "/");
					}
					ModelState.AddModelError("", "Wrong Credantion Information!");
				}
			}
			return View(loginVM);
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
					Errors(result);
				}
			}
			return View(userVM);
		}

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                TempData["Error"] = $"{error.Code}-{error.Description}";
            }
        }

        public IActionResult Reset()
		{
			return View();
		}
	}
}
