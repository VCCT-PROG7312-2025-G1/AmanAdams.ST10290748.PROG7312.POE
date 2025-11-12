using System.Collections;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class CategoryRepositoryModel
    {
        public static readonly Hashtable Categories = new()
        {
            { IssueCategory.Roads, "Road maintenance, potholes, traffic signals" },
            { IssueCategory.Sanitation, "Waste collection, sewage, drainage" },
            { IssueCategory.Utilities, "Water, electricity, public lighting" },
            { IssueCategory.Safety, "Crime reports, street safety issues" },
            { IssueCategory.Other, "General or uncategorised issues" }
        };
    }
}
//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
