namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;
    using Utils;

    public class Comment
    {
        private string content;

        public Comment(User user, string content)
        {
            this.User = user;
            this.Content = content;
        }

        public User User { get; private set; }

        public string Content
        {
            get
            {
                return this.content;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The content cannot be null or empty");
                }

                if (value.Length < Constants.MinCommentTextLength)
                {
                    throw new ArgumentException(string.Format("The content must be at least {0} symbols long", Constants.MinCommentTextLength));
                }

                this.content = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(this.Content)
                .AppendFormat("-- {0}", (object)this.User.UserName)
                .AppendLine();

            return output.ToString().Trim();
        }
    }
}