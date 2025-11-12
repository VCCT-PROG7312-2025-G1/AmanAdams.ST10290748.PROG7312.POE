
//Aman Adams
//ST10290748
//PROG7312
//POE PART 3


namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    // BST Node
    public class IssueNode
    {
        public IssueModel Issue { get; set; }
        public IssueNode Left { get; set; }
        public IssueNode Right { get; set; }

        public IssueNode(IssueModel issue)
        {
            Issue = issue;
        }
    }

    // BST
    public class IssueBST
    {
        public IssueNode Root { get; private set; }

        public void Insert(IssueModel issue)
        {
            Root = InsertRec(Root, issue);
        }

        private IssueNode InsertRec(IssueNode node, IssueModel issue)
        {
            if (node == null) return new IssueNode(issue);

            // Compare by RequestId
            if (string.Compare(issue.RequestId, node.Issue.RequestId) < 0)
                node.Left = InsertRec(node.Left, issue);
            else
                node.Right = InsertRec(node.Right, issue);

            return node;
        }

        public IssueModel Search(string requestId)
        {
            return SearchRec(Root, requestId);
        }

        private IssueModel SearchRec(IssueNode node, string requestId)
        {
            if (node == null) return null;
            if (node.Issue.RequestId == requestId) return node.Issue;

            return string.Compare(requestId, node.Issue.RequestId) < 0
                ? SearchRec(node.Left, requestId)
                : SearchRec(node.Right, requestId);
        }
    }

}


//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//

