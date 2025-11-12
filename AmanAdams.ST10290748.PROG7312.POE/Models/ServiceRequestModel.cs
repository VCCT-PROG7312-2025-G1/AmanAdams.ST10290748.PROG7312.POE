

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class ServiceRequestModel
    {
        public string RequestId { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; } 
        public DateTime CreatedAt { get; set; }
    }
}
//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
