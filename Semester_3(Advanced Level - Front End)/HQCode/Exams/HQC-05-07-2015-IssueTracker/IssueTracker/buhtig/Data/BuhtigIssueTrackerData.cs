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
            this.UsersDictionaryByUsername = new Dictionary<string, User>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);
            this.UsersCommentDictionaryByUser = new MultiDictionary<User, Comment>(true);
        }

        public User CurrentLoggedUser { get; set; }
        public IDictionary<string, User> UsersDictionaryByUsername { get; private set; }
        public OrderedDictionary<int, Issue> IssuesById { get; private set; }
        public MultiDictionary<string, Issue> IssuesByUsername { get; private set; }
        public MultiDictionary<string, Issue> IssuesByTag { get; private set; }
        public MultiDictionary<User, Comment> UsersCommentDictionaryByUser { get; private set; }

        public void AddUser(User user)
        {
            this.UsersDictionaryByUsername.Add(user.UserName, user);
        }

        public void AddIssue(Issue issue)
        {
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Add(issue);
            }

            this.IssuesById.Add(issue.Id, issue);
            this.IssuesByUsername[this.CurrentLoggedUser.UserName].Add(issue);
        }

        public void RemoveIssue(Issue issue)
        {           
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
            this.IssuesByUsername[this.CurrentLoggedUser.UserName].Remove(issue);
        }

        public Issue GetIssueById(int issueId)
        {
            if (!this.IssuesById.ContainsKey(issueId))
            {
                return default(Issue);
            }

            var issue = this.IssuesById[issueId];

            return issue;
        }

        public void AddCommentForLoggedUser(Comment comment)
        {
            this.UsersCommentDictionaryByUser[this.CurrentLoggedUser].Add(comment);
        }
    }
}