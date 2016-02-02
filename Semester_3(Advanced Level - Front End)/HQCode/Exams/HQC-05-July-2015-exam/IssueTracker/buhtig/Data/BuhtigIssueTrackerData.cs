namespace BuhtigIssueTracker.Data
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {     
        public BuhtigIssueTrackerData()
        {
            this.UsersDictionary = new Dictionary<string, User>();
            this.Issues = new MultiDictionary<Issue, string>(true);
            this.Issues1 = new OrderedDictionary<int, Issue>();
            this.Issues2 = new MultiDictionary<string, Issue>(true);
            this.Issues4 = new MultiDictionary<string, Issue>(true);
            this.Dict = new MultiDictionary<User, Comment>(true);
        }

        public User CurrentLoggedUser { get; set; }
        public IDictionary<string, User> UsersDictionary { get; }
        public MultiDictionary<Issue, string> Issues { get;}
        public OrderedDictionary<int, Issue> Issues1 { get; }
        public MultiDictionary<string, Issue> Issues2 { get; }
        public MultiDictionary<string, Issue> Issues4 { get; }
        public MultiDictionary<User, Comment> Dict { get; }

        public int AddIssue(Issue issue)
        {
            // Todo: Implement AddIssue method
            return 0;
        }

        public void RemoveIssue(Issue issue)
        {
            // Todo: Implement RemoVaIssue method
            return;
        }
    }
}