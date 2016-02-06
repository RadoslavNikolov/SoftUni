namespace BuhtigIssueTracker.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string urlString)
        {
            this.ParseEndpoint(urlString);         
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        private void ParseEndpoint(string urlString)
        {
            int questionMark = urlString.IndexOf('?');

            if (questionMark != -1)
            {
                this.ActionName = urlString.Substring(0, questionMark);
                this.Parameters = this.ParseParameters(urlString.Substring(questionMark + 1));
            }
            else
            {
                this.ActionName = urlString;
            }
        }

        private IDictionary<string, string> ParseParameters(string parametersTokens)
        {
            var pairs = parametersTokens
                    .Split('&')
                    .Select(x => x.Split('=').Select(xx => WebUtility.UrlDecode(xx)).ToArray());

            var parameters = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                parameters.Add(pair[0], pair[1]);
            }

            return parameters;
        }
    }
}