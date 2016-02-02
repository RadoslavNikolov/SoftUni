namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentLoggedUser { get; set; }

        IDictionary<string, User> UsersDictionary { get; }

        MultiDictionary<Issue, string>Issues { get; }

        OrderedDictionary<int, Issue> Issues1 { get; }

        MultiDictionary<string, Issue> Issues2 { get; }

        MultiDictionary<string, Issue> Issues4 { get; }

        MultiDictionary<User, Comment> Dict { get; }

        int AddIssue(Issue p);

        void RemoveIssue(Issue p);
    }
}