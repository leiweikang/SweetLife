using Lwk.MyLife.Core.CommonDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Lwk.MyLife.Core.Filters
{
    /// <summary>
    /// 异常过滤器 add by leiweikang 2021年12月8日 23:31:46
    /// </summary>
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// 重写OnExceptionAsync方法，定义自己的处理逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            // 已验证可用
            // 如果异常没有被处理则进行处理
            if (context.ExceptionHandled == false)
            {
                // 定义返回类型
                var result = new CustomerActionResult
                {
                    HttpStatus = HttpStatusCode.InternalServerError,
                    Code = 5001,
                    Data = $"Message:{context.Exception.Message}|StackTrace:{context.Exception.StackTrace}",
                    Message = "服务器异常",
                    TimeOut = 0
                };
                context.Result = new ObjectResult(result);
            }
            // 设置为true，表示异常已经被处理了
            context.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
