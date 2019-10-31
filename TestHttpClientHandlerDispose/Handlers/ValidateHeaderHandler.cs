using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestHttpClientHandlerDispose.Handlers
{
    public class ValidateHeaderHandler : DelegatingHandler
    {
        private readonly ILogger _logger;

        public ValidateHeaderHandler(ILogger<ValidateHeaderHandler> logger)
        {
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("X-API-KEY"))
            {
                _logger.LogInformation("not found");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
