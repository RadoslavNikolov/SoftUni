namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Utils;

    public class Issue
    {
        private string title;
        private string description;
        private static int id;
        private readonly IList<Comment> comments; 

        static Issue()
        {
            id = 0;
        }

        public Issue(string title, string description, IssuePriority priority, IList<string> tags)
        {
            Issue.id++;
            this.comments = new List<Comment>();
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            this.Id = Issue.id;
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The title cannot be null or empty");
                }

                if (value.Length < Constants.MinIssueTittleTextLength)
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The description cannot be null or empty");
                }

                if (value.Length < Constants.MinIssueDescriptionTextLength)
                {
                    throw new ArgumentException(string.Format("The description must be at least 5 symbols long", Constants.MinIssueDescriptionTextLength));
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
                .AppendFormat("Priority: {0}", this.GetPriorityAsString())
                .AppendLine()
                .AppendLine(this.Description);

            this.AppendTags(output);       
            this.AppendComments(output);

            return output.ToString().Trim();
        }

        private void AppendComments(StringBuilder output)
        {
            if (this.comments.Count > 0)
            {
                output.AppendFormat("Comments:{0}{1}", Environment.NewLine, string.Join(Environment.NewLine, this.Comments))
                    .AppendLine();
            }
        }

        private void AppendTags(StringBuilder output)
        {
            if (this.Tags.Count > 0)
            {
                var orderedTags = this.Tags.OrderBy(t => t);
                output.AppendFormat("Tags: {0}", string.Join(",", orderedTags))
                    .AppendLine();
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