using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public enum IssueCategory { Roads, Sanitation, Utilities, Safety, Other }

    public class IssueModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  

        [Required]
        public string RequestId { get; set; } = "REQ-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        public string Location { get; set; }
        public IssueCategory Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//

