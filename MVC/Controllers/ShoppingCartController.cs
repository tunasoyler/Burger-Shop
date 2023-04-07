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


        private readonly IHttpContextAccessor _httpContextAccessor;

        Order order = new Order();
        CartItemDTO cartItem;

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor, BurgerContext burgerContext)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.burgerContext = burgerContext;

        }


        public IActionResult AddMenuToCart(int id)
        {     
            var item = burgerContext.Menus.Find(id);

            var cartItem = new CartItemDTO
            {
                Name = item.Name,
                MenuId = item.Id,
                Quantity = 1,
                Size = Entity.Enums.Size.Small,
                Price = item.Price,
                Image = item.Image
            };


            HttpContext.Session.SetObject("CartItem", cartItem);
            

            return RedirectToAction("GetShoppingCart");
        }
        public IActionResult AddExtraToCart(int id)
        {

            var item = burgerContext.Extras.Find(id);

            var cartItem = new CartItemDTO
            {
                Name = item.Name,
                ExtraId = item.Id,
                Quantity = 1,
                Price = item.Price,
                Image = item.Image
            };


            HttpContext.Session.SetObject("CartItem", cartItem);

            return RedirectToAction("GetShoppingCart");
        }
        public IActionResult GetShoppingCart()
        {
            List<Extra> extraList = extraManager.GetList();

            var cartList = HttpContext.Session.GetObject<List<CartItemDTO>>("cartList");
            var CartItem = HttpContext.Session.GetObject<CartItemDTO>("CartItem");

            cartList.Add(CartItem);

            HttpContext.Session.SetObject("cartList", cartList);

            ViewBag.cartList1 = cartList;

            return View(extraList);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
