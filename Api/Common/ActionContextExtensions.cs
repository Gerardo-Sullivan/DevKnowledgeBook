using Microsoft.AspNetCore.Mvc;

namespace Common
{
    public static class ActionContextExtensions
    {
        public static string GetRequestPath(this ActionContext context)
        {
            return context.HttpContext.Request.Path.Value;
        }
    }
}
