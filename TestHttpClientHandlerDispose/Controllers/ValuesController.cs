using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestHttpClientHandlerDispose.Models;
using TestHttpClientHandlerDispose.Services;

namespace TestHttpClientHandlerDispose.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepoService _repoService;

        /// <inheritdoc />
        public ValuesController(IRepoService repoService)
        {
            _repoService = repoService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<GitHubIssue>> Get()
        {
            return await _repoService.GetRepos();
        }
    }
}
