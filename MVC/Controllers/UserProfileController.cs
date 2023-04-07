
using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Context;

namespace MVC.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        BurgerContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordHasher<AppUser> _passwordHasher;
        OrderDetailVM orderDetailVm = new OrderDetailVM();
        OrderDetailsManager _orderDetailManager = new OrderDetailsManager(new EfOrderDetailsDal());

        public UserProfileController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager, IPasswordHasher<AppUser> passwordHasher, BurgerContext db)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
            _passwordHasher = passwordHasher;
            _db = db;
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
        public async Task<IActionResult> ChangePassword(string newPassword, string password)
        {
            AppUser _user = await _userManager.GetUserAsync(HttpContext.User);
            var passwordMatched = await _userManager.CheckPasswordAsync(_user, password);
            if (passwordMatched)
            {
                IdentityResult result = await _userManager.ChangePasswordAsync(_user, password, newPassword);
                if (result.Succeeded)
                    return RedirectToAction("LogOut");
                else
                    Errors(result);
            }

            else
                ModelState.AddModelError("UserNotFound", "Kullanıcı Bulunamadı!");
            return RedirectToAction("ProfileHome");
        }
        public async Task<IActionResult> GetOrders()
        {
            AppUser _user = await _userManager.GetUserAsync(HttpContext.User);
            orderDetailVm.orders = _db.OrderDetails.Where(x => x.Order.AppUserId == _user.Id).Select(x => new OrderDetailDto()
            {
                Id= x.OrderId,
                MenuImage = x.Menu.Image,
                MenuName = x.Menu.Name,
                ExtraImage = x.Extra.Image,
                ExtraName = x.Extra.Name,
                Status = x.State,
                ModifiedTime = x.ModifiedTime,
                TotalPrice = x.Order.OrderTotal
            }).ToList();
            return View(orderDetailVm);
        }
        public IActionResult EditOrder(int id)
        {
            AppUser _user = await _userManager.GetUserAsync(HttpContext.User);
            orderDetailVm.orderDetails= _db.OrderDetails.FirstOrDefault(x => x.OrderId == id && x.Order.AppUserId == _user.Id);
            return View(orderDetailVm);
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            AppUser _user = await _userManager.GetUserAsync(HttpContext.User);
            OrderDetails orderDetails = _db.OrderDetails.FirstOrDefault(x => x.OrderId == id && x.Order.AppUserId == _user.Id);
            _db.OrderDetails.Remove(orderDetails);
            _db.SaveChanges();
            TempData["result"] = "İşlem Başarıyla Gerçekleştirilmiştir!";
            return RedirectToAction("GetOrders");
        }
    }
}
