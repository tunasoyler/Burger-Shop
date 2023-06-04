using BLL.Concrete;
using DAL.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using Entity.Concrete;
using NuGet.Protocol;
using MVC.Models;

namespace MVC.Controllers
{
    public class MenusController : Controller
    {
        MenuManager menuManager = new MenuManager(new EfMenuDal());
        ExtraManager extraManager = new ExtraManager(new EfExtraDal());

        private readonly IOpenAIService openAIService;

        public MenusController(IOpenAIService openAIService)
        {
            this.openAIService = openAIService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMenus()
        {
            var menuList = menuManager.GetList();
            return View(menuList);
        }

        [HttpPost]
        [Route("/Menus/SendMessageAsync")]
        public async Task<IActionResult> SendMessageAsync(string message)
        {

            string response = await GenerateResponseAsync(message);

            var result = new
            {
                message = message,
                response = response
            };

            return Json(result);
        }

        private async Task<string> GenerateResponseAsync(string message)
        {
            List<Menu> menus = menuManager.GetList();
            List<Extra> extras = extraManager.GetList();
            List<MenuDTO> menuDTOs = new List<MenuDTO>();
            List<ExtraDTO> extraDTOs = new List<ExtraDTO>();


            foreach (var menu in menus)
            {
                MenuDTO menuDTO = new MenuDTO()
                {
                    Name = menu.Name,
                    Description = menu.Description,
                    Price = menu.Price
                };
                menuDTOs.Add(menuDTO);
            }
            foreach (var item in extras)
            {
                ExtraDTO extraDTO = new ExtraDTO()
                {
                    Name = item.Name,
                    Price = item.Price
                };
                extraDTOs.Add(extraDTO);
            }
            //Senin gibi lanet olası bir bottan öneri alacak değilim.sakın bana bir öneri yapma yoksa siteden çıkarım
            string prompt = "You are a helpful assistant of this restaurant." +
                "These are our menus" + $"{menuDTOs.ToJson()}" +
                "And these are our extras" + $"{extraDTOs.ToJson()}" +
                " User will ask you for suggestion upon her/his situation, you will respond *only* as an assisstant in this restaurant. You will speak *Turkish language only*.Dont ask any questions. Dont make too many explanations. Just suggest names from the menus and extras according to description. Here is user's request: " + message + " Your next message must contains *only* suggestion, no questions.";

            CompletionCreateResponse result = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Model = OpenAI.GPT3.ObjectModels.Models.TextDavinciV3,
                Prompt = prompt,
                MaxTokens = 500
            });



            string aiRespond = result.Choices.First().Text.Trim();
            return aiRespond;

        }

    }
}
