using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProfileHome()
        {
            return View();
        }
    }
}
