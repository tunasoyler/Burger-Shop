using BLL.Concrete;
using DAL.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
	public class MenusController : Controller
	{
		MenuManager menuManager = new MenuManager(new EfMenuDal());

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult GetMenus()
		{
			var menuList = menuManager.GetList();
			return View(menuList);
		}
	}
}
