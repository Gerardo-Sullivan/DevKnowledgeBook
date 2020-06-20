using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using WebApi.Models;
using Common.Extensions;
using WebApi.Contracts.Errors;
using System.Net;

namespace WebApi
{
    public static class DevKnowledgeBookModelStateValidator
    {
        public static IActionResult ValidateModelState(ActionContext context) //TODO: look over this code
        {
            //TODO: try tidy up and add logging
            var request = context.GetRequestPath();
            (string fieldName, ModelStateEntry entry) = context.ModelState
            .First(x => x.Value.Errors.Count > 0);
            string errorMessage = entry.Errors.First().ErrorMessage;

            var errorResponse = new ErrorResponse(request, HttpStatusCode.BadRequest, ErrorTitle.InvalidModel, errorMessage);

            return new DevKnowledgeBookUnauthorizedResult(errorResponse);
        }
    }
}
