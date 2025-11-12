using Microsoft.AspNetCore.Mvc;
using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

public class IssuesController : Controller
{
    private readonly IssueServiceModel _issueService;
    private readonly IssueGraph _issueGraph = new IssueGraph();
    private readonly AppDbContext _context;
 

    public IssuesController(AppDbContext context)
    {
        _context = context;
        var repo = new IssueRepositoryModel(context);
        _issueService = new IssueServiceModel(repo);
    }
    

    [HttpGet]
    public IActionResult Report()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Report(string location, IssueCategory category, string description, IFormFile attachment)
    {
        string filePath = null;

        //Handle optional file upload
        if (attachment != null && attachment.Length > 0)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(attachment.FileName);
            filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                attachment.CopyTo(stream);
            }
        }

        //Save to SQLite DB
        var issue = _issueService.ReportIssue(location, category, description, filePath);

        //Send request ID to Success page
        TempData["RequestId"] = issue.RequestId;

        return RedirectToAction("Success");
    }


    [HttpGet]
    public IActionResult Search()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Search(string requestId)
    {
        if (string.IsNullOrEmpty(requestId))
        {
            TempData["SuccessMessage"] = "Please enter a valid Request ID.";
            return RedirectToAction("Status");
        }

        //Load all issues from DB
        var allIssues = _context.Issues.ToList();

        //Build BST
        var bst = new IssueBST();
        foreach (var issue in allIssues)
        {
            bst.Insert(issue);
        }

        //Search in BST
        var foundIssue = bst.Search(requestId);

        var result = foundIssue != null ? new List<IssueModel> { foundIssue } : new List<IssueModel>();

        if (result.Count == 0)
        {
            TempData["SuccessMessage"] = "No requests found matching the ID.";
        }

        return View("/Views/Status/Status.cshtml", result);
    }

    public IActionResult Success()
    {
        ViewBag.RequestId = TempData["RequestId"];
        return View();
    }


    [HttpPost]
    public IActionResult UpdateStatus(string requestId, string status)
    {
        try
        {
            var issue = _context.Issues.FirstOrDefault(i => i.RequestId == requestId);
            if (issue == null)
            {
                TempData["SuccessMessage"] = "Error: Issue not found.";
                return RedirectToAction("Status");
            }

            issue.Status = status;
            _context.SaveChanges();

            TempData["SuccessMessage"] = $"Status for Request {requestId} updated to '{status}'.";
            return RedirectToAction("Status", "Status");
        }
        catch (Exception ex)
        {
            // Log error 
            TempData["SuccessMessage"] = "Error updating status: " + ex.Message;
            return RedirectToAction("Status");
        }
    }

    public IActionResult GraphView()
    {
        //Load issues and build graph connections
        var issues = _context.Issues.ToList();
        foreach (var issue in issues)
        {
            _issueGraph.AddVertex(issue.RequestId);
        }

        //Example: connect related issues (category-based)
        foreach (var issue1 in issues)
        {
            foreach (var issue2 in issues)
            {
                if (issue1.Category == issue2.Category && issue1.RequestId != issue2.RequestId)
                {
                    _issueGraph.AddEdge(issue1.RequestId, issue2.RequestId);
                }
            }
        }

        ViewBag.AdjacencyList = _issueGraph.GetAdjacencyList();
        return View(issues);
    }
   
}


//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
