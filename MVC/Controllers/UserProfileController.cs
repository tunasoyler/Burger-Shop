
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Context;

namespace MVC.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;

        public UserProfileController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ProfileHome()
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ProfileHome(AppUser user)
        {
            AppUser _user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                if (user.UserName != null)
                {
                    _user.UserName = user.UserName;
                }
                else
                    ModelState.AddModelError("UpdateUser", "Kullanıcı adı boş geçilemez!");
                if (user.Email != null)
                {
                    _user.Email = user.Email;
                }
                else
                    ModelState.AddModelError("UpdateUser", "E-posta adresi boş geçilemez!");
                if (user.FirstName != null)
                {
                    _user.FirstName = user.FirstName;
                }
                ModelState.AddModelError("UpdateUser", "İsim boş geçilemez!");
                if (user.LastName != null)
                {
                    _user.LastName = user.LastName;
                }
                ModelState.AddModelError("UpdateUser", "Soyisim boş geçilemez!");
                if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                {
                    IdentityResult result = await _userManager.UpdateAsync(_user);
                    if (result.Succeeded)
                        return RedirectToAction("ProfileHome");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("UserNotFound", "Kullanıcı Bulunamadı!");
            return View(user);
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                TempData["Error"] = $"{error.Code}-{error.Description}";
            }
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("GetHome", "Home");
        }
        public async Task<IActionResult> ChangePassword()
        {
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);
            return RedirectToAction("ProfileHome");
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string newPassword,string password)
        {
            AppUser _user = await _userManager.GetUserAsync(HttpContext.User);
            var passwordMatched = await _userManager.CheckPasswordAsync(_user, password);
            if (_user != null)
            {
                if (!string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(_user.PasswordHash))
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(_user, _user.PasswordHash, newPassword);
                    if (result.Succeeded)
                        return RedirectToAction("LogOut");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("UserNotFound", "Kullanıcı Bulunamadı!");
            return RedirectToAction("ProfileHome");
        }
    }
}
