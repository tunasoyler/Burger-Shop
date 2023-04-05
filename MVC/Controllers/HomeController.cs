using BLL.Concrete;
using DAL.EntityFramework;
using Microsoft.AspNetCore.Mvc;
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
       public IActionResult GetHome()
        {
            var menuList = menuManager.GetList();
            return View(menuList);
        }
    }
}