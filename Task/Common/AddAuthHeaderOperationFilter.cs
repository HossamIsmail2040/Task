using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Task.Common
{
    public class AddAuthHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Policy names map to scopes
            var requiredScopes = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Select(attr => attr.Policy)
                .Distinct();

            if (requiredScopes.Any())
            {
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

                var oAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                    {
                        new OpenApiSecurityRequirement
                        {
                            [ oAuthScheme ] = requiredScopes.ToList()
                        }
                    };
            }

            operation.Responses.Add("404", new OpenApiResponse { Description = "Not Found" });
            operation.Responses.Add("406", new OpenApiResponse { Description = "Business Exception" });
            operation.Responses.Add("422", new OpenApiResponse { Description = "Validation Exception" });
            operation.Responses.Add("500", new OpenApiResponse { Description = "Internal Server Error. Please call customer support." });
        }
    }

}

