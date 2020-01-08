using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NetCore_MyMiddleware
{
    /// <summary>
    /// 约定大于配置
    /// </summary>
    public class MyMiddlewareSecond
    {
        private readonly RequestDelegate _next;

        //1.需要实现一个构造函数，参数requestDelegate
        public MyMiddlewareSecond(RequestDelegate next)
        {
            _next = next;
        }
        //2.需要实现一个叫做InvokeAsync 的方法
        public async Task InvokeAsync(HttpContext context)
        {
            //throw new NotImplementedException("这是一个按照约定编写的中间件，但没有具体实现内容");
            await _next.Invoke(context);
        }
    }
}
