using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IlvbuService
{
    //public class ControllerGuardFilter : IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {

    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
    //        foreach (ParameterDescriptor pd in context.ActionDescriptor.Parameters)
    //        {
    //            if (!(pd is ControllerParameterDescriptor)) continue;

    //            ParameterInfo pi = ((ControllerParameterDescriptor)pd).ParameterInfo;
    //            object value = context.ActionArguments.ContainsKey(pd.Name) ? context.ActionArguments[pd.Name] : null;
    //            RouteData routeData = GuardHandler.HandleParameter(pi, value);
    //            if (!routeData.IsSccuess)
    //            {
    //                context.Result = new JsonResult(routeData);
    //            }
    //        }
    //    }
    //}
}
