using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;

public class IssuesController : Controller
{
    private readonly IssueServiceModel _service = new();

    [HttpGet]
    public IActionResult Report()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Report(string location, IssueCategory category, string description, IFormFile attachment)
    {
        string? filePath = null;
        if (attachment != null && attachment.Length > 0)
        {
            filePath = Path.Combine("uploads", attachment.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            attachment.CopyTo(stream);
        }

        _service.ReportIssue(location, category, description, filePath ?? "");
        return RedirectToAction("Success");
    }

    public IActionResult Success()
    {
        return View();
    }
}
