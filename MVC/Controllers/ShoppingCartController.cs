using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
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
		ExtraManager extraManager = new ExtraManager(new EfExtraDal());
		MenuManager menuManager = new MenuManager(new EfMenuDal());
		OrderManager orderManager = new OrderManager(new EfOrderDal());

		Order order = new Order();
		OrderDetails orderDetail = new OrderDetails();

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor, BurgerContext burgerContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.burgerContext = burgerContext;
			
        }

        public IActionResult AddToCart(int id)
        {
						
			orderDetail.MenuId = id;
			orderDetail.Quantity = 1;
			orderDetail.Size = Entity.Enums.Size.Small;

			orderManager.Add(orderDetail);

            return RedirectToAction("GetShoppingCart");
        }


        public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetShoppingCart()
		{
			List<Extra> extraList = extraManager.GetList();
			//CartDTO cartDTO = new CartDTO();
			//cartDTO = orderManager.GetOrder(cartDTO);
			return View(extraList);
		}
	}
}
