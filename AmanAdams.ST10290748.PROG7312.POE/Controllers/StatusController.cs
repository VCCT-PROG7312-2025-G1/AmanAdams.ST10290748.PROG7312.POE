using AmanAdams.ST10290748.PROG7312.POE;
using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

public class StatusController : Controller
{
    private readonly AppDbContext _context;

    //Constructor injection
    public StatusController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Status()
    {
        //Load all issues from DB
        var allIssues = _context.Issues.ToList();

        //Use IssueHeap (min-heap) to organize by CreatedAt()
        var heap = new IssueHeap();
        foreach (var issue in allIssues)
        {
            heap.Insert(issue);
        }

        // Extract all issues from the heap
        var sortedIssues = new List<IssueModel>();
        IssueModel maxIssue;
        while ((maxIssue = heap.PopMax()) != null)
        {
            sortedIssues.Add(maxIssue);
        }

        // Reverse so the oldest appear first
        sortedIssues.Reverse();

        // Pass the sorted issues to your Status view
        return View("/Views/Status/Status.cshtml", sortedIssues);

    }
}
//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
