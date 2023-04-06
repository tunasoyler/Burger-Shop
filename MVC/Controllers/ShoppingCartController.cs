using BLL.Concrete;
using DAL.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Extension;
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
        OrderDetailsManager orderDetailsManager = new OrderDetailsManager(new EfOrderDetailsDal());
        private const string OrderSessionKey = "order";
        private const string OrderDetailsSessionKey = "orderDetails";


        private readonly IHttpContextAccessor _httpContextAccessor;

        Order order = new Order();
        CartItemDTO cartItem = new CartItemDTO();

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor, BurgerContext burgerContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.burgerContext = burgerContext;

        }

        public IActionResult AddToCart(int id)
        {
            var item = burgerContext.Menus.Find(id);



            cartItem.Name = item.Name;
            cartItem.MenuId = item.Id;
            cartItem.Quantity = 1;
            cartItem.Size = Entity.Enums.Size.Small;
            cartItem.Price = item.Price;


            HttpContext.Session.SetObject("CartItem", cartItem);


            return RedirectToAction("GetShoppingCart");
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetShoppingCart()
        {
            List<Extra> extraList = extraManager.GetList();
            var CartItem = HttpContext.Session.GetObject<CartItemDTO>("CartItem");

            List<CartItemDTO> cartList = new List<CartItemDTO>();

            cartList.Add(CartItem);

            ViewBag.cartList1 = cartList;

            return View(extraList);
        }
    }
}
