namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class IssueServiceModel
    {
        private readonly IssueRepositoryModel _repo = new();

        public void ReportIssue(string location, IssueCategory category, string description, string attachment)
        {
            var issue = new IssueModel
            {
                Location = location,
                Category = category,
                Description = description,
                AttachmentPath = attachment
            };
            _repo.AddIssue(issue);
        }

        public IEnumerable<IssueModel> GetAllIssues() => _repo.GetAllIssues();
    }
}
