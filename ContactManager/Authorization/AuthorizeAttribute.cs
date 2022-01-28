using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ContactManager.Entities;

namespace ContactManager.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (User) context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new {message = "Unauthorized"})
                    {StatusCode = StatusCodes.Status401Unauthorized};
            }
            else
            {
                // cuban administrators permission if action is decorated with [AllowCubanAdministrators] attribute
                var allowCubanAdministrators = context.ActionDescriptor.EndpointMetadata.OfType<AllowCubanAdministratorsAttribute>().Any();
                if (allowCubanAdministrators)
                {
                    var userss = (User)context.HttpContext.Items["User"];
                    var userRoles = (List<string>)context.HttpContext.Items["UserRoles"];
                    
                    userRoles.ForEach(Console.WriteLine);
                    if(!userRoles.Contains("Administrator"))
                        context.Result = new JsonResult(new {message = "Forbidden"})
                            {StatusCode = StatusCodes.Status403Forbidden};
                }
            }
        }
    }
}