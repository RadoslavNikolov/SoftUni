namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using BuhtigIssueTracker.Models;
    using Wintellect.PowerCollections;

    /// <summary>
    /// 
    /// </summary>
    public interface IBuhtigIssueTrackerData
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        User CurrentUser { get; set; }

        /// <summary>
        /// Gets the users by username.
        /// </summary>
        /// <value>
        /// The users by username.
        /// </value>
        IDictionary<string, User> UsersByUsername { get; }

        /// <summary>
        /// Gets the issues by identifier.
        /// </summary>
        /// <value>
        /// The issues by identifier.
        /// </value>
        OrderedDictionary<int, Issue> IssuesById { get; }

        /// <summary>
        /// Gets the issues by username.
        /// </summary>
        /// <value>
        /// The issues by username.
        /// </value>
        MultiDictionary<string, Issue> IssuesByUsername { get; }

        /// <summary>
        /// Gets the issues by tags.
        /// </summary>
        /// <value>
        /// The issues by tags.
        /// </value>
        MultiDictionary<string, Issue> IssuesByTags { get; }

        /// <summary>
        /// Gets the comments by users.
        /// </summary>
        /// <value>
        /// The comments by users.
        /// </value>
        MultiDictionary<User, Comment> CommentsByUsers { get; }

        /// <summary>
        /// Adds the issue.
        /// </summary>
        /// <param name="issue">The issue.</param>
        /// <returns></returns>
        int AddIssue(Issue issue);

        /// <summary>
        /// Removes the issue.
        /// </summary>
        /// <param name="issue">The issue.</param>
        void RemoveIssue(Issue issue);
    }
}
