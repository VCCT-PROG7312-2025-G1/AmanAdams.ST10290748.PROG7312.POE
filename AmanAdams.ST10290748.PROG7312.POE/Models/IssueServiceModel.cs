
using System.Linq;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 3


namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class IssueServiceModel
    {
        private readonly IssueRepositoryModel _repo;

        public IssueServiceModel(IssueRepositoryModel repo)
        {
            _repo = repo;
        }

        public IssueModel ReportIssue(string location, IssueCategory category, string description, string attachment)
        {
            var issue = new IssueModel
            {
                Location = location,
                Category = category,
                Description = description,
                AttachmentPath = attachment
            };

            _repo.AddIssue(issue);
            return issue;
        }

        public IssueModel? GetIssueByRequestId(string requestId)
        {
            return _repo.GetIssueByRequestId(requestId);
        }

        public IEnumerable<IssueModel> GetAllIssues() => _repo.GetAllIssues();
    }
}
//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
