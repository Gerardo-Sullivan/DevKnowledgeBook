using Microsoft.AspNetCore.Mvc;
using WebApi.Contracts.ClientErrors;

namespace WebApi.Models
{
    public class DevKnowledgebaseUnauthorizedResult : UnauthorizedObjectResult
    {
        public DevKnowledgebaseUnauthorizedResult(ClientErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
