using Common.Extensions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using WebApi.Contracts.Errors;
using WebApi.Models;
using WebApi.Exceptions;

namespace WebApi.ActionFilters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(
            ILogger<ApiExceptionFilter> logger
        )
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var request = context.GetRequestPath();

            switch (exception)
            {
                case NaturalLangaugeInvalidUrlException naturalLangaugeInvalidUrlException:
                    {
                        var errorTitle = "Invalid Url";
                        var errorDescription = $"Invalid Url {naturalLangaugeInvalidUrlException.InvalidUrl}.";
                        var errorResponse = new ErrorResponse(request, HttpStatusCode.BadRequest, errorTitle, errorDescription);

                        context.Result = new DevKnowledgeBookBadRequestObjectResult(errorResponse);
                        _logger.LogError(naturalLangaugeInvalidUrlException, errorDescription);
                        break;
                    }
                case NoBookmarkExitsException noBookmarkExitsException:
                    {
                        var errorTitle = "Bookmark exists";
                        var errorDescription = $"Bookmark with url {noBookmarkExitsException.RequestUrl} already exits.";
                        var errorResponse = new ErrorResponse(request, HttpStatusCode.BadRequest, errorTitle, errorDescription);

                        context.Result = new DevKnowledgeBookBadRequestObjectResult(errorResponse);
                        _logger.LogError(noBookmarkExitsException, errorDescription);
                        break;
                    }
                default:
                    {
                        var errorTitle = "Internal Server Error";
                        var errorDescription = $"An unexpected error occurred.";
                        var errorResponse = new ErrorResponse(request, HttpStatusCode.InternalServerError, errorTitle, errorDescription);

                        context.Result = new DevKnowledgeBookInternalServerResult(errorResponse);
                        _logger.LogError(exception, errorDescription);
                        break;
                    }
            }
        }
    }
}
