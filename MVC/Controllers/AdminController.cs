using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;
using MVC.Models.Context;
using System.Web;


namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;
        ContactManager contactManager = new ContactManager(new EfComplaintSuggestionDal());
        CouponManager couponManager = new CouponManager(new EfCouponDal());
        ExtraManager extraManager = new ExtraManager(new EfExtraDal());
        ExtraCategoryManager extracategoryManager = new ExtraCategoryManager(new EfExtraCategoryDal());
        MenuManager menuManager = new MenuManager(new EfMenuDal());
        OrderManager orderManager = new OrderManager(new EfOrderDal());
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


        public IActionResult DeleteSuggestion(int id)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            ComplaintSuggestion complaintSuggestion = contactManager.FindById(id);
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
        public IActionResult GetCoupon()
        {
            CouponVM couponVM = new CouponVM();
            couponVM.CouponList = couponManager.GetList();
            return View(couponVM);
        }
        public IActionResult CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCoupon(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                Coupon Coupon = new Coupon()
                {
                    Name = coupon.Name,
                    CouponCode = coupon.CouponCode,
                    State = coupon.State
                };
                bool result = couponManager.CouponAdd(coupon);
                if (result)
                {
                    TempData["result"] = "Your create has been  successfully.";
                    return RedirectToAction("GetCoupon");
                }
                else
                {
                    TempData["resultError"] = "Your create has been not successfully.";
                }

            }
            return View(coupon);
        }
        public IActionResult UpdateCoupon(int id)
        {
            Coupon coupon = couponManager.FindById(id);
            if (coupon != null)
            {
                return View(coupon);
            }
            else
            {
                return RedirectToAction("GetCoupon", "Admin");
            }
        }
        [HttpPost]
        public IActionResult UpdateCoupon(int id, string name, string couponcode, bool state)
        {
            Coupon coupon = couponManager.FindById(id);
            if (coupon != null)
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(couponcode))
                {
                    coupon.Name = name;
                    coupon.CouponCode = couponcode;
                    coupon.State = state;
                }
                else
                {
                    ModelState.AddModelError("UdateCoupon", "Kupon ismi ve kupon kodu boş geçilemez");
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(couponcode))
                {
                    bool result = couponManager.CouponUpdate(coupon);
                    if (result)
                    {
                        TempData["result"] = "Kayıt Başarılı.";
                        return RedirectToAction("GetCoupon");

                    }

                    else
                        TempData["resultError"] = "Kayıt Başarısız.";
                }
            }
            else
                ModelState.AddModelError("CouponNotFound", "Kupon Bulunamadı.");
            return View(coupon);
        }
        public IActionResult DeleteCoupon(int id)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            Coupon coupon = couponManager.FindById(id);
            if (coupon != null)
            {
                bool result = couponManager.CouponRemove(coupon);
                if (result)
                {
                    TempData["result"] = "Silme İşlemi Başarılı.";
                    return RedirectToAction("GetCoupon");
                }
                else
                    TempData["resultError"] = "Silme İşlemi Başarısız.";
            }
            else
                ModelState.AddModelError("CouponNotFound_Delete", "Kupon Bulunamadı.");

            return View("GetCoupon");
        }







        public IActionResult GetExtra()
        {

            ExtraVM extraVM = new ExtraVM();
            extraVM.Extras = extraManager.GetList();
            return View(extraVM);
        }
        public IActionResult CreateExtra()
        {
            ExtraVM extraVM = new ExtraVM();
            extraVM.ExtraCategoryForDropDown = extraManager.FillExtraCategory();
            return View(extraVM);
        }

        [HttpPost]
        public IActionResult CreateExtra(ExtraVM extraVm, IFormFile imageFile)
        {
            Extra extra = new Extra();
            extra = extraVm.ExtraDb;
            //if (ModelState.IsValid)
            //{

                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        extra.Image = ms.ToArray();
                    }
                }
                else
                {
                    // Varsayılan boş fotoğrafı kullanmak için önceden belirlediğiniz yol veya dosya adını kullanın
                    string defaultImagePath = /*@"~/dashmin-1.0.0/img/bos.jpg";*/@"C:\Users\SELİN\Source\Repos\MvcNotları\Uygulamalar\MvcBurgerProject1\MVC\wwwroot\dashmin-1.0.0\img\bos.jpg";

                    byte[] defaultImage = System.IO.File.ReadAllBytes(defaultImagePath);
                    extra.Image = defaultImage;
                }

                bool result = extraManager.ExtraAdd(extraVm.ExtraDb);
                if (result)
                {
                    TempData["result"] = "Kayıt Başarılı.";
                    return RedirectToAction("GetExtra");
                }
                else
                {
                    TempData["resultError"] = "Kayıt Başarısız.";
                    return RedirectToAction("GetExtra");
                }
            //}
            //else
            //{
            //    ModelState.AddModelError("CreateExtra", "Extra ismi,Extra Fiyatı ve Extra Kategorisi boş geçilemez");
            //    extraVm.ExtraCategoryForDropDown = extraManager.FillExtraCategory();
            //    return View(extraVm);
            //}



        }



        public IActionResult UpdateExtra(int id)
        {
            Extra extra = extraManager.FindById(id);
            ExtraVM extraVM = new ExtraVM();
            extraVM.ExtraDb = extra;
            if (extraVM != null)
            {
                extraVM.ExtraCategoryForDropDown = extraManager.FillExtraCategory();
                return View(extraVM);
            }
            else
            {
                return RedirectToAction("GetExtra", "Admin");
            }
        }
        [HttpPost]
        public IActionResult UpdateExtra(int id, ExtraVM extraVM, IFormFile imageFile)
        {
            Extra extra = extraManager.FindById(id);
            if (extra != null)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        imageFile.CopyTo(stream);
                        extra.Image = stream.ToArray();
                    }
                }
                else
                {
                    // Varsayılan boş fotoğrafı kullanmak için önceden belirlediğiniz yol veya dosya adını kullanın
                    string defaultImagePath = /*@"~/dashmin-1.0.0/img/bos.jpg";*/@"C:\Users\SELİN\Source\Repos\MvcNotları\Uygulamalar\MvcBurgerProject1\MVC\wwwroot\dashmin-1.0.0\img\bos.jpg";

                    byte[] defaultImage = System.IO.File.ReadAllBytes(defaultImagePath);
                    extra.Image = defaultImage;
                }

                if (!string.IsNullOrEmpty(extraVM.ExtraDb.Name) && !string.IsNullOrEmpty(extraVM.ExtraDb.Price.ToString()) && !string.IsNullOrEmpty(extraVM.ExtraDb.ExtraCategoryId.ToString()))
                {
                    extra.Name = extraVM.ExtraDb.Name;
                    extra.ExtraCategoryId = extraVM.ExtraDb.ExtraCategoryId;
                    extra.Price = extraVM.ExtraDb.Price;
                    extra.Description = extraVM.ExtraDb.Description;

                    extra.State = extraVM.ExtraDb.State;
                }
                else
                {
                    ModelState.AddModelError("UdateExtra", "Extra ismi,Extra Fiyatı ve Extra Kategorisi boş geçilemez");
                }

                if (!string.IsNullOrEmpty(extraVM.ExtraDb.Name) && !string.IsNullOrEmpty(extraVM.ExtraDb.Price.ToString()) && !string.IsNullOrEmpty(extraVM.ExtraDb.ExtraCategoryId.ToString()))
                {
                    bool result = extraManager.ExtraUpdate(extra);
                    if (result)
                    {
                        TempData["result"] = "Kayıt Başarılı.";
                        return RedirectToAction("GetExtra");

                    }

                    else
                        TempData["resultError"] = "Kayıt Başarısız.";
                }
            }
            else
                ModelState.AddModelError("ExtraNotFound", "Kupon Bulunamadı.");
            return View(extra);
        }
        public IActionResult DeleteExtra(int id)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            Extra extra = extraManager.FindById(id);
            if (extra != null)
            {
                bool result = extraManager.ExtraRemove(extra);
                if (result)
                {
                    TempData["result"] = "Silme İşlemi Başarılı.";
                    return RedirectToAction("GetExtra");
                }
                else
                    TempData["resultError"] = "Silme İşlemi Başarısız.";
            }
            else
                ModelState.AddModelError("ExtraNotFound_Delete", "Extra Bulunamadı.");

            return View("GetExtra");
        }







        public IActionResult GetExtraCategory()
        {
            ExtraCategoryVM extraCategoryVM = new ExtraCategoryVM();
            extraCategoryVM.ExtraCategoryList = extracategoryManager.GetList();
            return View(extraCategoryVM);
        }
        public IActionResult CreateExtraCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExtraCategory(ExtraCategory extraCategory)
        {
            if (ModelState.IsValid)
            {

                bool result = extracategoryManager.ExtraCategoryAdd(extraCategory);
                if (result)
                {
                    TempData["result"] = "Kayıt İşlemi Başarılı.";
                    return RedirectToAction("GetExtraCategory");
                }
                else
                {
                    TempData["resultError"] = "Kayıt İşlemi Başarısız.";
                }

            }
            return View(extraCategory);
        }
        public IActionResult UpdateExtraCategory(int id)
        {
            ExtraCategory extraCategory = extracategoryManager.FindById(id);
            if (extraCategory != null)
            {
                return View(extraCategory);
            }
            else
            {
                return RedirectToAction("GetExtraCategory", "Admin");
            }
        }
        [HttpPost]
        public IActionResult UpdateExtraCategory(int id, string name, string description, bool state)
        {
            ExtraCategory extraCategory = extracategoryManager.FindById(id);
            if (extraCategory != null)
            {
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
                {
                    extraCategory.Name = name;
                    extraCategory.Description = description;
                    extraCategory.State = state;
                }
                else
                {
                    ModelState.AddModelError("UdateExtraCategory", "Kategory ismi ve Kategori açıklamsı boş geçilemez");
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
                {
                    bool result = extracategoryManager.ExtraCategoryUpdate(extraCategory);
                    if (result)
                    {
                        TempData["result"] = "Kayıt Başarılı.";
                        return RedirectToAction("GetExtraCategory");

                    }

                    else
                        TempData["resultError"] = "Kayıt Başarısız.";
                }
            }
            else
                ModelState.AddModelError("ExtraCategoryNotFound", "Kategori Bulunamadı.");
            return View(extraCategory);
        }
        public IActionResult DeleteExtraCategory(int id)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            ExtraCategory extraCategory = extracategoryManager.FindById(id);
            if (extraCategory != null)
            {
                bool result = extracategoryManager.ExtraCategoryRemove(extraCategory);
                if (result)
                {
                    TempData["result"] = "Silme İşlemi Başarılı.";
                    return RedirectToAction("GetExtraCategory");
                }
                else
                    TempData["resultError"] = "Silme İşlemi Başarısız.";
            }
            else
                ModelState.AddModelError("ExtraCategoryNotFound_Delete", "Kategori Bulunamadı.");

            return View("GetExtraCategory");
        }




        public IActionResult GetMenu()
        {
            MenuVM menuVM = new MenuVM();
            menuVM.MenuList = menuManager.GetList();
            return View(menuVM);
        }
        public IActionResult CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(Menu menu, IFormFile imageFile)
        {

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        imageFile.CopyTo(ms);
                        menu.Image = ms.ToArray();
                    }
                }
                else
                {
                    // Varsayılan boş fotoğrafı kullanmak için önceden belirlediğiniz yol veya dosya adını kullanın
                    string defaultImagePath = /*@"~/dashmin-1.0.0/img/bos.jpg";*/@"C:\Users\SELİN\Source\Repos\MvcNotları\Uygulamalar\MvcBurgerProject1\MVC\wwwroot\dashmin-1.0.0\img\bos.jpg";

                    byte[] defaultImage = System.IO.File.ReadAllBytes(defaultImagePath);
                    menu.Image = defaultImage;
                }
                bool result = menuManager.MenuAdd(menu);
                if (result)
                {
                    TempData["result"] = "Kayıt İşlemi Başarılı.";
                    return RedirectToAction("GetMenu");
                }
                else
                {
                    TempData["resultError"] = "Kayıt İşlemi Başarısız.";
                }
            }
            return View(menu);
        }
        public IActionResult UpdateMenu(int id)
        {
            Menu menu = menuManager.FindById(id);
            if (menu != null)
            {
                return View(menu);
            }
            else
            {
                return RedirectToAction("GetMenu", "Admin");
            }
        }
        [HttpPost]
        public IActionResult UpdateMenu(int id, string name, string description, IFormFile imageFile, decimal price, string menucategory, bool state)
        {
            Menu menu = menuManager.FindById(id);
            if (menu != null)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        imageFile.CopyTo(stream);
                        menu.Image = stream.ToArray();
                    }
                }
                else
                {
                    // Varsayılan boş fotoğrafı kullanmak için önceden belirlediğiniz yol veya dosya adını kullanın
                    string defaultImagePath = /*@"~/dashmin-1.0.0/img/bos.jpg";*/@"C:\Users\SELİN\Source\Repos\MvcNotları\Uygulamalar\MvcBurgerProject1\MVC\wwwroot\dashmin-1.0.0\img\bos.jpg";

                    byte[] defaultImage = System.IO.File.ReadAllBytes(defaultImagePath);
                    menu.Image = defaultImage;
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(menucategory))
                {
                    menu.Name = name;
                    menu.Description = description;
                    menu.Price = price;
                    menu.MenuCategory = menucategory;
                    menu.State = state;
                }
                else
                {
                    ModelState.AddModelError("UdateMenu", "Menu İsmi,Menu Açıklaması ve Manu Kategorisi boş geçilemez");
                }

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(menucategory))
                {
                    bool result = menuManager.MenuUpdate(menu);
                    if (result)
                    {
                        TempData["result"] = "Kayıt Başarılı.";
                        return RedirectToAction("Getmenu");

                    }

                    else
                        TempData["resultError"] = "Kayıt Başarısız.";
                }
            }
            else
                ModelState.AddModelError("MenuNotFound", "Menu Bulunamadı.");
            return View(menu);
        }
        public IActionResult DeleteMenu(int id)
        {
            //AppUser user = await userManager.FindByIdAsync(id);
            Menu menu = menuManager.FindById(id);
            if (menu != null)
            {
                bool result = menuManager.MenuRemove(menu);
                if (result)
                {
                    TempData["result"] = "Silme İşlemi Başarılı.";
                    return RedirectToAction("GetMenu");
                }
                else
                    TempData["resultError"] = "Silme İşlemi Başarısız.";
            }
            else
                ModelState.AddModelError("MenuNotFound_Delete", "Menü Bulunamadı.");

            return View("GetMenu");
        }




        public IActionResult GetActiveOrder()
        {//Id
            //Name
            //AppUserId
            //CreatedTime
            //State
            //CouponId
            //OrderTotal
            //MenuVM menuVM = new MenuVM();
            //menuVM.MenuList = menuManager.GetList();
            BurgerContext _db = new BurgerContext();
            OrderVM orderVM = new OrderVM();
            orderVM.OrderList = _db.Orders.Where(x => x.State == true).Select(x => new OrderDto()
            {
                Id = x.Id,
                FirstName = x.AppUser.FirstName,
                LastName = x.AppUser.LastName,
                CreatedTime = x.CreatedTime,
                State = x.State,
                CouponName = x.Coupon.Name,
                OrderTotal = x.OrderTotal

            }).ToList();



            return View(orderVM);
        }


        public IActionResult UpdateOrder(int id)
        {
            Order order = orderManager.FindById(id);
            if (order != null)
            {
                return View(order);
            }
            else
            {
                return RedirectToAction("GetActiveOrder", "Admin");
            }
        }
        [HttpPost]
        public IActionResult UpdateOrder(int id, Order Order)
        {
            Order order = orderManager.FindById(id);
            if (order != null)
            {


                if (Order != null)
                {
                    order.AppUserId = Order.AppUserId;
                    order.CreatedTime = Order.CreatedTime;
                    order.State = Order.State;
                    order.OrderTotal = Order.OrderTotal;
                }
                else
                {
                    ModelState.AddModelError("UpdateActiveOrder", "Menu İsmi,Menu Açıklaması ve Manu Kategorisi boş geçilemez");
                }

                if (Order != null)
                {
                    bool result = orderManager.OrderUpdate(order);
                    if (result)
                    {
                        TempData["result"] = "Kayıt Başarılı.";
                        return RedirectToAction("GetActiveOrder");

                    }

                    else
                        TempData["resultError"] = "Kayıt Başarısız.";
                }
            }
            else
                ModelState.AddModelError("ActiveOrderNotFound", "Sipariş Bulunamadı.");
            return View(Order);
        }



        public IActionResult GetAllOrder()
        {
            BurgerContext _db = new BurgerContext();
            OrderVM orderVM = new OrderVM();
            orderVM.OrderList = _db.Orders.Select(x => new OrderDto()
            {
                Id = x.Id,
                FirstName = x.AppUser.FirstName,
                LastName = x.AppUser.LastName,
                CreatedTime = x.CreatedTime,
                State = x.State,
                CouponName = x.Coupon.Name,
                OrderTotal = x.OrderTotal

            }).ToList();



            return View(orderVM);
        }










        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError($"{error.Code}-{error.Description}", error.Description);
            }
        }
    }
}
