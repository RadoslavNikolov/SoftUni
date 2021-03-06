﻿namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Utils;

    public class Issue
    {
        private static int id;
        private readonly IList<Comment> comments;      
        private string title;
        private string description;       
        
        static Issue()
        {
            id = 1;
        }

        public Issue(string title, string description, IssuePriority priority, IList<string> tags)
        {          
            this.comments = new List<Comment>();
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;       
            this.Id = Issue.id;
            Issue.id++;
        }

        public int Id { get; private set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinIssueTittleTextLength)
                {
                    throw new ArgumentException(string.Format("The title must be at least {0} symbols long", Constants.MinIssueTittleTextLength));
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinIssueDescriptionTextLength)
                {
                    throw new ArgumentException(string.Format("The description must be at least {0} symbols long", Constants.MinIssueDescriptionTextLength));
                }

                this.description = value;
            }
        }

        public IssuePriority Priority { get; set; }

        public IList<string> Tags { get; set; }

        public IEnumerable<Comment> Comments
        {
            get { return this.comments; }
        }

        public void AddComment(Comment comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(this.Title)
                .AppendFormat("Priority: {0}{1}", this.GetPriorityAsString(), Environment.NewLine)
                .AppendLine(this.Description);

            this.AppendTags(output);       
            this.AppendComments(output);

            return output.ToString().Trim();
        }

        private void AppendComments(StringBuilder output)
        {
            if (this.comments.Count > 0)
            {
                output.AppendFormat("Comments:{0}{1}{2}", Environment.NewLine, string.Join(Environment.NewLine, this.Comments), Environment.NewLine);
            }
        }

        private void AppendTags(StringBuilder output)
        {
            if (this.Tags.Count > 0)
            {
                output.AppendFormat("Tags: {0}{1}", string.Join(",", this.Tags.OrderBy(t => t)), Environment.NewLine);
            }
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePriority.Showstopper:
                    return "****";
                case IssuePriority.High:
                    return "***";
                case IssuePriority.Medium:
                    return "**";
                case IssuePriority.Low:
                    return "*";
                default:
                    throw new InvalidOperationException("The priority is invalid");
            }
        }
    }
}