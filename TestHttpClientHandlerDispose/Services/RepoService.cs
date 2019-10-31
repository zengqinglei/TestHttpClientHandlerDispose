using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TestHttpClientHandlerDispose.Models;

namespace TestHttpClientHandlerDispose.Services
{
    /// <inheritdoc />
    public class RepoService : IRepoService
    {
        private readonly HttpClient _httpClient;

        /// <inheritdoc />
        public RepoService(HttpClient client)
        {
            _httpClient = client;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<GitHubIssue>> GetRepos()
        {
            var response = await _httpClient.GetAsync("repos/aspnet/AspNetCore.Docs/issues?state=open&sort=created&direction=desc");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IEnumerable<GitHubIssue>>();

            return result;
        }
    }
}
