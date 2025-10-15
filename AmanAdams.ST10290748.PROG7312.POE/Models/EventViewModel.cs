using System;
using System.Collections.Generic;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 2 

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class EventViewModel
    {
        // All events (for main display)
        public List<Event> Events { get; set; } = new List<Event>();

        // Stack for recently added events 
        public Stack<Event> RecentEvents { get; set; } = new Stack<Event>();

        // Queue for upcoming events in chronological order
        public Queue<Event> UpcomingEvents { get; set; } = new Queue<Event>();

        // PriorityQueue for events prioritized by date (earliest first)
        public PriorityQueue<Event, DateTime> PriorityEvents { get; set; } = new PriorityQueue<Event, DateTime>();

        // Dictionary to quickly access events by category
        public Dictionary<string, List<Event>> EventsByCategory { get; set; } = new Dictionary<string, List<Event>>();

        // SortedDictionary to access events by date
        public SortedDictionary<DateTime, List<Event>> EventsByDate { get; set; } = new SortedDictionary<DateTime, List<Event>>();

        // Sets for unique categories and dates
        public HashSet<string> UniqueCategories { get; set; } = new HashSet<string>();
        public HashSet<DateTime> UniqueEventDates { get; set; } = new HashSet<DateTime>();

        // Recommendations (optional)
        public List<Event> RecommendedEvents { get; set; } = new List<Event>();
    }
}


