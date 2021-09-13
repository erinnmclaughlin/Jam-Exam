using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Server.Authentication
{
    public class JamAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (TokenManager)context.HttpContext.RequestServices.GetService(typeof(TokenManager));
            var hasToken = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);

            if (!hasToken || !tokenManager.VerifyToken(token).Result)
            {
                context.ModelState.AddModelError("Unauthorized", "Invalid or missing token.");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            }
        }
    }
}
