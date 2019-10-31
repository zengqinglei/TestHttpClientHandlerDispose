using Newtonsoft.Json;
using System;

namespace TestHttpClientHandlerDispose.Models
{
    /// <summary>
    /// A partial representation of an issue object from the GitHub API
    /// </summary>
    public class GitHubIssue
    {
        [JsonProperty("html_url")]
        public string Url { get; set; }

        public string Title { get; set; }

        [JsonProperty("created_at")]
        public DateTime Created { get; set; }
    }
}
