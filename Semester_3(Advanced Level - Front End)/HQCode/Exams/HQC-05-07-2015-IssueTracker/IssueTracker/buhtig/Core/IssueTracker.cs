namespace BuhtigIssueTracker.Core {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;
    using Models.Enums;
    using Utils;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data;
        }

        private IBuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(IEndpoint endpoint)
        {
            string username = endpoint.Parameters["username"];
            string password = endpoint.Parameters["password"];
            string confirmPassword = endpoint.Parameters["confirmPassword"];
            if (this.Data.CurrentLoggedUser != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            if (this.Data.UsersDictionaryByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.AddUser(user);
           
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(IEndpoint endpoint)
        {
            string username = endpoint.Parameters["username"];
            string password = endpoint.Parameters["password"];
            if (this.Data.CurrentLoggedUser != null)
            {
                return "There is already a logged in user";
            }

            if (!this.Data.UsersDictionaryByUsername.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.UsersDictionaryByUsername[username];
            if (user.UserPassword != HashUtils.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            this.Data.CurrentLoggedUser = user;

            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }
            string username = this.GetCurrentUsername();
            this.Data.CurrentLoggedUser = null;

            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(IEndpoint endpoint)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            string title = endpoint.Parameters["title"];
            string description = endpoint.Parameters["description"];
            IssuePriority priority =
                (IssuePriority) Enum.Parse(typeof (IssuePriority), endpoint.Parameters["priority"], true);
            IList<string> tagsList = endpoint.Parameters["tags"].Split('|');

            var newIssue = new Issue(title, description, priority, tagsList.Distinct().ToList());
            this.Data.AddIssue(newIssue);

            return string.Format("Issue {0} created successfully.", newIssue.Id);
        }

        public string RemoveIssue(IEndpoint endpoint)
        {
            int issueId = int.Parse(endpoint.Parameters["id"]);

            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Data.IssuesById.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssuesById[issueId];
            var username = this.GetCurrentUsername();
            if (!this.Data.IssuesByUsername[username].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}", issueId, username);
            }

            this.Data.RemoveIssue(issue);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(IEndpoint endpoint)
        {
            int issueId = int.Parse(endpoint.Parameters["id"]);
            string commentText = endpoint.Parameters["text"];

            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            var issue = this.Data.GetIssueById(issueId);
            if (issue == null)
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var comment = new Comment(this.Data.CurrentLoggedUser, commentText);
            issue.AddComment(comment);
            this.Data.AddCommentForLoggedUser(comment);

            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues() 
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            var username = this.GetCurrentUsername();
            var issuesForCurrentUser = this.Data.IssuesByUsername[username];

            //BUG: I think this is unnecessary
            //var newIssues = issues;

            if (!issuesForCurrentUser.Any())
            {
                //BUG: I think this is unnecessary
                //var result = "";
                //foreach (var i in this.Data.IssuesByUsername)
                //{
                //    result += i.Value.Select(iss => iss.Comments.Select(c => c.Content)).ToString();
                //}

                return "No issues";
            }

            return string.Join(Environment.NewLine, issuesForCurrentUser.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }

        public string GetMyComments() 
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            var comments = new List<Comment>();
            this.Data.IssuesById.Select(i => i.Value.Comments).ToList()
                .ForEach(item => comments.AddRange(item));

            var username = this.GetCurrentUsername();
            var resultComments = comments
                .Where(c => c.User.UserName == username)
                .Select(c => c.ToString())
                .ToList();

            //Bug: This is unnecessary
            //var commentsAsString = resultComments
            //    .Select(x => x.ToString()).ToArray();

            if (!resultComments.Any())
            {
                return "No comments";
            }

            return string.Join(Environment.NewLine, resultComments);
        }

        public string SearchForIssues(string[] strings) {
            if (strings.Length < 0)
            {
                return "There are no tags provided";
            }

            var i = new List<Issue>();
            foreach (var t in strings)
            {
                i.AddRange(this.Data.IssuesByTag[t]);
            }

            if (!i.Any())
            {
                return "There are no issues matching the tags provided";
            }
            var newi = i.Distinct();
            if (!newi.Any())
            {
                return "No issues";
            }

            return string.Join(Environment.NewLine, newi.OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(x => string.Empty));
        }

        private string GetCurrentUsername()
        {
            return this.Data.CurrentLoggedUser.UserName;
        }
        
    }
}
