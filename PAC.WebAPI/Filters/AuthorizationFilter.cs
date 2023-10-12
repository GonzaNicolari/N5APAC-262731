using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["token"].ToString();
            if (string.IsNullOrEmpty(authorizationHeader)) 
            {
                context.Result = new BadRequestObjectResult("No puedo authorizarme");
            }
        }

    }
}

