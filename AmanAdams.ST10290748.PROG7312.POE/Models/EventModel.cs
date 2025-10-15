// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

namespace AmanAdams.ST10290748.PROG7312.POE.Models

{
    public class Event
    {
        public int Id { get; set; }  // Primary key
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }  // "Event" or "Announcement"
        public DateTime EventDate { get; set; }
        public string PhotoPath { get; set; } 
                                                // Path to uploaded photo
    }


}
