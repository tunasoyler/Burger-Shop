using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetPayment()
        { 
            return View(); 
        }

    }
}
