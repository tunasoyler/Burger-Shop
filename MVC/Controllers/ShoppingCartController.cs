using BLL.Concrete;
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
		ExtraManager extraManager;

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor, BurgerContext burgerContext,ExtraManager extraManager)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.burgerContext = burgerContext;
			this.extraManager = extraManager;
        }
        public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetShoppingCart()
		{
			var extraList = extraManager.GetList();
			//CartDTO cartDTO = new CartDTO();
			//cartDTO = orderManager.GetOrder(cartDTO);
			return View(extraList);
		}
	}
}
