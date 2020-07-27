using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yomi.Blog.ToolKits.Helper;

namespace Yomi.Blog.HttpApi.Hosting.Filters
{
    public class YomiBlogExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
