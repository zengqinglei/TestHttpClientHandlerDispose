using System.Collections.Generic;
using System.Threading.Tasks;
using TestHttpClientHandlerDispose.Models;

namespace TestHttpClientHandlerDispose.Services
{
    /// <summary>
    /// /Hello服务
    /// </summary>
    public interface IRepoService
    {
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        Task<IEnumerable<GitHubIssue>> GetRepos();
    }
}
