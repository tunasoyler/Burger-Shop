using BLL.Concrete;
using DAL.Context;
using DAL.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using MVC.Extension;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        BurgerContext burgerContext;
        private readonly UserManager<AppUser> _userManager;
        ExtraManager extraManager = new ExtraManager(new EfExtraDal());
        MenuManager menuManager = new MenuManager(new EfMenuDal());
        OrderDetailsManager orderDetailsManager = new OrderDetailsManager(new EfOrderDetailsDal());
        OrderManager orderManager = new OrderManager(new EfOrderDal());


        private readonly IHttpContextAccessor _httpContextAccessor;

        Order order = new Order();
        CartItemDTO cartItem;
        OrderDetails orderDetails;

        public ShoppingCartController(BurgerContext burgerContext, UserManager<AppUser> userManager)
        {
            this.burgerContext = burgerContext;
            _userManager = userManager;
        }



        public IActionResult AddMenuToCart(int id)
        {
            var item = burgerContext.Menus.Find(id);
            var cartList = HttpContext.Session.GetObject<List<CartItemDTO>>("cartList");
            int cartId;
            if (cartList.Count != 0)
            {
                cartId = cartList.Last().Id;
            }
            else
            {
                cartId = 0;
            }

            var cartItem = new CartItemDTO
            {
                Id = cartId + 1,
                Name = item.Name,                
                MenuId = item.Id,
                Quantity = 1,
                Size = Entity.Enums.Size.Small,
                Price = item.Price,
                Image = item.Image,
                State = true
            };


            HttpContext.Session.SetObject("cartItem", cartItem);


            return RedirectToAction("GetShoppingCart");
        }
        public IActionResult AddExtraToCart(int id)
        {

            var item = burgerContext.Extras.Find(id);
            var cartList = HttpContext.Session.GetObject<List<CartItemDTO>>("cartList");
            int cartId;
            if (cartList.Count != 0)
            {
                cartId = cartList.Last().Id;
            }
            else
            {
                cartId = 0;
            }


            var cartItem = new CartItemDTO
            {
                Id = cartId + 1,
                Name = item.Name,
                ExtraId = item.Id,
                Quantity = 1,
                Price = item.Price,
                Image = item.Image,
                State = true
            };


            HttpContext.Session.SetObject("cartItem", cartItem);

            return RedirectToAction("GetShoppingCart");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cartList = HttpContext.Session.GetObject<List<CartItemDTO>>("cartList");
            var removeItem = cartList.FirstOrDefault(x => x.Id == id);

            if (removeItem != null)
            {
                removeItem.State = false;
                HttpContext.Session.SetObject("cartList", cartList);
            }

            return RedirectToAction("GetShoppingCart");
        }
        public IActionResult GetShoppingCart()
        {
            List<Extra> extraList = extraManager.GetList();

            var cartList = HttpContext.Session.GetObject<List<CartItemDTO>>("cartList");
            var CartItem = HttpContext.Session.GetObject<CartItemDTO>("cartItem");

            if (CartItem != null)
            {
                cartList.Add(CartItem);
            }

            HttpContext.Session.SetObject("cartList", cartList);

            ViewBag.cartList1 = cartList.Where(x => x.State == true).ToList();

            HttpContext.Session.Remove("cartItem");

            return View(extraList);
        }

        public async Task<IActionResult> ConfirmCart()
        {
            var confirmedList = HttpContext.Session.GetObject<List<CartItemDTO>>("cartList");
            AppUser appUser = await _userManager.GetUserAsync(HttpContext.User);

            if (appUser == null)
            {
                return RedirectToAction("GetOrders", "UserProfile");
            }
            else
            {
                if (confirmedList.Count() != 0)
                {
                    TempData["result"] = "Siparişiniz onaylandı!";

                    decimal orderTotal = 0;

                    foreach (var item in confirmedList)
                    {
                        if (item.ExtraId != null)
                        {
                            orderDetails = new OrderDetails()
                            {
                                Name = $"{DateTime.Now}",
                                ExtraId = item.ExtraId,
                                Extra = item.Extra,
                                Order = order,
                                OrderId = order.Id,
                                Quantity = item.Quantity,
                                OrderDetailPrice = (decimal)item.Price * item.Quantity
                            };
                            orderTotal += orderDetails.OrderDetailPrice;
                            order.OrderDetails.Add(orderDetails);
                        }
                        if (item.MenuId != null)
                        {
                            orderDetails = new OrderDetails()
                            {
                                Name = $"{DateTime.Now}",
                                MenuId = item.MenuId,
                                Menu = item.Menu,
                                Order = order,
                                OrderId = order.Id,
                                Quantity = item.Quantity,
                                OrderDetailPrice = (decimal)item.Price * item.Quantity
                            };
                            orderTotal += orderDetails.OrderDetailPrice;
                            order.OrderDetails.Add(orderDetails);
                        }
                    }
                    order.AppUserId = appUser.Id;
                    order.AppUser = appUser;
                    //order.Coupon = HttpContext.Session.GetObject<Coupon>("coupon");
                    //order.CouponId = HttpContext.Session.GetObject<int>("couponId");
                    order.OrderTotal = orderTotal;
                    order.Name = $"{appUser.UserName} + {DateTime.Now}";
                    order.State = true;

                    burgerContext.Add(order);
                    burgerContext.SaveChanges();

                    return RedirectToAction("GetOrders", "UserProfile");
                }
                else
                {
                    TempData["result"] = "Sepetiniz Boş!";
                    return RedirectToAction("GetShoppingCart");
                }
            }
        }

        public IActionResult ApplyCoupon()
        {


            return RedirectToAction("GetShoppingCart");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
