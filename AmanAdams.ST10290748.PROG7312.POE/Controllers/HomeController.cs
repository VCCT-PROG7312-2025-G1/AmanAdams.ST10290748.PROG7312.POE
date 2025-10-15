using System.Diagnostics;
using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

namespace AmanAdams.ST10290748.PROG7312.POE.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
