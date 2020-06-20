using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Errors;

namespace WebApi.Models
{
    public class DevKnowledgeBookBadRequestObjectResult : BadRequestObjectResult
    {
        public DevKnowledgeBookBadRequestObjectResult(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
