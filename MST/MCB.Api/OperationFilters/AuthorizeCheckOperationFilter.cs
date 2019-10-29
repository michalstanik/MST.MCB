using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MCB.Api.OperationFilters
{
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            
            //// policy names map to scopes
            //var requiredscopes = context.MethodInfo
            //    .DeclaringType
            //    .GetCustomAttributes(true)
            //    .OfType<AuthorizeAttribute>();
            //    //.Select(attr => attr.Policy)
            //    //.Distinct();

            ////var authotize = context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>();

            //context.ApiDescription.TryGetMethodInfo(out var methodInfo);

            //if (methodInfo == null)
            //    return;

            //var hasAuthorizeAttribute = false;

            //if (methodInfo.MemberType == MemberTypes.Method)
            //{
            //    // NOTE: Check the controller itself has Authorize attribute
            //    hasAuthorizeAttribute = methodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            //    // NOTE: Controller has Authorize attribute, so check the endpoint itself.
            //    //       Take into account the allow anonymous attribute
            //    if (hasAuthorizeAttribute)
            //        hasAuthorizeAttribute = !methodInfo.GetCustomAttributes(true).OfType<AllowAnonymousAttribute>().Any();
            //    else
            //        hasAuthorizeAttribute = methodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();
            //}

            //if (!hasAuthorizeAttribute)
            //    return;

            //   operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            //   operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
            //var oAuthScheme = new OpenApiSecurityScheme
            //{ 
            //        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            //};

            //operation.Security = new List<OpenApiSecurityRequirement>()
            //{
            //    new OpenApiSecurityRequirement
            //    {

            //    }
            //};





            //if (requiredScopes.Any())
            //{
            //    operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            //    operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });

            //    var oAuthScheme = new OpenApiSecurityScheme
            //    {
            //        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            //    };

            //    operation.Security = new List<OpenApiSecurityRequirement>
            //    {
            //    new OpenApiSecurityRequirement
            //    {
            //        [ oAuthScheme ] = requiredScopes.ToList()
            //    }
            //};
            //}
        }
    }
}
