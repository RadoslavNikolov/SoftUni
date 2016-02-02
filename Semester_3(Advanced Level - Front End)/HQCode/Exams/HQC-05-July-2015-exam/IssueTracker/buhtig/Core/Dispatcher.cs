namespace BuhtigIssueTracker.Core
{
    using Interfaces;
    using Models.Enums;

    public class Dispatcher : IDispatcher
    {
        public Dispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public IIssueTracker Tracker { get; private set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.Tracker.RegisterUser(endpoint.Parameters["username"], endpoint.Parameters["password"], endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.Tracker.LoginUser(endpoint.Parameters["username"], endpoint.Parameters["password"]);
                case "CreateIssue":
                    return this.Tracker.CreateIssue(endpoint.Parameters["title"], endpoint.Parameters["description"],
                        (IssuePriority)System.Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true),
                        endpoint.Parameters["tags"].Split('/'));
                case "RemoveIssue":
                    return this.Tracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                case "AddComment":
                    return this.Tracker.AddComment(
                        int.Parse(endpoint.Parameters["Id"]),
                        endpoint.Parameters["text"]);
                case "MyIssues": return this.Tracker.GetMyIssues();
                case "MyComments": return this.Tracker.GetMyComments();
                case "Search":
                    return this.Tracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}