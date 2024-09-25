using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hotel.Controllers
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
        public IActionResult Hservice()
        {
            return View();
        }
        public IActionResult Room()
        {
            return View();
        }
        public IActionResult Food()
        {
            return View();
        }
        public IActionResult Spa()
        {
            return View();
        }
        public IActionResult Swimming()
        {
            return View();
        }
        public IActionResult Gym()
        {
            return View();
        }
        public IActionResult Bar()
        {
            return View();
        }

  
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult RoomServiceU()
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