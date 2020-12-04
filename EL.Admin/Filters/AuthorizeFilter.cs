using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace EL.Admin.Filters
{
    public class AuthorizeFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            int uid = context.HttpContext.Session.GetInt32("uid") ?? 0;
            if (uid <= 0)
            {
                RedirectToActionResult content = new RedirectToActionResult("Index", "Login", null);
                context.Result = content;
            }
        }
    }
}
