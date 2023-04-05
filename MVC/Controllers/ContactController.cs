﻿using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.Context;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
       
        ContactManager contactManager = new ContactManager(new EfComplaintSuggestionDal());
        
        //public ContactController(BurgerContext _db, ContactManager contactManager)
        //{
        //    db = _db;
        //    this.contactManager = contactManager;
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
            
            contactManager.ContactAdd(p);
            TempData["result"] = "Your message has been sent successfully.";
            return RedirectToAction("GetContact");
        }


    }
}
