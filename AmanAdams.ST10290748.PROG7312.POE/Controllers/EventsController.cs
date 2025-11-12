using AmanAdams.ST10290748.PROG7312.POE.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

public class EventsController : Controller
{
    private readonly EventServiceModel _service;

    public EventsController(EventServiceModel service)
    {
        _service = service;
    }

   
    public IActionResult Events()
    {
        var allEvents = _service.GetAllEvents();

        //Default recommendations (most recent)
        var recommendations = allEvents
            .OrderByDescending(e => e.EventDate)
            .Take(4) 
            .ToList();

        var viewModel = new EventViewModel
        {
            Events = allEvents,
            EventsByCategory = _service.GetEventsByCategory(),
            EventsByDate = _service.GetEventsByDate(),
            UniqueCategories = _service.GetUniqueCategories(),
            UniqueEventDates = _service.GetUniqueDates(),
            PriorityEvents = _service.GetPriorityQueue()
        };

        ViewBag.Recommendations = recommendations;

        return View(viewModel);
    }

    //Add a new event
    [HttpPost]
    public async Task<IActionResult> AddEvent(Event newEvent, IFormFile Photo)
    {

        // Check for date conflict before saving
        if (_service.IsDateConflict(newEvent.EventDate))
        {
            TempData["SearchMessage"] = " An event already exists on this date. Please choose another date.";
            return RedirectToAction("Events");
        } 


        if (Photo != null && Photo.Length > 0)
        {
            var fileName = Path.GetFileName(Photo.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await Photo.CopyToAsync(stream);
            }
            newEvent.PhotoPath = "/uploads/" + fileName;
        }
        else
        {
            newEvent.PhotoPath = "/images/defaultImage.jpg";
        }

        _service.AddEvent(newEvent);

        TempData["SuccessMessage"] = "Event added!";
        return RedirectToAction("Events");
    }

    //Search and show recommendations based on category/date
    public IActionResult Search(string category, DateTime? eventDate)
    {
        var (results, recommendations) = _service.SearchEvents(category, eventDate);

        var viewModel = new EventViewModel
        {
            Events = results,
            EventsByCategory = _service.GetEventsByCategory(),
            EventsByDate = _service.GetEventsByDate(),
            UniqueCategories = _service.GetUniqueCategories(),
            UniqueEventDates = _service.GetUniqueDates(),
            PriorityEvents = _service.GetPriorityQueue()
        };

        ViewBag.Recommendations = recommendations;

        if (results.Count == 0)
            TempData["SearchMessage"] = "No events found for your search.";

        return View("Events", viewModel);
    }

 
}


//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//


