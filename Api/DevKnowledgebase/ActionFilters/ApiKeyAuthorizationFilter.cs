using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Api.Models.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Api.Models;
using System;

namespace Api.ActionFilters
{
    public class ApiKeyAuthorizationFilter : IAuthorizationFilter
    {
        public const string _apiKeyHeader = "Api-Key";

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
            bool hasApiKeyHeader = context.HttpContext.Request.Headers.TryGetValue(_apiKeyHeader, out StringValues clientApiKey);

            if (!hasApiKeyHeader)
            {
                var errorMessage = $"{_apiKeyHeader} header missing.";
                var errorResponse = new ErrorResponse
                {
                    Request = context.HttpContext.Request.Path.Value,
                    ErrorTime = DateTime.UtcNow,
                    Error = new Error
                    {
                        Message = errorMessage,
                        Type = "ApiKeyHeaderMissing"
                    }
                };

                _logger.LogWarning(errorMessage);
                context.Result = new UnauthorizedObjectResult(errorResponse);
                return;
            }

            if (!clientApiKey.ToString().Equals(_apiKey))
            {
                var errorMessage = $"{_apiKeyHeader} is invalid.";
                var errorResponse = new ErrorResponse
                {
                    Request = context.HttpContext.Request.Path.Value,
                    ErrorTime = DateTime.UtcNow,
                    Error = new Error
                    {
                        Message = errorMessage,
                        Type = "ApiKeyDidNotMatch"
                    }
                };

                _logger.LogWarning(errorMessage);
                context.Result = new UnauthorizedObjectResult(errorResponse);
                return;
            }
        }
    }
}
