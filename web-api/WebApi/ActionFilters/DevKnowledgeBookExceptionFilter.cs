using Common.Extensions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using WebApi.Contracts.Errors;
using WebApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApi.ActionFilters
{
    public class DevKnowledgeBookExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<DevKnowledgeBookExceptionFilter> _logger;

        public DevKnowledgeBookExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            ILogger<DevKnowledgeBookExceptionFilter> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                return;
            }

            var exception = context.Exception;
            var request = context.GetRequestPath();

            if (exception is NaturalLangaugeInvalidUrlException ex)
            {
                var errorTitle = "Invalid Url";
                var errorDescription = $"Invalid Url {ex.InvalidUrl}.";
                var errorResponse = new ErrorResponse(request, HttpStatusCode.BadRequest, errorTitle, errorDescription);

                context.Result = new DevKnowledgeBookBadRequestObjectResult(errorResponse);
            }
            else
            {
                var errorTitle = "Internal Server Error";
                var errorDescription = $"An unexpected error occurred.";
                var errorResponse = new ErrorResponse(request, HttpStatusCode.InternalServerError, errorTitle, errorDescription);

                context.Result = new DevKnowledgeBookInternalServerResult(errorResponse);
            }
        }
    }
}
