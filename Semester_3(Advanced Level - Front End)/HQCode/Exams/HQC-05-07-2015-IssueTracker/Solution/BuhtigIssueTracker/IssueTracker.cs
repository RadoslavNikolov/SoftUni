namespace BuhtigIssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BuhtigIssueTracker.Data;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;
    using BuhtigIssueTracker.Utilities;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        public IBuhtigIssueTrackerData Data { get; private set; }

        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="username">The username of the user to register</param>
        /// <param name="password">The password of the user to register</param>
        /// <param name="confirmPassword">The confirmation of the password of the user to register. To complete the registration,
        /// the two passwords must match</param>
        /// <returns>
        /// In case of success, returns a success message.
        /// If the passwords do not match, there is another user with the same username in the database,
        /// or there is already a logged in user, returns an error message.
        /// </returns>
        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.HasLoggedInUser())
            {
                return string.Format("There is already a logged in user");
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.UsersByUsername.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.HasLoggedInUser())
            {
                return string.Format("There is already a logged in user");
            }

            if (!this.Data.UsersByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.UsersByUsername[username];
            if (user.PasswordHash != HashUtility.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Data.CurrentUser = user;
            return string.Format("User {0} logged in successfully", username);
        }


        /// <summary>
        /// Logs out the logged in user from the application.
        /// </summary>
        /// <returns>
        /// In case of success, returns a success message.
        /// If there is no currently logged in user, returns an error message.
        /// </returns>
        public string LogoutUser()
        {
            if (!this.HasLoggedInUser())
            {
                return string.Format("There is no currently logged in user");
            }

            string username = this.Data.CurrentUser.Username;
            this.Data.CurrentUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            if (!this.HasLoggedInUser())
            {
                return string.Format("There is no currently logged in user");
            }

            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            int issueId = this.Data.AddIssue(issue);
            return string.Format("Issue {0} created successfully", issueId);
        }

        public string RemoveIssue(int issueId)
        {
            if (!this.HasLoggedInUser())
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            if (!this.Data.IssuesByUsername[this.Data.CurrentUser.Username].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}", issueId, this.Data.CurrentUser.Username);
            }

            this.Data.RemoveIssue(issue);
            return string.Format("Issue {0} removed", issueId);
        }

        /// <summary>
        /// Adds a comment to the issue given by the specified ID by the current user.
        /// </summary>
        /// <param name="issueId">The unique ID of the issue to add a comment to</param>
        /// <param name="text">The text of the comment</param>
        /// <returns>
        /// In case of success, returns a success message.
        /// If there is no issue with the specified ID, the issue text is less than 2 symbols long,
        /// or there is no currently logged in user, returns an error message.
        /// </returns>
        public string AddComment(int issueId, string text)
        {
            if (!this.HasLoggedInUser())
            {
                return string.Format("There is no currently logged in user");
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            var comment = new Comment(this.Data.CurrentUser, text);
            issue.AddComment(comment);
            this.Data.CommentsByUsers[this.Data.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        /// <summary>
        /// Returns the issues by the current user ordered by priority in descending order first
        /// and then by title in ascending order.
        /// </summary>
        /// <returns>
        /// In case of success, returns the issues. If there is no currently logged in user,
        /// or if there are no issues to show, returns an error message.
        /// </returns>
        public string GetMyIssues()
        {
            if (!this.HasLoggedInUser())
            {
                return string.Format("There is no currently logged in user");
            }

            var issues = this.Data.IssuesByUsername[this.Data.CurrentUser.Username];
            return this.FormatIssuesForPrinting(issues);
        }

        public string GetMyComments()
        {
            if (!this.HasLoggedInUser())
            {
                return string.Format("There is no currently logged in user");
            }

            var comments = this.Data.CommentsByUsers[this.Data.CurrentUser]
                .Select(i => i.ToString());
            if (!comments.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, comments);
        }

        /// <summary>
        /// Searches for issues which have one or more of the provided tags.
        /// </summary>
        /// <param name="tags">The tags to search for</param>
        /// <returns>
        /// In case of success, returns the issues ordered by priority in descending order first
        /// and then by title in ascending order. If there are no tags or no matching issues,
        /// returns an error message.
        /// </returns>
        public string SearchForIssues(string[] tags)
        {
            if (tags.Length == 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.IssuesByTags[tag]);
            }

            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            return this.FormatIssuesForPrinting(issues.Distinct());
        }

        private bool HasLoggedInUser()
        {
            return this.Data.CurrentUser != null;
        }

        /// <summary>
        /// Formats the issues for printing.
        /// </summary>
        /// <param name="issues">The issues.</param>
        /// <returns></returns>
        private string FormatIssuesForPrinting(IEnumerable<Issue> issues)
        {
            if (!issues.Any())
            {
                return "No issues";
            }

            var issuesAsStrings = issues
                .OrderByDescending(i => i.Priority)
                .ThenBy(i => i.Title)
                .Select(i => i.ToString());
            return string.Join(Environment.NewLine, issuesAsStrings);
        }
    }
}
