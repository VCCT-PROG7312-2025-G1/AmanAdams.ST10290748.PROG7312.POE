using System.Collections;

// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class IssueRepositoryModel
    {
        private readonly Hashtable _issues = new();

        public void AddIssue(IssueModel issue)
        {
            _issues[issue.Id] = issue;  
        }

        public IssueModel? GetIssue(Guid id)
        {
            return (IssueModel?)_issues[id];
        }

        public IEnumerable<IssueModel> GetAllIssues()
        {
            foreach (IssueModel issue in _issues.Values)
                yield return issue;
        }
    }
}
