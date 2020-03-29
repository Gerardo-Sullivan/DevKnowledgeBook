using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.ClientErrors;

namespace WebApi.Models
{
    public class DevKnowledgeBookUnauthorizedResult : UnauthorizedObjectResult
    {
        public DevKnowledgeBookUnauthorizedResult(ClientErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
