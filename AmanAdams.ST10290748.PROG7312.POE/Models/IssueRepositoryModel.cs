
//Aman Adams
//ST10290748
//PROG7312
//POE PART 3


using System.Collections.Generic;
using System.Linq;


namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class IssueRepositoryModel
    {
        private readonly AppDbContext _context;

        public IssueRepositoryModel(AppDbContext context)
        {
            _context = context;
        }

        public void AddIssue(IssueModel issue)
        {
            _context.Issues.Add(issue);
            _context.SaveChanges();
        }

        public IssueModel? GetIssueByRequestId(string requestId)
        {
            return _context.Issues.FirstOrDefault(i => i.RequestId == requestId);
        }

        public IEnumerable<IssueModel> GetAllIssues()
        {
            return _context.Issues.OrderByDescending(i => i.CreatedAt).ToList();
        }
    }
}

//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
