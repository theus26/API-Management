using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace API_PeopleManagement.Authenticate;

public class ManagementAuthenticateAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public string Roles { get; set; }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authorizationHeader = context.HttpContext.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
        {
            context.Result = new JsonResult(new { error = "Token not found or incorrectly formatted" })
            {
                StatusCode = 401
            };
            return;
        }
        var token = authorizationHeader.Replace("Bearer ", "").Trim();

        try
        {
            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
            {
                throw new SecurityTokenException("Invalid token");
            }

            var jwtToken = handler.ReadJwtToken(token);

            if (jwtToken.ValidTo <= DateTime.Now)
            {
                context.Result = new JsonResult(new { error = "Expired token" })
                {
                    StatusCode = 401
                };
                return;
            }
    
            var rolesClaim = jwtToken.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();

            {
                var requiredRoles = Roles.Split(',');
                if (!requiredRoles.Any(requiredRole => rolesClaim.Contains(requiredRole.Trim())))
                {
                    context.Result = new JsonResult(new { error = "User does not have the necessary permission" })
                    {
                        StatusCode = 403
                    };
                    return;
                }
            }

            var subject = jwtToken.Subject;
            if (string.IsNullOrEmpty(subject))
            {
                context.Result = new JsonResult(new { error = "Unauthorized user" })
                {
                    StatusCode = 403
                };
            }
    
            context.HttpContext.Session.SetString("Subject", subject);
        }
        catch (Exception ex)
        {
            context.Result = new JsonResult(new { error = ex.Message })
            {
                StatusCode = 401
            };
        }
    }
}