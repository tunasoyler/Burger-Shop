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
            userManager = _userManager;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetUser()
        {
            return View(userManager.Users);
        }

        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("GetUser", "Admin");
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> Update(string id, string email, string password)
        //{
        //    AppUser user = await userManager.FindByIdAsync(id);
        //    if (user != null)
        //    {
        //        if (!string.IsNullOrEmpty(email))
        //        {
        //            user.Email = email;
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("UpdateUser", "Email cannot be empty");
        //        }
        //        if (!string.IsNullOrEmpty(password))
        //            user.PasswordHash = passwordHasher.HashPassword(user, password);
        //        else
        //            ModelState.AddModelError("UpdateUser", "Password cannot be empty");


        //        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        //        {
        //            IdentityResult result = await userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //                return RedirectToAction("Index");
        //            else
        //                Errors(result);
        //        }
        //    }
        //    else
        //        ModelState.AddModelError("UserNotFound", "User Not Fount");
        //    return View(user);
        //}


    }
}
