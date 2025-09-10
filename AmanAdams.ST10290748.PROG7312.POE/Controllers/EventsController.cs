using Microsoft.AspNetCore.Mvc;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 1 

namespace AmanAdams.ST10290748.PROG7312.POE.Controllers
{
    public class EventsController : Controller
    {
        
            public IActionResult Events()
            {
                ViewData["Title"] = "Local Events And Announcements";
                return View();
            }
        
    }
}
