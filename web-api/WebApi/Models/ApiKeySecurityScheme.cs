using Microsoft.OpenApi.Models;
using WebApi.ActionFilters;

namespace WebApi.Models
{
    public class ApiKeySecurityScheme : OpenApiSecurityScheme
    {
        public static ApiKeySecurityScheme Instance()
        {
            return new ApiKeySecurityScheme
            {
                Name = ApiKeyAuthorizationFilter.API_HEADER,
                In = ParameterLocation.Header,
                Description = "Please enter the api key for the application.",
                Type = SecuritySchemeType.ApiKey,
            };
        }
    }
}
