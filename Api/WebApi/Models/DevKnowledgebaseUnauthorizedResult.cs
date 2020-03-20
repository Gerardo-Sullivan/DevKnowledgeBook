using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiContracts;

namespace WebApi.Models
{
    public class DevKnowledgebaseUnauthorizedResult : UnauthorizedObjectResult
    {
        public DevKnowledgebaseUnauthorizedResult(ErrorResponse errorResponse) : base(errorResponse)
        {
        }
    }
}
