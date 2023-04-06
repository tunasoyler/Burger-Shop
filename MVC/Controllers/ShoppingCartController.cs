using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.Context;
using Newtonsoft.Json;

namespace MVC.Controllers
{
	public class ShoppingCartController : Controller
	{
		IHttpContextAccessor httpContextAccessor;
        BurgerContext burgerContext;

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor, BurgerContext burgerContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.burgerContext = burgerContext;
        }

        public IActionResult AddToCart(int id)
        {

            CookieHelper.AddProductToCart(HttpContext, id, 1);

            return RedirectToAction("GetShoppingCart");
        }

        //public IActionResult RemoveFromCart(int id)
        //{
        //    CookieHelper.RemoveProductFromCart(HttpContext, id, 1);

        //    return RedirectToAction("GetShoppingCart");
        //}

        //public IActionResult ClearCart()
        //{
        //    CookieHelper.ClearCart(HttpContext);

        //    return RedirectToAction("GetShoppingCart");
        //}






        public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetShoppingCart()
		{
			CartDTO cartDTO = new CartDTO();
			//cartDTO = orderManager.GetOrder(cartDTO);
			return View();
		}
	}
}
