using ComicsApp.Models;
using ComicsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ComicsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComicService _comicService;
        public HomeController(ILogger<HomeController> logger, IComicService comicService)
        {
            _logger = logger;
            _comicService = comicService;
        }

        public  IActionResult Index()
        {
            var comics = _comicService.GetAllQueryable();


            return View(comics.ToList());
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}