using Api.ActionFilters;
using Microsoft.OpenApi.Models;

namespace Api.Models
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
