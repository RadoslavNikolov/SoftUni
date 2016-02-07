namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;
    using Utils;

    public class Comment
    {
        private string text;

        public Comment(User user, string text)
        {
            this.User = user;
            this.Text = text;
        }

        public User User { get; private set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinCommentTextLength)
                {
                    throw new ArgumentException(string.Format("The text must be at least {0} symbols long", Constants.MinCommentTextLength));
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine(this.Text)
                .AppendFormat("-- {0}", (object)this.User.UserName)
                .AppendLine();

            return output.ToString().Trim();
        }
    }
}