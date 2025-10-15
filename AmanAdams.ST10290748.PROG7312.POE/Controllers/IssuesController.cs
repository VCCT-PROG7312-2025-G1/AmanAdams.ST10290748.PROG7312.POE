using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

public class IssuesController : Controller
{
    
    private readonly IssueServiceModel _issueService = new IssueServiceModel();

    [HttpGet]
    public IActionResult Report()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Report(string location, IssueCategory category, string description, IFormFile attachment)
    {
        string filePath = null;

        if (attachment != null && attachment.Length > 0)
        {
            // Choose where to save uploaded files
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            // Create folder if it doesn’t exist
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // Unique filename
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + attachment.FileName;
            filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save file to server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                attachment.CopyTo(stream);
            }
        }

        // Save issue with file path
        _issueService.ReportIssue(location, category, description, filePath);

        return RedirectToAction("Success");
    }


    public IActionResult Success()
    {
        return View();
    }
}
