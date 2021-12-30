using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lwk.MyLife.Core.CommonDtos
{
    /// <summary>
    /// 数据返回模型基类
    /// </summary>
    public class CustomerActionResult
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public virtual HttpStatusCode HttpStatus { get; set; } = HttpStatusCode.OK;

        public virtual int Code { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public virtual object Data { get; set; }

        /// <summary>
        /// 获取 消息内容
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 执行时长
        /// </summary>
        public virtual long TimeOut { get; set; }
    }
}
