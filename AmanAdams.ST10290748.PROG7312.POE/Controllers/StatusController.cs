using Microsoft.AspNetCore.Mvc;

namespace AmanAdams.ST10290748.PROG7312.POE.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Status()
        {
            ViewData["Title"] = "Service Request Status";
            return View();
        }
    }
}
