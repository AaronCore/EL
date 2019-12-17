using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EL.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using EL.Common;

namespace EL.Admin.Filters
{
    /// <summary>
    /// 全局异常拦截
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Task.Run(() => { new LogService().SaveException(context.Exception); });
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            var obj = new
            {
                code = -1,
                message = context.Exception.Message,
            };
            context.Result = new ContentResult { Content = obj.ToJson() };
        }
    }
}
