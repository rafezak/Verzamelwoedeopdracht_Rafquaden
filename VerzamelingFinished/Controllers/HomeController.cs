using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VerzamelingFinished.Models;

namespace VerzamelingFinished.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Mydecks()
        {
            return View();
        }

        public IActionResult Cards()
        {
            return View();
        }

        public IActionResult GetCoins()
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
