using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Context;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        ContactManager contactManager = new ContactManager(new EfComplaintSuggestionDal());
        public AdminController(UserManager<AppUser> _userManager, IPasswordHasher<AppUser> _passwordHasher)
        {
            userManager = _userManager;
            passwordHasher = _passwordHasher;

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
        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    user.Email = email;
                }
                else
                {
                    ModelState.AddModelError("UpdateUser", "Email cannot be empty");
                }
                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("UpdateUser", "Password cannot be empty");


                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        TempData["result"] = "Your message has been sent successfully.";
                        return RedirectToAction("GetUser");
                      
                    }
                        
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("UserNotFound", "User Not Fount");
            return View(user);
        }

        public IActionResult GetComplaintSuggestion()
        {
            ComplaintSuggestionVM complaintSuggestionVM = new ComplaintSuggestionVM();
            complaintSuggestionVM.ComplaintSuggestionsList = contactManager.GetList();
            return View(complaintSuggestionVM);
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError($"{error.Code}-{error.Description}", error.Description);
            }
        }
       
        public async Task<IActionResult> DeleteSuggestion(int id)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            ComplaintSuggestion complaintSuggestion =  contactManager.FindById(id);
            if (User != null)
            {
                bool result = contactManager.ContactRemove(complaintSuggestion);
                if (result)
                {
                    TempData["result"] = "Your message has been sent successfully.";
                    return RedirectToAction("GetComplaintSuggestion");
                }
                else
                    TempData["resultError"] = "Your message has been sent successfully.";
            }
            else
                ModelState.AddModelError("ComplaintSuggestionNotFound_Delete", "ComplaintSuggestion Not Found");

            return View("GetComplaintSuggestion");
        }
    }
}
