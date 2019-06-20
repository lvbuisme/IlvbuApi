using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace IlvbuService
{
    /// <summary>
    /// 认证保护筛选
    /// </summary>
    public abstract class AuthProtectedFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {


        protected abstract AuthInfo GetAuthInfo(AuthorizationFilterContext context);

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AuthInfo authInfo = GetAuthInfo(context);
            if (authInfo == null)
            {
                context.Result = new ForbidResult();
            }       
        }
    }
    public class UserAuthProtectedFilterAttribute : AuthProtectedFilterAttribute
    {
        public UserAuthProtectedFilterAttribute()  { }

        protected override AuthInfo GetAuthInfo(AuthorizationFilterContext context)
        {
            return context.HttpContext.User.ToAuthInfo<WxAuthInfo>(null);
        }
    }

}
