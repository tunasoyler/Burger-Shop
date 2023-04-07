using BLL.Concrete;
using DAL.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using MVC.Extension;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MenuManager menuManager = new MenuManager(new EfMenuDal());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewDto { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        List<CartItemDTO> cartList = new List<CartItemDTO>();

        public IActionResult GetHome()
        {
            HttpContext.Session.SetObject("cartList", cartList);
            var menuList = menuManager.GetList().Take(3).ToList();
            return View(menuList);
        }
    }
}