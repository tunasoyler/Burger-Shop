using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.Context;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {

        ContactManager contactManager = new ContactManager(new EfComplaintSuggestionDal());

        //public ContactController(BurgerContext _db, ContactManager contactManager)
        //{
        //    db = _db;
        //    this.contactManager = contactManager;
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetContact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetContact(ComplaintSuggestion p)
        {
            bool result = contactManager.ContactAdd(p);
            if (result)
            {
                TempData["result"] = "Kayıt Başarılı";
                return RedirectToAction("GetContact");
            }
            else
            {
                TempData["resultError"] = "Kayıt Başarısız.";
                return View(p);
            }
        }




    }
}

