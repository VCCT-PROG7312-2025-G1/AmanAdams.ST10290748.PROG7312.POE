using AmanAdams.ST10290748.PROG7312.POE.Models;
using System;
using System.Collections.Generic;
using System.Linq;


// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class EventServiceModel
    {
        private readonly AppDbContext _context;

        public EventServiceModel(AppDbContext context)
        {
            _context = context;
        }

        //Stack for undo
        private Stack<Event> recentEvents = new Stack<Event>();

        //Dictionary to track how often each category is searched
        private static Dictionary<string, int> searchFrequency = new Dictionary<string, int>();

        //Get all events ordered by date
        public List<Event> GetAllEvents()
        {
            return _context.Events.OrderBy(e => e.EventDate).ToList();
        }

        public void AddEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            recentEvents.Push(newEvent);
        }

       

        //Dictionary by category
        public Dictionary<string, List<Event>> GetEventsByCategory()
        {
            return _context.Events
                .GroupBy(e => e.Category)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        //SortedDictionary by date
        public SortedDictionary<DateTime, List<Event>> GetEventsByDate()
        {
            var groupedByDate = _context.Events
                .GroupBy(e => e.EventDate.Date)
                .ToList();

            var sortedDict = new SortedDictionary<DateTime, List<Event>>();
            foreach (var group in groupedByDate)
            {
                sortedDict.Add(group.Key, group.ToList());
            }
            return sortedDict;
        }

        //Unique categories and dates (Sets)
        public HashSet<string> GetUniqueCategories()
        {
            return new HashSet<string>(_context.Events.Select(e => e.Category));
        }

        public HashSet<DateTime> GetUniqueDates()
        {

            return new HashSet<DateTime>(_context.Events.Select(e => e.EventDate.Date));
        }

        
        // Checks if an event already exists on a specific date
        public bool IsDateConflict(DateTime eventDate)
        {
            var uniqueDates = GetUniqueDates(); 
            return uniqueDates.Contains(eventDate.Date);
        }



        //PriorityQueue by date
        public PriorityQueue<Event, DateTime> GetPriorityQueue()
        {
            var pq = new PriorityQueue<Event, DateTime>();
            foreach (var e in _context.Events)
                pq.Enqueue(e, e.EventDate);
            return pq;
        }

        //Enhanced Search + Recommendation Feature
        public (List<Event> Results, List<Event> Recommendations) SearchEvents(string category, DateTime? eventDate)
        {
            var eventsByCategory = GetEventsByCategory();
            List<Event> results = new List<Event>();
            HashSet<string> matchedCategories = new HashSet<string>();

            //Filter by category
            if (!string.IsNullOrEmpty(category))
            {
                foreach (var kvp in eventsByCategory)
                {
                    if (kvp.Key.Contains(category, StringComparison.OrdinalIgnoreCase))
                    {
                        results.AddRange(kvp.Value);
                        matchedCategories.Add(kvp.Key);
                        RecordSearch(kvp.Key); 
                    }
                }
            }
            else
            {
                results = GetAllEvents();
            }

            //Filter by date
            if (eventDate.HasValue)
            {
                DateTime searchDate = eventDate.Value.Date;
                results = results
                    .Where(e => e.EventDate.Date == searchDate)
                    .ToList();
            }

            //If no filters, return all events
            if (string.IsNullOrEmpty(category) && !eventDate.HasValue)
            {
                results = GetAllEvents();
                matchedCategories = new HashSet<string>(results.Select(e => e.Category));
            }

            //Build recommendations
            var recommendations = GetRecommendedEvents(matchedCategories, results, eventDate);

            return (results, recommendations);
        }

        //Track search frequency for trending category recommendations
        private void RecordSearch(string category)
        {
            if (string.IsNullOrEmpty(category)) return;

            if (searchFrequency.ContainsKey(category))
                searchFrequency[category]++;
            else
                searchFrequency[category] = 1;
        }

        //Generate related/trending recommendations (Chatgpt)
        private List<Event> GetRecommendedEvents(HashSet<string> matchedCategories, List<Event> currentResults, DateTime? eventDate)
        {
            var allEvents = _context.Events.ToList();
            List<Event> recommendations = new List<Event>();

            //Recommend same-category events
            recommendations.AddRange(allEvents
                .Where(e => matchedCategories.Contains(e.Category) && !currentResults.Contains(e))
                .Take(4));

            //If searching by date, recommend events within 7 days +/-
            if (eventDate.HasValue)
            {
                recommendations.AddRange(allEvents
                    .Where(e => Math.Abs((e.EventDate - eventDate.Value).TotalDays) <= 7 && !currentResults.Contains(e))
                    .Take(4));
            }

            //If no results, recommend most searched/trending categories
            if (!recommendations.Any() && searchFrequency.Any())
            {
                var topCategory = searchFrequency.OrderByDescending(x => x.Value).First().Key;
                recommendations.AddRange(allEvents
                    .Where(e => e.Category == topCategory && !currentResults.Contains(e))
                    .Take(4));
            }

            return recommendations.Distinct().ToList();
        }
    }
}



//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//



