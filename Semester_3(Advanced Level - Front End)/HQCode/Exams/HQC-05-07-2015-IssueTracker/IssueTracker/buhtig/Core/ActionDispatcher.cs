namespace BuhtigIssueTracker.Core
{
    using Interfaces;
    using Models.Enums;

    public class ActionDispatcher : IDispatcher
    {
        public ActionDispatcher(IIssueTracker issueTracker)
        {
            this.IssueTracker = issueTracker;
        }

        private IIssueTracker IssueTracker { get; set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.IssueTracker.RegisterUser(endpoint);
                case "LoginUser":
                    return this.IssueTracker.LoginUser(endpoint);
                case "LogoutUser":
                    return this.IssueTracker.LogoutUser();
                case "CreateIssue":
                    return this.IssueTracker.CreateIssue(endpoint);
                case "RemoveIssue":
                    return this.IssueTracker.RemoveIssue(endpoint);
                case "AddComment":
                    return this.IssueTracker.AddComment(endpoint);
                case "MyIssues": 
                    return this.IssueTracker.GetMyIssues();
                case "MyComments": 
                    return this.IssueTracker.GetMyComments();
                case "Search":
                    return this.IssueTracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}