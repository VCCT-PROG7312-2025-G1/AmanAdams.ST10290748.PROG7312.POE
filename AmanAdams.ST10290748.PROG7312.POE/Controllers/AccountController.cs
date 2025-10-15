using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

namespace AmanAdams.ST10290748.PROG7312.POE.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginServiceModel _loginService = new();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (_loginService.ValidateUser(username, password))
            {
                HttpContext.Session.SetString("LoggedInUser", username);
                return RedirectToAction("Events", "Events");
            }

            ViewBag.Error = "Invalid username or password. Please try again.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

     
    }
}

