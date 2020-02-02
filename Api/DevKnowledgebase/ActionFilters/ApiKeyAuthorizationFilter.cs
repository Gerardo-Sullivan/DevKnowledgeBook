using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Api.Models.Configuration;
using Microsoft.Extensions.Options;

namespace Api.ActionFilters
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        public const string _apiKeyHeader = "Api-Key";
        private readonly string _apiKey;

        public ApiKeyAuthorizationFilter(IOptions<DevKnowledgeBookConfiguration> devKnowledgeBookConfig)
        {
            _apiKey = devKnowledgeBookConfig.Value.ApiKey;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasApiKeyHeader = context.HttpContext.Request.Headers.TryGetValue(_apiKeyHeader, out StringValues clientApiKey);

            if (!hasApiKeyHeader)
            {
                context.Result = new UnauthorizedObjectResult(new { error = $"{_apiKeyHeader} header missing." });
                return;
            }

            if (!clientApiKey.ToString().Equals(_apiKey))
            {
                context.Result = new UnauthorizedObjectResult(new { error = $"{_apiKeyHeader} is invalid." });
                return;
            }
        }
    }
}
