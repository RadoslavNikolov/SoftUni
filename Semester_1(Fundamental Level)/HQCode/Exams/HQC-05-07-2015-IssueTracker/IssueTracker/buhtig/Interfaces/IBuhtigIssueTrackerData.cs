namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentLoggedUser { get; set; }

        IDictionary<string, User> UsersDictionaryByUsername { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> UsersCommentDictionaryByUser { get; }

        void AddUser(User user);

        void AddIssue(Issue issue);

        void RemoveIssue(Issue issue);

        Issue GetIssueById(int issueId);

        void AddCommentForLoggedUser(Comment comment);
    }
}