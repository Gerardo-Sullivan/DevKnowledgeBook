using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Contracts.Errors;

namespace WebApi.Models
{
    public class DevKnowledgeBookInternalServerResult : ObjectResult
    {
        public DevKnowledgeBookInternalServerResult(ErrorResponse errorResponse) : base(errorResponse)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
