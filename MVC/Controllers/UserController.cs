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
                return View(new LoginVM() { ReturnUrl = returnUrl });
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
                    SignInResult result =await _signInManager.PasswordSignInAsync(appUser, loginVM.Password,loginVM.Remember,false);
					if(result.Succeeded)
					{
						if (appUser.Email == "huseyingulerman.1997@gmail.com")
						{
							return RedirectToAction("Index", "Admin");
						}
						return Redirect(loginVM.ReturnUrl ?? "/");
					}
					ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre.");
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
			return View(new ResetPasswordModel());
		}
		[HttpPost]
		public async Task<IActionResult> Reset(ResetPasswordModel password)
		{
			AppUser user = await _usermanager.FindByEmailAsync(password.Email);
			if (user != null)
			{
				string resetToken = await _usermanager.GeneratePasswordResetTokenAsync(user);
				string passwordResetLink = Url.Action("UpdatePassword", "User", new { userId = user.Id, token = resetToken }, HttpContext.Request.Scheme);
				MailHelper.ResetPassword.PasswordSendMail(passwordResetLink);
				ViewBag.state = true;
			}
			else
			{
				ViewBag.state = false;
			}
			return View(password);
		}
		public IActionResult UpdatePassword(string userId,string token)
		{
			TempData["userId"]=userId;
			TempData["token"]=token;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdatePassword([Bind("NewPassword")] ResetPasswordModel model)
		{
			string token = TempData["token"].ToString();
			string userId = TempData["userId"].ToString();
			AppUser user=await _usermanager.FindByIdAsync(userId);
			if(user != null)
			{
				IdentityResult result = await _usermanager.ResetPasswordAsync(user, token, model.NewPassword);
				if(result.Succeeded)
				{
					await _usermanager.UpdateSecurityStampAsync(user);
					TempData["Success"] = "Başarıyla güncellenmiştir.";
				}
			}
			else
			{
				ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı.");
			}
			return View();
		}
	}
}
