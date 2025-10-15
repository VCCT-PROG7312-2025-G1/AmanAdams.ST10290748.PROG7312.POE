
// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public enum IssueCategory { Roads, Sanitation, Utilities, Safety, Other }
    public class IssueModel
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Location { get; set; }
        public IssueCategory Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }

        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
