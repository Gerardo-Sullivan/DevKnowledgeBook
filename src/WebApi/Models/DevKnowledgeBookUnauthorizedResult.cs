using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.Errors;

namespace WebApi.Models
{
    public class DevKnowledgeBookUnauthorizedResult : UnauthorizedObjectResult
    {
        public DevKnowledgeBookUnauthorizedResult(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
