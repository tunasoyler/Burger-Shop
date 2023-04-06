﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProfileHome()
        {
            TempData["cookieValue"] = Request.Cookies["IdentityCookie"];
            return View();
        }
    }
}
