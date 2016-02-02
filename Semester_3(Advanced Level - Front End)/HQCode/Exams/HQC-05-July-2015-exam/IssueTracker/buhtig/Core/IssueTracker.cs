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

        private IBuhtigIssueTrackerData Data { get; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return string.Format("The provided passwords do not match", username);
            }

            if (this.Data.UsersDictionary.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            var user = new User(username, password);
            this.Data.UsersDictionary.Add(username, user);

            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is already a logged in user";
            }

            if (!this.Data.UsersDictionary.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            var user = this.Data.UsersDictionary[username];
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
            string username = this.Data.CurrentLoggedUser.UserName;
            this.Data.CurrentLoggedUser = null;

            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            var issue = new Issue(title, description, priority, strings.Distinct().ToList());
            this.Data.Issues1.Add(issue.Id, issue);
            this.Data.Issues2[this.Data.CurrentLoggedUser.UserName].Add(issue);

            foreach (var tag in issue.Tags)
            {
                this.Data.Issues4[tag].Add(issue);
            }

            return string.Format("Issue {0} created successfully.", issue.Id);
        }
        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Data.Issues1.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }
            var issue = this.Data.Issues1[issueId];
            if (!this.Data.Issues2[this.Data.CurrentLoggedUser.UserName].Contains(issue))
            {
                return string.Format("The issue with ID {0} does not belong to user {1}", issueId, this.Data.CurrentLoggedUser.UserName);
            }

            this.Data.Issues2[this.Data.CurrentLoggedUser.UserName].Remove(issue);

            foreach (var tag in issue.Tags)
            {
                this.Data.Issues4[tag].Remove(issue);
            }
            this.Data.Issues1.Remove(issue.Id);

            return string.Format("Issue {0} removed", issueId);
        }
        public string AddComment(int intValue, string stringValue) {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }
            if (!this.Data.Issues1.ContainsKey(intValue + 1))
            {
                return string.Format("There is no issue with ID {0}", intValue + 1);
            }
            var issue = this.Data.Issues1[intValue];
            var comment = new Comment(this.Data.CurrentLoggedUser, stringValue);
            issue.AddComment(comment);
            this.Data.Dict[this.Data.CurrentLoggedUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }
        public string GetMyIssues() {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }

            var issues = this.Data.Issues2[this.Data.CurrentLoggedUser.UserName];
            var newIssues = issues;
            if (!newIssues.Any())
            {
                var result = "";
                foreach (var i in this.Data.Issues2)
                {
                    result += i.Value.Select(iss => iss.Comments.Select(c => c.Content)).ToString();
                }

                return "No issues";
            }
            return string.Join(Environment.NewLine, newIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
        public string GetMyComments() {
            if (this.Data.CurrentLoggedUser == null)
            {
                return "There is no currently logged in user";
            }
            var comments = new List<Comment>();
            this.Data.Issues1.Select(i => i.Value.Comments).ToList()
                .ForEach(item => comments.AddRange(item));
            var resultComments = comments
                .Where(c => c.User.UserName == this.Data.CurrentLoggedUser.UserName)
                .ToList();
            var strings = resultComments
                .Select(x => x.ToString());
            if (!strings.Any())
            {
                return "No comments";
            }
            return string.Join(Environment.NewLine, strings);
        }

        public string SearchForIssues(string[] strings) {
            if (strings.Length < 0)
                return "There are no tags provided";

            var i = new List<Issue>();
            foreach (var t in strings)
                i.AddRange(this.Data.Issues4[t]);
            if (!i.Any())
                return "There are no issues matching the tags provided";
            var newi = i.Distinct();
            if (!newi.Any())
            {
                return "No issues";
            }
            return string.Join(Environment.NewLine, newi.OrderByDescending(x => x.Priority).ThenBy(x => x.Title).Select(x => string.Empty));
        }

        
    }
}
