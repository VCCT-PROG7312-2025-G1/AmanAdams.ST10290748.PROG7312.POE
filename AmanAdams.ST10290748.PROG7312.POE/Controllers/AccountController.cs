using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

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
            // Only Admin and Employee are valid
            if (_loginService.ValidateUser(username, password, out string role))
            {
                HttpContext.Session.SetString("LoggedInUser", username);
                HttpContext.Session.SetString("UserRole", role);


                // Redirect admins to Service Request Status
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Invalid username or password.";
            ViewBag.Error = "Invalid username or password. Please try again.";
                        return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out.";
            return RedirectToAction("Index", "Home");
        }
    }
}

//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//

