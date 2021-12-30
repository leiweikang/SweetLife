using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using Lwk.MyLife.Core.CommonDtos;

namespace Lwk.MyLife.Core.Filters
{
    /// <summary>
    /// api过滤器 add by leiweikang 2021年12月7日 14:39:16
    /// </summary>
    public class CustomerActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public CustomerActionFilter()
        {

        }

        /// <summary>
        /// 请求时长计时开始
        /// </summary>
        private readonly Stopwatch watch = new Stopwatch();

        /// <summary>
        /// Action方法调用之前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //每次进入Action之前
            watch.Restart();
            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var strBody = JsonConvert.SerializeObject(context.ActionArguments);
            var request = context.HttpContext.Request;
            if (request != null)
            {
                var sbHeader = JsonConvert.SerializeObject(request.Headers.AsEnumerable());
                var obj = new
                {
                    request.Path,
                    request.Method,
                    request.Protocol,
                    request.Host,
                    body = strBody,
                    header = sbHeader.ToString()
                };

                Console.WriteLine($"请求Controller：{descriptor.ControllerName}");
                Console.WriteLine($"请求Action：{descriptor.ActionName}");
                Console.WriteLine($"请求协议：{obj.Protocol}");
                Console.WriteLine($"请求方式：{obj.Method}");
                Console.WriteLine($"请求主机：{obj.Host.Value}");
                Console.WriteLine($"请求路径：{obj.Path}");
                Console.WriteLine($"请求参数：{JsonConvert.SerializeObject(obj.body)}");
                Console.WriteLine($"请求header：{JsonConvert.SerializeObject(obj.header)}");
            }
            base.OnActionExecuting(context);
        }

        /// <summary>
        /// Action方法调用后，Result方法调用前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        /// <summary>
        /// Result方法调用后执行 500异常不进入；400会进入
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }

        /// <summary>
        /// Result方法调用前执行 500异常不进入；400会进入；404不进入
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //根据实际需求进行具体实现
            if (context.Result is OkObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult == null)
                {
                    throw new ArgumentException($"{nameof(context)} should be ObjectResult!");
                }
                if (!(objectResult.Value is CustomerActionResult))
                {
                    objectResult.Value = new CustomerActionResult()
                    {
                        HttpStatus = HttpStatusCode.OK,
                        Code = 2001,
                        Data = objectResult.Value,
                        Message = "成功返回数据",
                        TimeOut = watch.ElapsedMilliseconds
                    };
                }
            }
            else if (context.Result is BadRequestObjectResult)
            {
                //验证通过
                var objectResult = context.Result as ObjectResult;
                if (objectResult == null)
                {
                    throw new ArgumentException($"{nameof(context)} should be ObjectResult!");
                }
                if (!(objectResult.Value is CustomerActionResult))
                {
                    objectResult.Value = new CustomerActionResult()
                    {
                        HttpStatus = HttpStatusCode.BadRequest,
                        Code = 4001,
                        Data = objectResult.Value,
                        Message = "入参异常",
                        TimeOut = watch.ElapsedMilliseconds
                    };
                }
            }
            else if (context.Result is NoContentResult)
            {
                //验证通过
                context.Result = new ObjectResult(new CustomerActionResult()
                {
                    HttpStatus = HttpStatusCode.NoContent,
                    Code = 2004,
                    Data = "",
                    Message = "无内容返回",
                    TimeOut = watch.ElapsedMilliseconds
                });
            }
            else if (context.Result is NotFoundObjectResult)
            {
                //验证通过
                var objectResult = context.Result as ObjectResult;
                if (objectResult == null)
                {
                    throw new ArgumentException($"{nameof(context)} should be ObjectResult!");
                }
                if (!(objectResult.Value is CustomerActionResult))
                {
                    objectResult.Value = new CustomerActionResult()
                    {
                        HttpStatus = HttpStatusCode.NotFound,
                        Code = 4004,
                        Data = objectResult.Value,
                        Message = "查不到数据",
                        TimeOut = watch.ElapsedMilliseconds
                    };
                }
            }
            base.OnResultExecuting(context);
        }
    }
}
