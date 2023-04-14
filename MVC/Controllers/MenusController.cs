﻿using BLL.Concrete;
using DAL.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using Entity.Concrete;
using NuGet.Protocol;

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

            foreach (var menu in menus)
            {
                menu.Image = null;
            }
            foreach (var item in extras)
            {
                item.Image = null;
            }

            string prompt = "You are a helpful assistant of this restaurant." +
                "These are our menus" + $"{menus.ToJson()}" +
                "And these are our extras" + $"{extras.ToJson()}" +
                " User will ask you for suggestion upon her/his situation, you will respond *only* as an assisstant in this restaurant. You will speak *Turkish language only*.Dont ask any questions. Dont make too many explanations. Just suggest names from the menus and extras according to description. Here is user's request: " + message +" Your next message must contains *only* suggestion, no questions.";

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








//public IActionResult GetMenusAsync()
//{
//    TempData["aiRespond"] = HttpContext.Session.GetString("aiRespond");

//    var menuList = menuManager.GetList();
//    return View(menuList);
//}

//[HttpPost]
//public async Task<string> GetSuggestionFromAI(string request)
//{
//    List<Menu> menus = menuManager.GetList();
//    List<Extra> extras = extraManager.GetList();

//    foreach (var menu in menus)
//    {
//        menu.Image = null;
//    }
//    foreach (var item in extras)
//    {
//        item.Image = null;
//    }


//    string prompt = "You are a helpful assistant." +
//        "These are my menus" + $"{menus.ToJson()}" +
//        "And these are my extras" + $"{extras.ToJson()}" +
//        " I will ask you for suggestion upon my situation, you will respond *only* as an assisstant in this restaurant. My restaurant name is 'Sakura Burger'. You will speak *Turkish language only*.Don't ask any questions. Just suggest something from the menus and extras. Here is my request: " + request;

//    // OpenAI hizmetinden AI yanıtını alın
//    CompletionCreateResponse result = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
//    {
//        Model = OpenAI.GPT3.ObjectModels.Models.TextDavinciV3,
//        Prompt = prompt,
//        MaxTokens = 500,
//    });

//    // AI yanıtını döndürün
//    return result.Choices.First().Text.Trim();
//}

//private async Task<string> GetGpt3Prompt()
//{
//    List<Menu> menus = menuManager.GetList();
//    List<Extra> extras = extraManager.GetList();

//    foreach (var menu in menus)
//    {
//        menu.Image = null;
//    }
//    foreach (var item in extras)
//    {
//        item.Image = null;
//    }



//    string prompt = "You are a helpful assistant." +
//        "These are my menus" + $"{menus.ToJson()}" +
//        "And these are my extras" + $"{extras.ToJson()}" +   
//        " I will ask you for suggestion upon my situation, you will respond *only* as an assisstant in this restaurant. My restaurant name is 'Sakura Burger'. You will speak *Turkish language only*. Here is my request: ";

//    CompletionCreateResponse result = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
//    {

//        Model = OpenAI.GPT3.ObjectModels.Models.TextDavinciV3,
//        Prompt = prompt,
//        MaxTokens = 1000,
//    });


//    return result.Choices.First().Text;
//}


//[HttpPost]
//public async Task<IActionResult> GetSuggestionFromAI(AiSuggestion text)
//{
//    AiSuggestion aiSuggestion = new AiSuggestion();
//    string prompt = await GetGpt3Prompt();

//    CompletionCreateResponse result = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
//    {
//        Model = OpenAI.GPT3.ObjectModels.Models.TextDavinciV3,
//        Prompt = prompt + text.Request,
//        MaxTokens = 1000,
//    });

//    aiSuggestion.Response = result.Choices.First().Text.Trim();

//    TempData["model"] = aiSuggestion.Response;

//    return PartialView();
//}




//public async Task<IActionResult> GetSuggestionFromAI(string request)
//{
//    AiSuggestion aiSuggestion = new AiSuggestion();

//    ChatMessage.FromSystem("You are");


//    CompletionCreateResponse result2 = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
//    {
//        Model = OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo,
//        MaxTokens= 1000,               

//    });

//    aiSuggestion.Response = result2.Choices.First().Text;

//    return View(aiSuggestion);
//}

