using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Api.Models.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApiContracts.ClientErrors;
using Common;

namespace Api.ActionFilters
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        public const string API_HEADER = "Api-Key";

        private readonly string _apiKey;
        private readonly ILogger<ApiKeyAuthorizationFilter> _logger;

        public ApiKeyAuthorizationFilter(
            ILogger<ApiKeyAuthorizationFilter> logger,
            IOptions<DevKnowledgeBookConfiguration> devKnowledgeBookConfig)
        {
            _apiKey = devKnowledgeBookConfig.Value.ApiKey;
            _logger = logger;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var request = context.GetRequestPath();
            bool hasApiKeyHeader = context.HttpContext.Request.Headers.TryGetValue(API_HEADER, out StringValues clientApiKey);

            if (!hasApiKeyHeader)
            {
                var errorMessage = $"{API_HEADER} header missing.";
                var errorResponse = new ClientErrorResponse(request, errorMessage, ClientErrorType.ApiKeyHeaderMissing);

                _logger.LogWarning(errorMessage);
                context.Result = new DevKnowledgebaseUnauthorizedResult(errorResponse);
                return;
            }

            if (!clientApiKey.ToString().Equals(_apiKey)) //TODO: look into which StringComparison to use if any
            {
                var errorMessage = $"{API_HEADER} is invalid.";
                var errorResponse = new ClientErrorResponse(request, errorMessage, ClientErrorType.ApiKeyDidNotMatch);

                _logger.LogWarning(errorMessage);
                context.Result = new DevKnowledgebaseUnauthorizedResult(errorResponse);
                return;
            }
        }
    }
}
